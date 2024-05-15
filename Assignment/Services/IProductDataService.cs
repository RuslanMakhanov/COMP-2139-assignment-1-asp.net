using Assignment.Models;

namespace Assignment.Services
{
    public interface IProductDataService
    {
        List<ProductModel> GetallProducts();
        List<ProductModel> SearchProducts(string searchTerm);
        ProductModel GetProductById(int Id);
        int Insert(ProductModel product);
        int Delete(ProductModel product);
        int Update(ProductModel product);


    }
}
