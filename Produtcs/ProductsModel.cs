namespace ApiTesteCrud.Products;

public class ProductsModel
{
    public Guid Id { get; init; }
    public string Name { get; private set; }
    public string Description { get; private set; }

    public ProductsModel(string name, string description)
    {
        Name = name;
        Description = description;
        Id = Guid.NewGuid();
    }

    public void UpdateProduct(string name, string description)
    {
        Name = name;
        Description = description;
    }
}