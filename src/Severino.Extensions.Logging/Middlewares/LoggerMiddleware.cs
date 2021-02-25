using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IO;
using Severino.Extensions.Logging.Models;
using Severino.Extensions.Logging.Options;
using Severino.Extensions.Serialization;

namespace Severino.Extensions.Logging.Middlewares
{
    
    public class LoggerMiddleware : IMiddleware
    {
        const string RegexErrors = "5[0-9]{2}";
        private static string CurrentVersion => Assembly.GetExecutingAssembly().GetName().Version?.ToString();
        private static string ProjectName => Assembly.GetExecutingAssembly().GetName().Name;
        private readonly RecyclableMemoryStreamManager _recyclableMemoryStreamManager;
        private readonly ILogger<LoggerMiddleware> _logger;
        private readonly LoggerMiddlewareOptions _options;

        public LoggerMiddleware(ILogger<LoggerMiddleware> logger, IOptions<LoggerMiddlewareOptions> options)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _options = options?.Value ?? throw new ArgumentNullException(nameof(options));
            
            _recyclableMemoryStreamManager = new RecyclableMemoryStreamManager();
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            HttpModel httpModel;

            httpModel = await LogRequest(context);
            httpModel = await LogResponse(context, next, httpModel);


            if (!context.Request.Path.Value.StartsWith("/api"))
                return;

            var logLevel = Regex.IsMatch(httpModel.StatusCode.ToString(), RegexErrors)
                ? "ERROR" : "INFO";
            
            var log = new ApiLogModel
            {
                App = ProjectName,
                Team = _options.Team,
                Kind = "server",
                Version = CurrentVersion,
                Level = logLevel,
                Http = httpModel
            };

            var logMessage = log.ToJson();

            _logger.LogInformation(new EventId(), logMessage);
        }

        private async Task<HttpModel> LogRequest(HttpContext context)
        {
            string requestBody;

            context.Request.EnableBuffering();

            await using var requestStream = _recyclableMemoryStreamManager.GetStream();
            await context.Request.Body.CopyToAsync(requestStream);

            requestBody = ReadStreamInChunks(requestStream);

            context.Request.Body.Position = 0;

            var logHttp = new HttpModel();
            logHttp.RequestMethod = context.Request.Method;
            logHttp.Url = context.Request.Path;
            logHttp.Path = context.Request.Path;
            logHttp.Protocol = context.Request.Scheme;
            logHttp.RequestHeader = context.Request.Headers.ToJson();
            logHttp.RequestBody = requestBody;

            return logHttp;
        }

        private async Task<HttpModel> LogResponse(HttpContext context, RequestDelegate next, HttpModel model)
        {
            var originalBodyStream = context.Response.Body;

            await using var responseBody = _recyclableMemoryStreamManager.GetStream();
            context.Response.Body = responseBody;

            Stopwatch watch = new Stopwatch();
            watch.Start();

            try
            {
                await next(context);
            }
            finally
            {
                watch.Stop();

                context.Response.Body.Seek(0, SeekOrigin.Begin);
                var responseText = await new StreamReader(context.Response.Body).ReadToEndAsync();
                context.Response.Body.Seek(0, SeekOrigin.Begin);

                await responseBody.CopyToAsync(originalBodyStream);

                model.LatencySeconds = watch.ElapsedMilliseconds / 1000D;
                model.ResponseBody = responseText;
                model.ResponseHeader = context.Response.Headers.ToJson();
                model.StatusCode = context.Response.StatusCode;
            }

            return model;
        }

        private static string ReadStreamInChunks(Stream stream)
        {
            const int readChunkBufferLength = 4096;

            stream.Seek(0, SeekOrigin.Begin);

            using var textWriter = new StringWriter();
            using var reader = new StreamReader(stream);

            var readChunk = new char[readChunkBufferLength];
            int readChunkLength;

            do
            {
                readChunkLength = reader.ReadBlock(readChunk,
                                                   0,
                                                   readChunkBufferLength);
                textWriter.Write(readChunk, 0, readChunkLength);
            } while (readChunkLength > 0);

            return textWriter.ToString();
        }
    }}