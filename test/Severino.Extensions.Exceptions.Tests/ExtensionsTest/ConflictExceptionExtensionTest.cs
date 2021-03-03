using System;
using Xunit;

namespace Severino.Extensions.Exceptions.Tests.ExtensionsTest
{
    public class ConflictExceptionExtensionTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("  ")]
        public void ToConflictException_Throw_IfMessageInvalid(string message)
        {
            var baseException = new Exception("Unexpected Error");

            var exception = Assert.Throws<ArgumentException>(() => 
                baseException.ToConflictException(message));
            
            Assert.Null(exception.ParamName);
            Assert.Equal("Message cannot be null.", exception.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("  ")]
        public void ToConflictException_Throw_IfMessageInvalidAndErrorCodeValid(string message)
        {
            var baseException = new Exception("Unexpected Error");

            var exception = Assert.Throws<ArgumentException>(() => 
                baseException.ToConflictException(message, "5000"));
            
            Assert.Null(exception.ParamName);
            Assert.Equal("Message cannot be null.", exception.Message);
        }

        [Fact]
        public void ToConflictException_Success_IfMessageAndErrorCodeValid()
        {
            var baseException = new Exception("Unexpected Error");

            var ex = baseException.ToConflictException("Conflict Exception Message", "5000");
            
            Assert.NotNull(ex.InnerException);
            Assert.Equal("Unexpected Error", ex.InnerException.Message);
            Assert.IsType<Exception>(ex.InnerException);
            Assert.Equal("5000", ex.ErrorCode);
            Assert.Equal("5000 - Conflict Exception Message: Unexpected Error", ex.Message);
        }
    }
}