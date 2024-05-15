using Assignment.Models;
using System.Data.SqlClient;

namespace Assignment.TechiciansServices
{
    public class TechiciansDAO : ITechiciansDataService
    {
        string connectionstring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Assignment;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public int Delete(TechniciansModel technician)
        {
            int newIdNumber = -1;
            string sqlStatement = "DELETE FROM dbo.Techicians WHERE id LIKE @id";
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.AddWithValue("@id", technician.id);
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

        public List<TechniciansModel> GetallTechicians()
        {
            List<TechniciansModel> foundTechnician = new List<TechniciansModel> ();
            string sqlStatement = "SELECT * FROM dbo.Techicians";
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    foundTechnician.Add(new TechniciansModel
                    {
                        id = (int)reader[0],
                        Name = (string)reader[1],
                        Email = (string)reader[2],
                        Phone = (string)reader[3]

                    });
                }
            }
            return foundTechnician;

            
        }

        public TechniciansModel GetTechiciansById(int id)
        {
            TechniciansModel foundtechnician = null;
            string sqlStatement = "SELECT * FROM dbo.Techicians WHERE Id = @Id";
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
                        foundtechnician = new TechniciansModel
                        {
                            id = (int)reader[0],
                            Name = (string)reader[1],
                            Email = (string)reader[2],
                            Phone = (string)reader[3]
                        };
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return foundtechnician;
        }

        public int Insert(TechniciansModel technician)
        {
            int newIdNumber = +1;
            string sqlStatement = "INSERT INTO dbo.Techicians VALUES (@id,@Name,@Email,@Phone)";
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Name", technician.Name);
                command.Parameters.AddWithValue("@Email", technician.Email);
                command.Parameters.AddWithValue("@Phone", technician.Phone);
                
                command.Parameters.AddWithValue("@id", technician.id);
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

        public List<TechniciansModel> SearchTechicians(string searchTerm)
        {
            List<TechniciansModel> foundtehcnicians = new List<TechniciansModel>();
            string sqlStatement = "SELECT * FROM dbo.Techicians WHERE Name LIKE @Name";
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Name", '%' + searchTerm + '%');
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foundtehcnicians.Add(new TechniciansModel
                        {
                            id = (int)reader[0],
                            Name = (string)reader[1],
                            Email = (string)reader[2],
                            Phone = (string)reader[3]
                        });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return foundtehcnicians;
        }

        public int Update(TechniciansModel technician)
        {
            int newIdNumber = -1;
            string sqlStatement = "UPDATE dbo.Techicians Set Name = @Name,Email = @Email, Phone=@Phone WHERE id LIKE @id";
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Name", technician.Name);
                command.Parameters.AddWithValue("@Email", technician.Email);
                command.Parameters.AddWithValue("@Phone", technician.Phone);

                command.Parameters.AddWithValue("@id", technician.id);
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
