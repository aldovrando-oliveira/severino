using System;
using System.Runtime.Serialization;

namespace Severino.Extensions.Exceptions
{
    /// <summary>
    /// Exceção de conflitos nas entidades
    /// </summary>
    [Serializable]
    public class ConflictException : BaseException
    {
        /// <summary>
        /// Cria uma nova instância de <see cref="ConflictException"/>
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected ConflictException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="ConflictException"/>
        /// </summary>
        /// <param name="message">Mensagem descritiva da exceção</param>
        public ConflictException(string message) 
            : base(message)
        {
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="ConflictException"/>
        /// </summary>
        /// <param name="message">Mensagem descritiva da exceção</param>
        /// <param name="errorCode">Código do erro</param>
        public ConflictException(string message, string errorCode)
            : base(message, errorCode)
        {
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="ConflictException"/>
        /// </summary>
        /// <param name="message">Mensagem descritiva da exceção</param>
        /// <param name="innerException">Erro de origem da exceção </param>
        public ConflictException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="ConflictException"/>
        /// </summary>
        /// <param name="message">Mensagem descritiva da exceção</param>
        /// <param name="errorCode">Código do erro</param>
        /// <param name="innerException">Erro de origem da exceção </param>
        public ConflictException(string message, string errorCode, Exception innerException)
            : base(message, errorCode, innerException)
        {
        }
   }
}