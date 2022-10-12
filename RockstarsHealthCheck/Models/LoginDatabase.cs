using System.Data.SqlClient;
using System.Data;

namespace RockstarsHealthCheck.Models
{
    public class LoginDatabase
    {
        string connectionString = @"Server=tcp:rockstars.database.windows.net,1433;Initial Catalog=RockstarsDataBase;Persist Security Info=False;User ID=RockstarAdmin;Password=Rockstars!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public bool LogIn(string email, string password)
        {
            string queryString = "SELECT * FROM Admin WHERE Email = @Email AND Password = @Password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@Email", SqlDbType.VarChar);
                command.Parameters["@Email"].Value = email;
                command.Parameters.Add("@Password", SqlDbType.VarChar);
                command.Parameters["@Password"].Value = password;
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                return reader.HasRows;
            }
        }
    }
}
