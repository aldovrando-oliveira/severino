namespace Severino.Extensions.Exceptions
{
    public interface IBaseException
    {
        /// <summary>
        /// Código de identificação do erro
        /// </summary>
        string ErrorCode { get; }
    }
}