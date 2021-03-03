using System;
using Xunit;

namespace Severino.Extensions.Exceptions.Tests.ConflictExceptionTest
{
    public class ConstructorTest
    {
        
        #region Message Validation
        
        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("  ")]
        public void Constructor_Throws_IfMessageInvalid(string message)
        {
            var exception = Assert.Throws<ArgumentException>(() => 
                new ConflictException(message));
            
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
                new ConflictException(message, "5000"));
            
            Assert.Null(exception.ParamName);
            Assert.Equal("Message cannot be null.", exception.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("  ")]
        public void Constructor_Throws_IfMessageInvalidAndInnerExceptionValid(string message)
        {
            var exception = Assert.Throws<ArgumentException>(() => 
                new ConflictException(message, new Exception()));
            
            Assert.Null(exception.ParamName);
            Assert.Equal("Message cannot be null.", exception.Message);
        }
        
        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("  ")]
        public void Constructor_Throws_IfMessageInvalidAndErrorCodeAndInnerExceptionValid(string message)
        {
            var exception = Assert.Throws<ArgumentException>(() => 
                new ConflictException(message, "5000", new Exception()));
            
            Assert.Null(exception.ParamName);
            Assert.Equal("Message cannot be null.", exception.Message);
        }
        
        #endregion
        
        #region ErrorCode Validation
        
        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("  ")]
        public void Constructor_Throws_IfErrorCodeInvalidAndMessageValid(string errorCode)
        {
            var exception = Assert.Throws<ArgumentException>(() => 
                new ConflictException("Unexpected conflict error", errorCode));
            
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
                new ConflictException("Unexpected conflict error", errorCode, new Exception()));
            
            Assert.Null(exception.ParamName);
            Assert.Equal("ErrorCode cannot be null.", exception.Message);
        }
        
        #endregion
        
        #region Sucess

        [Fact]
        public void Constructor_Success_IfMessageValid()
        {
            var ex = new ConflictException("Unexpected conflict error");
            
            Assert.NotNull(ex);
            Assert.Null(ex.ErrorCode);
            Assert.Null(ex.InnerException);
            Assert.Equal("Unexpected conflict error", ex.Message);
        }

        [Fact]
        public void Constructor_Success_IfMessageAndErrorValid()
        {
            var ex = new ConflictException("Unexpected conflict error", "5000");
            
            Assert.NotNull(ex);
            Assert.Null(ex.InnerException);
            Assert.Equal("5000", ex.ErrorCode);
            Assert.Equal("5000 - Unexpected conflict error", ex.Message);
        }

        [Fact]
        public void Constructor_Success_IfMessageAndInnerExceptionValid()
        {
            var ex = new ConflictException("Unexpected conflict error", new Exception("Error Test"));
            
            Assert.NotNull(ex);
            Assert.NotNull(ex.InnerException);
            Assert.Null(ex.ErrorCode);
            Assert.Equal("Unexpected conflict error: Error Test", ex.Message);
        }

        [Fact]
        public void Constructor_Success_IfMessageErrorCodeAndInnerExceptionValid()
        {
            var ex = new ConflictException("Unexpected conflict error", "5000", new Exception("Error Test"));
            
            Assert.NotNull(ex);
            Assert.NotNull(ex.InnerException);
            Assert.Equal("5000", ex.ErrorCode);
            Assert.Equal("5000 - Unexpected conflict error: Error Test", ex.Message);
        }
        
        
        #endregion
    }
}