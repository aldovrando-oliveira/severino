using System;

namespace Severino.Extensions.Exceptions
{
    /// <summary>
    /// Extensões para auxiliar o uso das exceções
    /// </summary>
    public static class ExceptionsExtensions
    {
        /// <summary>
        /// Cria uma exceção do tipo <see cref="ConflictException"/>
        /// </summary>
        /// <remarks>
        /// <para>Cria uma nova exceção do tipo <see cref="ConflictException"/></para> 
        /// <para>É utilizado o erro original e mensagem informada para criar a nova exceção.</para>
        /// </remarks>
        /// <param name="exception">Exceção original</param>
        /// <param name="message">Mensagem da nova exceção</param>
        /// <returns>Retorna uma nova instância de <see cref="ConflictException"/></returns>
        public static ConflictException ToConflictException(this Exception exception, string message) =>
            new(message, exception);
        
        /// <summary>
        /// Retorna uma exceção do tipo <see cref="ConflictException"/>
        /// </summary>
        /// <remarks>
        /// <para>Cria uma nova exceção do tipo <see cref="ConflictException"/></para> 
        /// <para>É utilizado o erro original e mensagem informada para criar a nova exceção.</para>
        /// </remarks>
        /// <param name="exception">Exceção original</param>
        /// <param name="message">Mensagem da nova exceção</param>
        /// <param name="errorCode">Código de identificação do erro</param>
        /// <returns>Retorna uma nova instância de <see cref="ConflictException"/></returns>
        public static ConflictException ToConflictException(this Exception exception, string message, string errorCode) =>
            new(message, errorCode, exception);
    }
}