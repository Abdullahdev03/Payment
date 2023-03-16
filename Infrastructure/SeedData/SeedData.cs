using Domain.Entities;
using Infrastructure.Data;
namespace Infrastructure.SeedData;

public static  class SeedData
{
    public static async Task Seed(DataContext context)
    {
        if(context.Categories.Any())return;
        var category = new List<Category>()
        {
            new Category(1, "Смартфон"),
            new Category(2, "Компьютер"),
            new Category(3, "Телевизор")
        };
        context.Categories.AddRange(category);
        await context.SaveChangesAsync();
        
        if(context.Products.Any())return;
        var product = new List<Product>()
        {
            new Product(1,"Samsung Galaxy Note 20",3500,1),
            new Product(2,"IPhone 14 Pro Golden",16000,1),
            new Product(3,"MacBook Air 13 2022",23250,2),
            new Product(4,"Hp ProBook",10599,2),
            new Product(5,"TV Samsung",1500,3),
            new Product(6,"TV LG LED",1999,3),
        };
        context.Products.AddRange(product);
        await context.SaveChangesAsync();
    }
}