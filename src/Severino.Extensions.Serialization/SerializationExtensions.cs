using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Severino.Extensions.Serialization
{
    public static class SerializationExtensions
    {
        private static JsonSerializerSettings DefaultSettings => new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            DateFormatHandling = DateFormatHandling.IsoDateFormat,
            DateTimeZoneHandling = DateTimeZoneHandling.Utc,
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
        };
        
        /// <summary>
        /// Serializa um objeto para texto no formato json
        /// </summary>
        /// <param name="value">Objeto a ser serializado</param>
        /// <param name="settings">Configurações para realizar a serialização</param>
        /// <returns>Retorna o texto serializado</returns>
        public static string ToJson(this object value, JsonSerializerSettings settings) =>
            JsonConvert.SerializeObject(value, settings);

        /// <summary>
        /// Serializa um objeto para texto no formato json
        /// </summary>
        /// <param name="value">Objeto a ser serializado</param>
        /// <param name="configureSettings">Função para configuração da serialização</param>
        /// <returns></returns>
        public static string ToJson(this object value, Action<JsonSerializerSettings> configureSettings)
        {
            var settings = DefaultSettings;
            
            configureSettings.Invoke(settings);

            return value.ToJson(settings);
        }
        
        /// <summary>
        /// Serializa um objeto para texto no formato json
        /// </summary>
        /// <param name="value">Objeto a ser serializado</param>
        /// <returns>Retorna o texto serializado</returns>
        public static string ToJson(this object value) =>
            value.ToJson(DefaultSettings);

        /// <summary>
        /// Desserializa um texto json para o tipo informado
        /// </summary>
        /// <param name="json">Texto no formato json que será desserializado</param>
        /// <param name="settings">Configurações para realizar a desserialização</param>
        /// <typeparam name="T">Tipo do objeto que deve ser convertido</typeparam>
        /// <returns>Objeto preenchido a partir das informações no json</returns>
        public static T ToObject<T>(this string json, JsonSerializerSettings settings) where T : class =>
            JsonConvert.DeserializeObject<T>(json, settings);

        /// <summary>
        /// Desserializa um texto json para o tipo informado
        /// </summary>
        /// <param name="json">Texto no formato json que será desserializado</param>
        /// <typeparam name="T">Tipo do objeto que deve ser convertido</typeparam>
        /// <returns>Objeto preenchido a partir das informações no json</returns>
        public static T ToObject<T>(this string json) where T : class =>
            json.ToObject<T>(DefaultSettings);

    }
}