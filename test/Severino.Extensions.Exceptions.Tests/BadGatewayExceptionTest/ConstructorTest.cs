using System;
using Xunit;

namespace Severino.Extensions.Exceptions.Tests.BadGatewayExceptionTest
{
    public class ConstructorTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("  ")]
        public void Constructor_Throws_IfMessageInvalid(string message)
        {
            var exception = Assert.Throws<ArgumentException>(() => 
                new BadGatewayException(message));
            
            Assert.Null(exception.ParamName);
            Assert.Equal("Message cannot be null.", exception.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("  ")]
        public void Constructor_Throws_IfMessageInvalidAndErrorCodeValid(string message)
        {
            var exception = Assert.Throws<ArgumentException>(() => 
                new BadGatewayException(message, "ABC500"));
            
            Assert.Null(exception.ParamName);
            Assert.Equal("Message cannot be null.", exception.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("  ")]
        public void Constructor_Throws_ifMessageInvalidAndInnerExceptionValid(string message)
        {
            var exception = Assert.Throws<ArgumentException>(() => 
                new BadGatewayException(message, new Exception("Inner Message")));
            
            Assert.Null(exception.ParamName);
            Assert.Equal("Message cannot be null.", exception.Message);
        }
        
        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("  ")]
        public void Constructor_Throws_IfMessageInvalidAndErrorCodeInnerExceptionValid(string message)
        {
            var exception = Assert.Throws<ArgumentException>(() => 
                new BadGatewayException(message, "ABC500", new Exception("Inner Message")));
            
            Assert.Null(exception.ParamName);
            Assert.Equal("Message cannot be null.", exception.Message);
        }
        
        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("  ")]
        public void Constructor_Throws_IfMessageValidAndErrorCodeInvalid(string errorCode)
        {
            var exception = Assert.Throws<ArgumentException>(() => 
                new BadGatewayException("Unexpected Error", errorCode));
            
            Assert.Null(exception.ParamName);
            Assert.Equal("ErrorCode cannot be null.", exception.Message);
        }
        
        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("  ")]
        public void Constructor_Throws_IfErrorCodeInvalidAndMessageAndInnerExceptionValid(string errorCode)
        {
            var exception = Assert.Throws<ArgumentException>(() => 
                new BadGatewayException("Unexpected Error", errorCode, new Exception("Inner Message")));
            
            Assert.Null(exception.ParamName);
            Assert.Equal("ErrorCode cannot be null.", exception.Message);
        }

        [Fact]
        public void Constructor_Success_IfMessageValid()
        {
            var exception = new BadGatewayException("Unexpected Error");
            
            Assert.NotNull(exception);
            Assert.IsType<BadGatewayException>(exception);
            Assert.Null(exception.ErrorCode);
            Assert.Null(exception.InnerException);
            Assert.Equal("Unexpected Error", exception.Message);
        }

        [Fact]
        public void Constructor_Success_IfMessageAndErrorCodeValid()
        {
            var exception = new BadGatewayException("Unexpected Error", "ABC500");
            
            Assert.NotNull(exception);
            Assert.IsType<BadGatewayException>(exception);
            Assert.NotNull(exception.ErrorCode);
            Assert.Null(exception.InnerException);
            Assert.Equal("ABC500 - Unexpected Error", exception.Message);
            Assert.Equal("ABC500", exception.ErrorCode);
        }

        [Fact]
        public void Constructor_Success_IfMessageAndInnerExceptionValid()
        {
            var exception = new BadGatewayException("Unexpected Error", new Exception("Inner Message"));
            
            Assert.NotNull(exception);
            Assert.IsType<BadGatewayException>(exception);
            Assert.Null(exception.ErrorCode);
            Assert.NotNull(exception.InnerException);
            Assert.Equal("Unexpected Error: Inner Message", exception.Message);
            Assert.Equal("Inner Message", exception.InnerException.Message);
        }

        [Fact]
        public void Constructor_Success_IfMessageAndErrorCodeAndInnerExceptionValid()
        {
            var exception = new BadGatewayException("Unexpected Error", "ABC500", new Exception("Inner Message"));
            
            Assert.NotNull(exception);
            Assert.IsType<BadGatewayException>(exception);
            Assert.NotNull(exception.ErrorCode);
            Assert.NotNull(exception.InnerException);
            Assert.Equal("ABC500 - Unexpected Error: Inner Message", exception.Message);
            Assert.Equal("Inner Message", exception.InnerException.Message);
            Assert.Equal("ABC500", exception.ErrorCode);
        }
    }
}