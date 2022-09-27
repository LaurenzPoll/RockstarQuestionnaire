using System.Data.SqlClient;

namespace RockstarsHealthCheck.Models
{
    public class Questions
    {
        private string connectionString = @"Server=tcp:rockstars.database.windows.net,1433;Initial Catalog=RockstarsDataBase;Persist Security Info=False;User ID=RockstarAdmin;Password=Rockstars!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public List<Question> list = new List<Question>();

        public Questions()
        {
            using var connection = new SqlConnection(connectionString);

            connection.Open();

            var command = new SqlCommand(" SELECT * FROM Questions", connection);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new Question(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2)));
            }

            connection.Close();
        }
    }
}
