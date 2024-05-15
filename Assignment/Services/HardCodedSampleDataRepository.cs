using Assignment.Models;
using Bogus;

namespace Assignment.Services
{
    public class HardCodedSampleDataRepository : IProductDataService

    {
        static List<ProductModel> products = new List<ProductModel>();

        public int Delete(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public List<ProductModel> GetallProducts()
        {
            if(products.Count ==0) { 
            products.Add(new ProductModel { Code = "Code132", Name = "Product Name", Price = 400, ReleaseDate = new DateTime(2022, 1, 17) });

            for (int i = 0; i < 20; i++)
            {
                products.Add(new Faker<ProductModel>()
                    .RuleFor(p => p.Code, f => f.Commerce.Ean8())
                    .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                    .RuleFor(p => p.Price, f => f.Random.Decimal(100))
                    .RuleFor(p => p.ReleaseDate, f => f.Date.Recent(0))
                    );
            }
            }
            return products;
        }

        public ProductModel GetProductById(int Id)
        {
            throw new NotImplementedException();
        }

        public int Insert(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public List<ProductModel> SearchProducts(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public int Update(ProductModel product)
        {
            throw new NotImplementedException();
        }
    }
}
