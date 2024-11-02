using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities;

public sealed class Product : Entity
{
    public string Name { get; private set; }
    
    public string Description { get; private set; }
    
    public decimal Price { get; private set; }
    
    public int Stock { get; private set; }
    
    public string Image { get; private set; }
    
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    
    public Product(string name, string description, decimal price, int stock, string image)
    {
        ValidateDomain(name, description, price, stock, image);
    }

    public Product(int id, string name, string description, decimal price, int stock, string image)
    {
        DomainExeptionValidation.When(id < 0, "Invalid category id");
        Id = id;
        ValidateDomain(name, description, price, stock, image);
    }
    
    public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
    {
        ValidateDomain(name, description, price, stock, image);
        CategoryId = categoryId;
    }

    private void ValidateDomain(string name, string description, decimal price, int stock, string image)
    {
        DomainExeptionValidation.When(string.IsNullOrEmpty(name), "Name is required.");
        
        DomainExeptionValidation.When(name.Length < 3, "Invalid name length, minimum 3 characters.");
        
        DomainExeptionValidation.When(string.IsNullOrEmpty(description), "Description is required.");
        
        DomainExeptionValidation.When(description.Length < 5, "Invalid name length, minimum 5 characters.");
        
        DomainExeptionValidation.When(price < 0, "Invalid price value");
        
        DomainExeptionValidation.When(stock < 0, "Invalid stock value");
        
        DomainExeptionValidation.When(image.Length > 250, "Invalid image, maximum 250 characters.");

        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        Image = image;
    }
    
}