using System;
using Xunit;

namespace Severino.Extensions.Exceptions.Tests.ExtensionsTest
{
    public class EntityNotFoundExceptionExtensionTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("  ")]
        public void ToEntityNotFoundException_Throw_IfEntityInvalid(string entity)
        {
            var baseException = new Exception("Unexpected Error");

            var exception = Assert.Throws<ArgumentException>(() => 
                baseException.ToEntityNotFoundException(entity));
            
            Assert.Null(exception.ParamName);
            Assert.Equal("Entity cannot be null.", exception.Message);
        }
        
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("  ")]
        public void ToEntityNotFoundException_Throw_IfEntityInvalidAndErrorCodeValid(string entity)
        {
            var baseException = new Exception("Unexpected Error");

            var exception = Assert.Throws<ArgumentException>(() => 
                baseException.ToEntityNotFoundException(entity, "ABC500"));
            
            Assert.Null(exception.ParamName);
            Assert.Equal("Entity cannot be null.", exception.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("  ")]
        public void ToEntityNotFoundException_Throw_IfEntityInvalidAndErrorCodeValidAndMessageValid(string entity)
        {
            var baseException = new Exception("Unexpected Error");

            var exception = Assert.Throws<ArgumentException>(() => 
                baseException.ToEntityNotFoundException(entity, "ABC500", "Error Message"));
            
            Assert.Null(exception.ParamName);
            Assert.Equal("Entity cannot be null.", exception.Message);
        }
        
        
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("  ")]
        public void ToEntityNotFoundException_Throw_IfEntityValidAndErrorCodeInvalid(string errorCode)
        {
            var baseException = new Exception("Unexpected Error");

            var exception = Assert.Throws<ArgumentException>(() => 
                baseException.ToEntityNotFoundException("Entity", errorCode));
            
            Assert.Null(exception.ParamName);
            Assert.Equal("ErrorCode cannot be null.", exception.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("  ")]
        public void ToEntityNotFoundException_Throw_IfEntityValidAndErrorCodeInvalidAndMessageValid(string errorCode)
        {
            var baseException = new Exception("Unexpected Error");

            var exception = Assert.Throws<ArgumentException>(() =>
                baseException.ToEntityNotFoundException("Entity", errorCode, "Error Message"));
            
            Assert.Null(exception.ParamName);
            Assert.Equal("ErrorCode cannot be null.", exception.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("  ")]
        public void ToEntityNotFoundException_Throw_IfEntityValidAndErrorCodeValidAndMessageInvalid(string message)
        {
            var baseException = new Exception("Unexpected Error");

            var exception = Assert.Throws<ArgumentException>(() =>
                baseException.ToEntityNotFoundException("Entity", "ABC500", message));
            
            Assert.Null(exception.ParamName);
            Assert.Equal("Message cannot be null.", exception.Message);
        }

        [Fact]
        public void ToEntityNotFoundException_Success_IfEntityValid()
        {
            var baseException = new Exception("Unexpected Error");

            var ex = baseException.ToEntityNotFoundException("Entity");

            Assert.NotNull(ex);
            Assert.IsType<EntityNotFoundException>(ex);
            Assert.NotNull(ex.Entity);
            Assert.Null(ex.ErrorCode);
            Assert.NotNull(ex.InnerException);
            Assert.Equal("Unexpected Error", ex.InnerException.Message);
            Assert.Equal("Entity", ex.Entity);
            Assert.Equal("Entity not found: Unexpected Error", ex.Message);
        }

        [Fact]
        public void ToEntityNotFoundException_Success_IfEntityValidAndErrorCodeValid()
        {
            var baseException = new Exception("Unexpected Error");

            var ex = baseException.ToEntityNotFoundException("Entity", "ABC500");

            Assert.NotNull(ex);
            Assert.IsType<EntityNotFoundException>(ex);
            Assert.NotNull(ex.Entity);
            Assert.NotNull(ex.ErrorCode);
            Assert.NotNull(ex.InnerException);
            Assert.Equal("Unexpected Error", ex.InnerException.Message);
            Assert.Equal("Entity", ex.Entity);
            Assert.Equal("ABC500", ex.ErrorCode);
            Assert.Equal("ABC500 - Entity not found: Unexpected Error", ex.Message);
        }

        
        [Fact]
        public void ToEntityNotFoundException_Success_IfEntityValidAndErrorCodeValidAndMessageValid()
        {
            var baseException = new Exception("Unexpected Error");

            var ex = baseException.ToEntityNotFoundException("Entity", "ABC500", "Error message");

            Assert.NotNull(ex);
            Assert.IsType<EntityNotFoundException>(ex);
            Assert.NotNull(ex.Entity);
            Assert.NotNull(ex.ErrorCode);
            Assert.NotNull(ex.InnerException);
            Assert.Equal("Unexpected Error", ex.InnerException.Message);
            Assert.Equal("Entity", ex.Entity);
            Assert.Equal("ABC500", ex.ErrorCode);
            Assert.Equal("ABC500 - Error message: Unexpected Error", ex.Message);
        }
    }
}