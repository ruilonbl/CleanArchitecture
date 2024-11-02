using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities;

public sealed class Category : Entity
{
    public string Name { get; private set; }

    public ICollection<Product> Products { get; set; }
    
    public Category(string name)
    {
        ValidateDomain(name);
    }

    public Category(int id, string name)
    {
        DomainExeptionValidation.When(id < 0, "Invalid category id");
        Id = id;
        ValidateDomain(name);
    }

    public void Update(string name)
    {
        ValidateDomain(name);
    }
    
    private void ValidateDomain(string name)
    {
        DomainExeptionValidation.When(string.IsNullOrEmpty(name), "Name is required.");
        
        DomainExeptionValidation.When(name.Length < 3, "Invalid name length, minimum 3 characters.");
        
        Name = name;
    }
}