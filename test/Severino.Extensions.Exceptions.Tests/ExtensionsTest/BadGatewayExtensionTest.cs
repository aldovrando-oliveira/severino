using System;
using Xunit;

namespace Severino.Extensions.Exceptions.Tests.ExtensionsTest
{
    public class BadGatewayExtensionTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("  ")]
        public void ToBadGatewayException_Throw_IfMessageInvalid(string message)
        {
            var baseException = new Exception("Unexpected Error");

            var exception = Assert.Throws<ArgumentException>(() => 
                baseException.ToBadGatewayException(message));
            
            Assert.Null(exception.ParamName);
            Assert.Equal("Message cannot be null.", exception.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("  ")]
        public void ToBadGatewayException_Throw_IfMessageInvalidAndErrorCodeValid(string message)
        {
            var baseException = new Exception("Unexpected Error");

            var exception = Assert.Throws<ArgumentException>(() => 
                baseException.ToBadGatewayException(message, "ABC500"));
            
            Assert.Null(exception.ParamName);
            Assert.Equal("Message cannot be null.", exception.Message);
        }
        
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("  ")]
        public void ToBadGatewayException_Throw_IfMessageValidAndErrorCodeInvalid(string errorCode)
        {
            var baseException = new Exception("Unexpected Error");

            var exception = Assert.Throws<ArgumentException>(() => 
                baseException.ToBadGatewayException("Error Message", errorCode ));
            
            Assert.Null(exception.ParamName);
            Assert.Equal("ErrorCode cannot be null.", exception.Message);
        }

        [Fact]
        public void ToBadGatewayException_Success_IfMessageValid()
        {
            var baseException = new Exception("Unexpected Error");

            var ex = baseException.ToBadGatewayException("Error Message");

            Assert.NotNull(ex);
            Assert.IsType<BadGatewayException>(ex);
            Assert.Null(ex.ErrorCode);
            Assert.NotNull(ex.InnerException);
            Assert.Equal("Unexpected Error", ex.InnerException.Message);
            Assert.Equal("Error Message: Unexpected Error", ex.Message);
        }

        [Fact]
        public void ToBadGatewayException_Success_IfMessageValidAndErrorCodeValid()
        {
            var baseException = new Exception("Unexpected Error");

            var ex = baseException.ToBadGatewayException("Error Message", "ABC500");

            Assert.NotNull(ex);
            Assert.IsType<BadGatewayException>(ex);
            Assert.NotNull(ex.ErrorCode);
            Assert.NotNull(ex.InnerException);
            Assert.Equal("ABC500", ex.ErrorCode);
            Assert.Equal("Unexpected Error", ex.InnerException.Message);
            Assert.Equal("ABC500 - Error Message: Unexpected Error", ex.Message);
        }
    }
}