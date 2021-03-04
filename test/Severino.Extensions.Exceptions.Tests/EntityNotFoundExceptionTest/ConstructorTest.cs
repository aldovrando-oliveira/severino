using System;
using Xunit;

namespace Severino.Extensions.Exceptions.Tests.EntityNotFoundExceptionTest
{
    public class ConstructorTest
    {
        
        #region Entity Validation
        
        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("  ")]
        public void Constructor_Throws_IfEntityInvalid(string entity)
        {
            var exception = Assert.Throws<ArgumentException>(() =>
                new EntityNotFoundException(entity));

            Assert.Null(exception.ParamName);
            Assert.Equal("Entity cannot be null.", exception.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("  ")]
        public void Constructor_Throws_IfEntityInvalidAndErrorCodeValid(string entity)
        {
            var exception = Assert.Throws<ArgumentException>(() =>
                new EntityNotFoundException(entity, "5000"));

            Assert.Null(exception.ParamName);
            Assert.Equal("Entity cannot be null.", exception.Message);
        }
        
        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("  ")]
        public void Constructor_Throws_IfEntityInvalidAndErrorCodeValidAndMessageValid(string entity)
        {
            var exception = Assert.Throws<ArgumentException>(() =>
                new EntityNotFoundException(entity, "5000", "Error message"));

            Assert.Null(exception.ParamName);
            Assert.Equal("Entity cannot be null.", exception.Message);
        }
        
        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("  ")]
        public void Constructor_Throws_IfEntityInvalidAndErrorCodeValidAndMessageValidAndInnerExceptionValid(string entity)
        {
            var exception = Assert.Throws<ArgumentException>(() =>
                new EntityNotFoundException(entity, "5000", "Error message", new Exception("Inner Message")));

            Assert.Null(exception.ParamName);
            Assert.Equal("Entity cannot be null.", exception.Message);
        }
        
        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("  ")]
        public void Constructor_Throws_IfEntityInvalidAndErrorCodeValidAndInnerExceptionValid(string entity)
        {
            var exception = Assert.Throws<ArgumentException>(() =>
                new EntityNotFoundException(entity, "5000", new Exception("Inner Message")));

            Assert.Null(exception.ParamName);
            Assert.Equal("Entity cannot be null.", exception.Message);
        }
        
        #endregion

        #region ErrorCode Validation
        
        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("  ")]
        public void Constructor_Throws_IfEntityValidAndErrorCodeInvalid(string errorCode)
        {
            var exception = Assert.Throws<ArgumentException>(() =>
                new EntityNotFoundException("Entity", errorCode));

            Assert.Null(exception.ParamName);
            Assert.Equal("ErrorCode cannot be null.", exception.Message);
        }
        
        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("  ")]
        public void Constructor_Throws_IfEntityValidAndErrorCodeInvalidAndMessageValid(string errorCode)
        {
            var exception = Assert.Throws<ArgumentException>(() =>
                new EntityNotFoundException("Entity", errorCode, "Error message"));

            Assert.Null(exception.ParamName);
            Assert.Equal("ErrorCode cannot be null.", exception.Message);
        }
        
        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("  ")]
        public void Constructor_Throws_IfEntityValidAndErrorCodeInvalidAndMessageValidAndInnerExceptionValid(string errorCode)
        {
            var exception = Assert.Throws<ArgumentException>(() =>
                new EntityNotFoundException( "Entity", errorCode, "Error message", new Exception("Inner Message")));

            Assert.Null(exception.ParamName);
            Assert.Equal("ErrorCode cannot be null.", exception.Message);
        }
        
        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("  ")]
        public void Constructor_Throws_IfEntityValidAndErrorCodeInvalidAndInnerExceptionValid(string errorCode)
        {
            var exception = Assert.Throws<ArgumentException>(() =>
                new EntityNotFoundException("Entity", errorCode, new Exception("Inner Message")));

            Assert.Null(exception.ParamName);
            Assert.Equal("ErrorCode cannot be null.", exception.Message);
        }
        
        #endregion

        #region Message Validation
        
        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("  ")]
        public void Constructor_Throws_IfEntityValidAndErrorCodeValidAndMessageInvalid(string message)
        {
            var exception = Assert.Throws<ArgumentException>(() =>
                new EntityNotFoundException("Entity", "5000", message));

            Assert.Null(exception.ParamName);
            Assert.Equal("Message cannot be null.", exception.Message);
        }
        
        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("  ")]
        public void Constructor_Throws_IfEntityValidAndErrorCodeValidAndMessageInvalidAndInnerExceptionValid(string message)
        {
            var exception = Assert.Throws<ArgumentException>(() =>
                new EntityNotFoundException("Entity", "5000", message, new Exception("Inner message")));

            Assert.Null(exception.ParamName);
            Assert.Equal("Message cannot be null.", exception.Message);
        }
        
        #endregion
        
        #region Success

        [Fact]
        public void Constructor_Success_IfEntityValid()
        {
            var ex = new EntityNotFoundException("Entity");
            
            Assert.NotNull(ex);
            Assert.NotNull(ex.Entity);
            Assert.Null(ex.ErrorCode);
            Assert.Null(ex.InnerException);
            Assert.Equal("Entity", ex.Entity);
            Assert.Equal("Entity not found", ex.Message);
        }

        [Fact]
        public void Constructor_Success_IfEntityAndErrorCodeValid()
        {
            var ex = new EntityNotFoundException("Entity", "5000");
            
            Assert.NotNull(ex);
            Assert.NotNull(ex.Entity);
            Assert.NotNull(ex.ErrorCode);
            Assert.Null(ex.InnerException);
            Assert.Equal("Entity", ex.Entity);
            Assert.Equal("5000", ex.ErrorCode);
            Assert.Equal("5000 - Entity not found", ex.Message);
        }

        [Fact]
        public void Constructor_Success_IfEntityAndErrorCodeAndMessageValid()
        {
            var ex = new EntityNotFoundException("Entity", "5000", "Product Not Found");
            
            Assert.NotNull(ex);
            Assert.NotNull(ex.Entity);
            Assert.NotNull(ex.ErrorCode);
            Assert.Null(ex.InnerException);
            Assert.Equal("Entity", ex.Entity);
            Assert.Equal("5000", ex.ErrorCode);
            Assert.Equal("5000 - Product Not Found", ex.Message);
        }
        
        [Fact]
        public void Constructor_Success_IfEntityAndErrorCodeAndInnerExceptionValid()
        {
            var ex = new EntityNotFoundException("Entity", "5000", new Exception("Inner Message"));
            
            Assert.NotNull(ex);
            Assert.NotNull(ex.Entity);
            Assert.NotNull(ex.ErrorCode);
            Assert.NotNull(ex.InnerException);
            Assert.Equal("Entity", ex.Entity);
            Assert.Equal("5000", ex.ErrorCode);
            Assert.Equal("5000 - Entity not found: Inner Message", ex.Message);
            Assert.IsType<Exception>(ex.InnerException);
            Assert.Equal("Inner Message", ex.InnerException.Message);
        }

        [Fact]
        public void Constructor_Success_IfEntityAndErrorCodeAndMessageAndInnerExceptionValid()
        {
            var ex = new EntityNotFoundException("Entity", "5000", "Message Exception", new Exception("Inner Message"));
            
            Assert.NotNull(ex);
            Assert.NotNull(ex.Entity);
            Assert.NotNull(ex.ErrorCode);
            Assert.NotNull(ex.InnerException);
            Assert.Equal("Entity", ex.Entity);
            Assert.Equal("5000", ex.ErrorCode);
            Assert.Equal("5000 - Message Exception: Inner Message", ex.Message);
            Assert.IsType<Exception>(ex.InnerException);
            Assert.Equal("Inner Message", ex.InnerException.Message);
        }

        [Fact]
        public void Constructor_Success_IfEntityAndInnerExceptionValid()
        {
            var ex = new EntityNotFoundException("Entity", new Exception("Inner Message"));
            
            Assert.NotNull(ex);
            Assert.NotNull(ex.Entity);
            Assert.Null(ex.ErrorCode);
            Assert.NotNull(ex.InnerException);
            Assert.Equal("Entity", ex.Entity);
            Assert.Equal("Entity not found: Inner Message", ex.Message);
            Assert.IsType<Exception>(ex.InnerException);
            Assert.Equal("Inner Message", ex.InnerException.Message);
        }

        #endregion
    }
}