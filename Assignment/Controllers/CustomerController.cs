using Assignment.CustomersServices;
using Assignment.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            CustomersDAO customers = new CustomersDAO();
            return View(customers.GetallCustomers());

        }
        public IActionResult ShowDetails(int id)
        {

            CustomersDAO customer = new CustomersDAO();

            CustomerModel foundcustomer = customer.GetCustomersById(id);
            return View(foundcustomer);
        }
        public IActionResult Edit(int id)
        {

            CustomersDAO customer = new CustomersDAO();
            CustomerModel foundcustomers = customer.GetCustomersById(id);
            return View("Edit", foundcustomers);
        }
        public IActionResult ProcessEdit(CustomerModel customer)
        {

            CustomersDAO customers = new CustomersDAO();
            customers.Update(customer);
            return View("Index", customers.GetallCustomers());
        }
        public IActionResult SearchResult(string searchTerm)
        {
            CustomersDAO customers = new CustomersDAO();
            List<CustomerModel> customersList = customers.SearchCustomers(searchTerm);
            return View("index", customersList);
        }
        public IActionResult SearchForm()
        {
            return View();
        }
        public IActionResult Delete(int id)
        {

            CustomersDAO customers = new CustomersDAO();
            CustomerModel customer = customers.GetCustomersById(id);
            customers.Delete(customer);
            return View("Index", customers.GetallCustomers());
        }
        public IActionResult InputForm()
        {
            return View("InputForm");
        }
        public IActionResult ProcessCreate(CustomerModel customer)
        {

            CustomersDAO customers = new CustomersDAO();
            customers.Insert(customer);
            return View("Index", customers.GetallCustomers());
        }

    }
}
