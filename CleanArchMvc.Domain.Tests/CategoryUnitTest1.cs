using CleanArchMvc.Domain.Entities;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1,"Category Name");
            action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainExeptionValidation>();
        }
        
        [Fact]
        public void CreateCategory_NegativeIdValue_DomainExeptionInvalidId()
        {
            Action action = () => new Category(-1,"Category Name");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExeptionValidation>().WithMessage("Invalid category id");
        }
    }
}