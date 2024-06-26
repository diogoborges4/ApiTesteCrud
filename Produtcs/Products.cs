using ApiTesteCrud.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiTesteCrud.Products;

public static class Products
{
    public static void AddProducts(WebApplication app)
    {
        var rotasProducts = app.MapGroup(prefix: "products");

        rotasProducts.MapPost("", handler: async (AddProductsRequest request, AppDBContext context) =>
        {
            var newProduct = new ProductsModel(request.Name, request.Description);
            await context.Products.AddAsync(newProduct);
            await context.SaveChangesAsync();
        });

        rotasProducts.MapGet("", handler: async (AppDBContext context) =>
        {
            var listProducts = await context.Products.ToListAsync();
            return listProducts;
        });

        rotasProducts.MapPut(pattern: "{id}", handler: async (Guid id, UpdateProductsRequest request, AppDBContext context) =>
        {
            var product = await context.Products.SingleOrDefaultAsync(product => product.Id == id);

            if (product == null)
            {
                return Results.NotFound();
            }
            product.UpdateProduct(request.Name, request.Description);
            await context.SaveChangesAsync();
            return Results.Ok(product);
        });

        rotasProducts.MapDelete(pattern: "{id}", handler: async (Guid id, AppDBContext context) =>
        {
            var product = await context.Products.SingleOrDefaultAsync(product => product.Id == id);

            if (product == null)
            {
                return Results.NotFound();
            }
            context.Products.Remove(product);

            await context.SaveChangesAsync();
            return Results.Ok(product);
        });
    }
}