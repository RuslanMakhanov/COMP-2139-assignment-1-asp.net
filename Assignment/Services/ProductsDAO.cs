using Assignment.Models;
using System.Data.SqlClient;

namespace Assignment.Services
{
    public class ProductsDAO : IProductDataService
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Assignment;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public int Delete(ProductModel product)
        {
            int newIdNumber = -1;
            string sqlStatement = "DELETE FROM dbo.Products WHERE id LIKE @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                
                command.Parameters.AddWithValue("@id", product.Id);
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

        public List<ProductModel> GetallProducts()
        {
            List<ProductModel> foundproducts = new List<ProductModel>();
            string sqlStatement = "SELECT * FROM dbo.Products";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foundproducts.Add(new ProductModel
                        {
                            Id = (int)reader[0],
                            Code = (string)reader[1],
                            Name = (string)reader[2],
                            Price = (decimal)reader[3],
                            ReleaseDate = (DateTime)reader[4]
                        });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }
            return foundproducts;
        }

        public ProductModel GetProductById(int id)
        {
            ProductModel foundproduct = null;
            string sqlStatement = "SELECT * FROM dbo.Products WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Id", id);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foundproduct =new ProductModel
                        {
                            Id = (int)reader[0],
                            Code = (string)reader[1],
                            Name = (string)reader[2],
                            Price = (decimal)reader[3],
                            ReleaseDate = (DateTime)reader[4]
                        };
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return foundproduct;
        }

        public int Insert(ProductModel product)
        {
            int newIdNumber = +1;
            string sqlStatement ="INSERT INTO dbo.Products VALUES (@Code,@Name,@Price,@ReleaseDate)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Code", product.Code);
                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@ReleaseDate", product.ReleaseDate);
                //command.Parameters.AddWithValue("@id", product.Id);
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

        public List<ProductModel> SearchProducts(string searchTerm)
        {
            List<ProductModel> foundproducts = new List<ProductModel>();
            string sqlStatement = "SELECT * FROM dbo.Products WHERE Name LIKE @Name";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Name", '%' +searchTerm + '%');
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foundproducts.Add(new ProductModel
                        {
                            Id = (int)reader[0],
                            Code = (string)reader[1],
                            Name = (string)reader[2],
                            Price = (decimal)reader[3],
                            ReleaseDate = (DateTime)reader[4]
                        });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }
            return foundproducts;
        }

        public int Update(ProductModel product)
        {
            int newIdNumber = -1;
            string sqlStatement = "UPDATE dbo.Products Set Code = @Code, Name = @Name,Price = @Price, ReleaseDate=@ReleaseDate WHERE id LIKE @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Code", product.Code);
                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@ReleaseDate", product.ReleaseDate);
                command.Parameters.AddWithValue("@id", product.Id);
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
