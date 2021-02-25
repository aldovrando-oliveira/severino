namespace Severino.Extensions.Logging.Options
{
    public class LoggerMiddlewareOptions
    {
        /// <summary>
        /// Time responsável pelo serviço
        /// </summary>
        public string Team { get; set; }
        
        /// <summary>
        /// HttpStatusCode que serão considerados erro.
        /// </summary>
        public string StatusError { get; set; }
        
        /// <summary>
        /// Path que serão desconsiderados para o registro de logs
        /// </summary>
            public string ExcludePath { get; set; }
    }
}