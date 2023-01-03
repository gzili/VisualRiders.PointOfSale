using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project;

public static class DbSeeder
{
    public static void Seed(PointOfSaleContext context)
    {
        if (context.BusinessEntities.Find(1) != null)
        {
            return;
        }

        var defaultBusiness = new BusinessEntity
        {
            Name = "Default Business",
            Code = "0000",
            Description = "This is the default business that cannot be deleted.",
            Address = "Default street 1, Default city, Default country"
        };

        context.Add(defaultBusiness);

        var individualTax = new Tax
        {
            BusinessEntity = defaultBusiness,
            Name = "20% Tax",
            Description = "20% tax that can be applied to individual products or services.",
            Percentage = 0.2m,
            Type = TaxType.Individual
        };

        var categoricalTax = new Tax
        {
            BusinessEntity = defaultBusiness,
            Name = "10% tax",
            Description = "10% tax that can be applied to categories.",
            Percentage = 0.1m,
            Type = TaxType.Categorical
        };

        context.AddRange(individualTax, categoricalTax);

        var basicCategory = new Category
        {
            BusinessEntity = defaultBusiness,
            Name = "Basic"
        };

        var taxedCategory = new Category
        {
            BusinessEntity = defaultBusiness,
            Name = "Taxed",
            Tax = categoricalTax
        };

        var product1 = new Product
        {
            BusinessEntity = defaultBusiness,
            Available = true,
            Category = basicCategory,
            Cost = 5.99m,
            Description = "This is a product without tax.",
            MeasUnit = "kg",
            Returnable = false,
            Name = "Product 1"
        };

        var product2 = new Product
        {
            BusinessEntity = defaultBusiness,
            Available = true,
            Category = basicCategory,
            Cost = 10.99m,
            Description = "This is a product with individual tax.",
            MeasUnit = "pcs",
            Name = "Product 2",
            Returnable = true,
            Tax = individualTax
        };

        var product3 = new Product
        {
            BusinessEntity = defaultBusiness,
            Available = true,
            Category = taxedCategory,
            Cost = 20.99m,
            Description = "This is a product with category tax.",
            MeasUnit = "pcs",
            Name = "Product 3",
            Returnable = true
        };
        
        context.AddRange(product1, product2, product3);

        var service1 = new Service
        {
            BusinessEntity = defaultBusiness,
            Name = "Service 1",
            Cost = 25.99m,
            Available = true,
            Description = "This is a service.",
            Category = basicCategory,
            Duration = 0.3
        };

        context.Add(service1);

        var sampleDiscount = new Discount
        {
            BusinessEntity = defaultBusiness,
            Name = "Sample discount",
            Description = "This is a sample discount that is applied to Product 2 by default.",
            Code = "SAMPLE"
        };

        context.Add(sampleDiscount);

        var sampleDiscountItem = new DiscountItem
        {
            Discount = sampleDiscount,
            Product = product2,
            DiscountSize = 0.1m
        };

        context.Add(sampleDiscountItem);

        context.SaveChanges();
    }
}