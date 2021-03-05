using System;
using System.Runtime.Serialization;

namespace Severino.Extensions.Exceptions
{
    /// <summary>
    /// Ocorre quando recebe uma resposta inválida do servidor para o qual foi encaminhado a requisição. 
    /// </summary>
    [Serializable]
    public sealed class BadGatewayException : BaseException
    {
        /// <summary>
        /// Retorna uma nova instância de <see cref="BadGatewayException"/>
        /// </summary>
        /// <param name="info">Informações para a serialização</param>
        /// <param name="context">Contexto para o stream</param>
        private BadGatewayException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        /// <summary>
        /// Retorna uma nova instância de <see cref="BadGatewayException"/>
        /// </summary>
        /// <param name="message">Mensagem descritiva do erro</param>
        public BadGatewayException(string message) 
            : base(message)
        {
        }

        /// <summary>
        /// Retorna uma nova instância de <see cref="BadGatewayException"/>
        /// </summary>
        /// <param name="message">Mensagem descritiva do erro</param>
        /// <param name="errorCode">Código de identificação do erro</param>
        public BadGatewayException(string message, string errorCode) 
            : base(message, errorCode)
        {
        }

        /// <summary>
        /// Retorna uma nova instância de <see cref="BadGatewayException"/>
        /// </summary>
        /// <param name="message">Mensagem descritiva do erro</param>
        /// <param name="innerException">Erro original que gerou a exceção atual</param>
        public BadGatewayException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Retorna uma nova instância de <see cref="BadGatewayException"/>
        /// </summary>
        /// <param name="message">Mensagem descritiva do erro</param>
        /// <param name="errorCode">Código de identificação do erro</param>
        /// <param name="innerException">Erro original que gerou a exceção atual</param>
        public BadGatewayException(string message, string errorCode, Exception innerException) 
            : base(message, errorCode, innerException)
        {
        }
    }
}