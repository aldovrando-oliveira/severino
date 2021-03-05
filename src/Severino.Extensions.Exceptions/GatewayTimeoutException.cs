using System;
using System.Runtime.Serialization;

namespace Severino.Extensions.Exceptions
{
    /// <summary>
    /// Exceção de timeout no uso de algum serviço
    /// </summary>
    [Serializable]
    public sealed class GatewayTimeoutException : BaseException
    {
        /// <summary>
        /// Retorna uma nova instância de <see cref="GatewayTimeoutException"/>
        /// </summary>
        /// <param name="info">Informações para a serialização</param>
        /// <param name="context">Contexto para o stream</param>
        private GatewayTimeoutException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Retorna uma nova instância de <see cref="GatewayTimeoutException"/>
        /// </summary>
        /// <param name="message">Mensagem descritiva do erro</param>
        public GatewayTimeoutException(string message) 
            : base(message)
        {
        }

        /// <summary>
        /// Retorna uma nova instância de <see cref="GatewayTimeoutException"/>
        /// </summary>
        /// <param name="message">Mensagem descritiva do erro</param>
        /// <param name="errorCode">Código de identificação do erro</param>
        public GatewayTimeoutException(string message, string errorCode) 
            : base(message, errorCode)
        {
        }

        /// <summary>
        /// Retorna uma nova instância de <see cref="GatewayTimeoutException"/>
        /// </summary>
        /// <param name="message">Mensagem descritiva do erro</param>
        /// <param name="innerException">Erro original que gerou a exceção atual</param>
        public GatewayTimeoutException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Retorna uma nova instância de <see cref="GatewayTimeoutException"/>
        /// </summary>
        /// <param name="message">Mensagem descritiva do erro</param>
        /// <param name="errorCode">Código de identificação do erro</param>
        /// <param name="innerException">Erro original que gerou a exceção atual</param>
        public GatewayTimeoutException(string message, string errorCode, Exception innerException) 
            : base(message, errorCode, innerException)
        {
        }
    }
}