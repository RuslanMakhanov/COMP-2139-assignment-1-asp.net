using Assignment.CustomerServices;
using Assignment.Models;
using System.Data.SqlClient;

namespace Assignment.CustomersServices
{
    public class CustomersDAO : ICustomersDataService
    {
        string connectionstring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Assignment;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public int Delete(CustomerModel customer)
        {
            int newIdNumber = -1;
            string sqlStatement = "DELETE FROM dbo.Customers WHERE id LIKE @id";
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.AddWithValue("@id", customer.id);
                try
                {
                    connection.Open();
                    newIdNumber = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return newIdNumber;
        }

        public List<CustomerModel> GetallCustomers()
        {
            List<CustomerModel> foundCustomer = new List<CustomerModel> ();
            string sqlStatement = "SELECT * FROM dbo.Customers";
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                try { 
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    foundCustomer.Add(new CustomerModel
                    {

                        id = (int)reader[0],
                        fName = (string)reader[1],
                        lName = (string)reader[2],
                        Address = (string)reader[3],
                        City = (string)reader[4],
                        State = (string)reader[5],
                        PostalCode = (string)reader[6],
                        Country = (string)reader[7],
                        Email = (string)reader[8],
                        Phone = (string)reader[9]

                    });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return foundCustomer;

            
        }

        public CustomerModel GetCustomersById(int id)
        {
            CustomerModel foundCustomer = null;
            string sqlStatement = "SELECT * FROM dbo.Customers WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Id", id);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foundCustomer = new CustomerModel
                        {
                            id = (int)reader[0],
                            fName = (string)reader[1],
                            lName = (string)reader[2],
                            Address = (string)reader[3],
                            City = (string)reader[4],
                            State = (string)reader[5],
                            PostalCode = (string)reader[6],
                            Country = (string)reader[7],
                            Email = (string)reader[8],
                            Phone = (string)reader[9]

                        };
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return foundCustomer;
        }

        public int Insert(CustomerModel customer)
        {
            int newIdNumber = +1;
            string sqlStatement = "INSERT INTO dbo.Customers VALUES (@First_Name,@Last_Name,@Address,@City,@State,@Postal_Code,@Country,@Email,@Phone)";
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@First_Name", customer.fName);
                command.Parameters.AddWithValue("@Last_Name", customer.lName);
                command.Parameters.AddWithValue("@Address", customer.Address);
                command.Parameters.AddWithValue("@City", customer.City);
                command.Parameters.AddWithValue("@State", customer.State);
                command.Parameters.AddWithValue("@Postal_Code", customer.PostalCode);
                command.Parameters.AddWithValue("@Country", customer.Country);
                command.Parameters.AddWithValue("@Email", customer.Email);
                command.Parameters.AddWithValue("@Phone", customer.Phone);
                


                try
                {
                    connection.Open();
                    newIdNumber = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return newIdNumber;
        }

        public List<CustomerModel> SearchCustomers(string searchTerm)
        {
            List<CustomerModel> foundcustomer = new List<CustomerModel>();
            string sqlStatement = "SELECT * FROM dbo.Customers WHERE First_Name LIKE @First_Name";
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@First_Name", '%' + searchTerm + '%');
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foundcustomer.Add(new CustomerModel
                        {

                            id = (int)reader[0],
                            fName = (string)reader[1],
                            lName = (string)reader[2],
                            Address = (string)reader[3],
                            City = (string)reader[4],
                            State = (string)reader[5],
                            PostalCode = (string)reader[6],
                            Country = (string)reader[7],
                            Email = (string)reader[8],
                            Phone = (string)reader[9]

                        });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return foundcustomer;
        }

        public int Update(CustomerModel customer)
        {
            int newIdNumber = -1;
            string sqlStatement = "UPDATE dbo.Customers Set First_Name = @First_Name, Last_Name = @Last_Name, Address=@Address, City = @City, State = @State, Postal_Code = @Postal_Code, Country = @Country, Email = @Email, Phone = @Phone WHERE id LIKE @id";
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@First_Name", customer.fName);
                command.Parameters.AddWithValue("@Last_Name", customer.lName);
                command.Parameters.AddWithValue("@Address", customer.Address);
                command.Parameters.AddWithValue("@City", customer.City);
                command.Parameters.AddWithValue("@State", customer.State);
                command.Parameters.AddWithValue("@Postal_Code", customer.PostalCode);
                command.Parameters.AddWithValue("@Country", customer.Country);
                command.Parameters.AddWithValue("@Email", customer.Email);
                command.Parameters.AddWithValue("@Phone", customer.Phone);
                command.Parameters.AddWithValue("@id", customer.id);


                try
                {
                    connection.Open();
                    newIdNumber = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return newIdNumber;
        }
    }
}
