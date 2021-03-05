using System;

namespace Severino.Extensions.Exceptions
{
    /// <summary>
    /// Extensões para auxiliar o uso das exceções
    /// </summary>
    public static class ExceptionsExtensions
    {
        #region ConflictException
        
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
        
        #endregion
        
        #region EntityNotFoundException

        /// <summary>
        /// Retorna uma exceção do tipo <see cref="EntityNotFoundException"/>
        /// </summary>
        /// <param name="exception">Exceção original</param>
        /// <param name="entity">Nome da entidade referênciada pela exceção</param>
        /// <returns>Retorna uma nova instância de <see cref="EntityNotFoundException"/></returns>
        public static EntityNotFoundException ToEntityNotFoundException(this Exception exception, string entity) =>
            new (entity, exception);

        /// <summary>
        /// Retorna uma exceção do tipo <see cref="EntityNotFoundException"/>
        /// </summary>
        /// <param name="exception">Exceção original</param>
        /// <param name="entity">Nome da entidade referênciada pela exceção</param>
        /// <param name="errorCode">Código de identificação do erro</param>
        /// <returns>Retorna uma nova instância de <see cref="EntityNotFoundException"/></returns>
        public static EntityNotFoundException ToEntityNotFoundException(this Exception exception, string entity,
            string errorCode) => new(entity, errorCode, exception);

        /// <summary>
        /// Retorna uma exceção do tipo <see cref="EntityNotFoundException"/>
        /// </summary>
        /// <param name="exception">Exceção original</param>
        /// <param name="entity">Nome da entidade referênciada pela exceção</param>
        /// <param name="errorCode">Código de identificação do erro</param>
        /// <param name="message">Mensagem descritiva do erro</param>
        /// <returns>Retorna uma nova instância de <see cref="EntityNotFoundException"/></returns>
        public static EntityNotFoundException ToEntityNotFoundException(this Exception exception, string entity,
            string errorCode, string message) => new(entity, errorCode, message, exception);

        #endregion
        
        #region BadGatewayException

        /// <summary>
        /// Retorna uma exceção do tipo <see cref="BadGatewayException"/>
        /// </summary>
        /// <param name="exception">Exceção original</param>
        /// <param name="message">Mensagem descritiva do erro</param>
        /// <returns>Retorna uma nova instância de <see cref="BadGatewayException"/></returns>
        public static BadGatewayException ToBadGatewayException(this Exception exception, string message) =>
            new(message, exception);

        /// <summary>
        /// Retorna uma exceção do tipo <see cref="BadGatewayException"/>
        /// </summary>
        /// <param name="exception">Exceção original</param>
        /// <param name="message">Mensagem descritiva do erro</param>
        /// <param name="errorCode">Código de identificação do erro</param>
        /// <returns>Retorna uma nova instância de <see cref="BadGatewayException"/></returns>
        public static BadGatewayException ToBadGatewayException(this Exception exception, string message,
            string errorCode) => new(message, errorCode, exception);

        #endregion
        
        #region GatewayTimeout

        /// <summary>
        /// Retorna uma exceçção do tipo <see cref="GatewayTimeoutException"/>
        /// </summary>
        /// <param name="exception">Exceção original</param>
        /// <param name="message">Mensagem descritiva do erro</param>
        /// <returns>Retorna uma nova instância de <see cref="GatewayTimeoutException"/></returns>
        public static GatewayTimeoutException ToGatewayTimeoutException(this Exception exception, string message) =>
            new(message, exception);

        /// <summary>
        /// Retorna uma exceçção do tipo <see cref="GatewayTimeoutException"/>
        /// </summary>
        /// <param name="exception">Exceção original</param>
        /// <param name="message">Mensagem descritiva do erro</param>
        /// <param name="errorCode">Código de identificação do erro</param>
        /// <returns>Retorna uma nova instância de <see cref="GatewayTimeoutException"/></returns>
        public static GatewayTimeoutException ToGatewayTimeoutException(this Exception exception, string message,
            string errorCode) => new(message, errorCode, exception);

        #endregion
    }
}