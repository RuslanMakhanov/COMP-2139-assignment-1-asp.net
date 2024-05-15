using Assignment.Models;
using Assignment.Services;
using Bogus;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controllers
{
    public class ProductManager : Controller
    {
        
        public IActionResult Index()
        {
            ProductsDAO products = new ProductsDAO();
            
            return View(products.GetallProducts());

        }
        
        public IActionResult ShowDetails(int id)
        {

            ProductsDAO products = new ProductsDAO();

            ProductModel foundproduct= products.GetProductById(id);
            return View(foundproduct);
        }
        public IActionResult Edit(int id)
        {

            ProductsDAO products = new ProductsDAO();
            ProductModel foundproduct = products.GetProductById(id);
            return View("ShowEdit",foundproduct);
        }
        public IActionResult ProcessEdit(ProductModel product)
        {

            ProductsDAO products = new ProductsDAO();
            products.Update(product);
            return View("Index", products.GetallProducts());
        }
        public IActionResult SearchResults(string searchterm)
        {
            ProductsDAO products = new ProductsDAO();
            List<ProductModel> productsList = products.SearchProducts(searchterm);

            return View("index", productsList);
        }
        public IActionResult Delete(int id)
        {

            ProductsDAO products = new ProductsDAO();
            ProductModel product = products.GetProductById(id);
            products.Delete(product);
            return View("Index", products.GetallProducts());
        }
        public IActionResult Searchform()
        {
            return View();
        }
        public IActionResult InputForm()
        {
            return View("InputForm");
        }
        public IActionResult ProcessCreate(ProductModel product)
        {

            ProductsDAO products = new ProductsDAO();
            products.Insert(product);
            return View("Index", products.GetallProducts());
        }


        
        public IActionResult Details(ProductModel product)
        {
            
            //products.Add(product);
            return View("Details", product);
        }
       
    }
}
