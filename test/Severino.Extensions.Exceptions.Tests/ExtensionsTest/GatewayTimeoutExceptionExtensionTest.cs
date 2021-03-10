using System;
using Xunit;

namespace Severino.Extensions.Exceptions.Tests.ExtensionsTest
{
    public class GatewayTimeoutExceptionExtensionTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("  ")]
        public void ToGatewayTimeoutException_Throw_IfMessageInvalid(string message)
        {
            var baseException = new Exception("Unexpected Error");

            var exception = Assert.Throws<ArgumentException>(() => 
                baseException.ToGatewayTimeoutException(message));
            
            Assert.Null(exception.ParamName);
            Assert.Equal("Message cannot be null.", exception.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("  ")]
        public void ToGatewayTimeoutException_Throw_IfMessageInvalidAndErrorCodeValid(string message)
        {
            var baseException = new Exception("Unexpected Error");

            var exception = Assert.Throws<ArgumentException>(() => 
                baseException.ToGatewayTimeoutException(message, "ABC500"));
            
            Assert.Null(exception.ParamName);
            Assert.Equal("Message cannot be null.", exception.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("  ")]
        public void ToGatewayTimeoutException_Throw_IfMessageValidAndErrorCodeInvalid(string errorCode)
        {
            var baseException = new Exception("Unexpected Error");

            var exception = Assert.Throws<ArgumentException>(() => 
                baseException.ToGatewayTimeoutException("Error Message", errorCode));
            
            Assert.Null(exception.ParamName);
            Assert.Equal("ErrorCode cannot be null.", exception.Message);
        }

        [Fact]
        public void ToGatewayTimeoutException_Success_IfMessageValid()
        {
            var baseException = new Exception("Unexpected Error");

            var ex = baseException.ToGatewayTimeoutException("Error Message");

            Assert.NotNull(ex);
            Assert.IsType<GatewayTimeoutException>(ex);
            Assert.Null(ex.ErrorCode);
            Assert.NotNull(ex.InnerException);
            Assert.Equal("Unexpected Error", ex.InnerException.Message);
            Assert.Equal("Error Message: Unexpected Error", ex.Message);
        }

        [Fact]
        public void ToGatewayTimeoutException_Success_IfMessageValidAndErrorCodeValid()
        {
            var baseException = new Exception("Unexpected Error");

            var ex = baseException.ToGatewayTimeoutException("Error Message", "ABC500");

            Assert.NotNull(ex);
            Assert.IsType<GatewayTimeoutException>(ex);
            Assert.NotNull(ex.ErrorCode);
            Assert.NotNull(ex.InnerException);
            Assert.Equal("ABC500", ex.ErrorCode);
            Assert.Equal("Unexpected Error", ex.InnerException.Message);
            Assert.Equal("ABC500 - Error Message: Unexpected Error", ex.Message);
        }
    }
}