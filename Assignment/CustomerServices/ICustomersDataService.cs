using Assignment.Models;

namespace Assignment.CustomerServices
{
    public interface ICustomersDataService
    {
        List<CustomerModel> GetallCustomers();
        List<CustomerModel> SearchCustomers(string searchTerm);
        CustomerModel GetCustomersById(int Id);
        int Insert(CustomerModel product);
        int Delete(CustomerModel product);
        int Update(CustomerModel product);
    }
}
