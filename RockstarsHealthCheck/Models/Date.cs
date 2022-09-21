using Microsoft.AspNetCore.Hosting.Server;
using System.Data.SqlClient;

namespace RockstarsHealthCheck.Models
{
    public class Date
    {
        private string LatestDateTime;

        public string latestDateTime { get { return LatestDateTime; } }
        public DateTime checkpoint { get; set; }

        string connectionString = @"Server=tcp:rockstars.database.windows.net,1433;Initial Catalog=RockstarsDataBase;Persist Security Info=False;User ID=RockstarAdmin;Password=Rockstars!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public void DateTimeDataBase()
        {
            using var connection = new SqlConnection(connectionString);

            connection.Open();

            var command = new SqlCommand("INSERT INTO HelloWorld(DateTime) VALUES( '" + checkpoint.ToString() + " ' )", connection);
            var reader = command.ExecuteReader();

            connection.Close();
        }

        public void GetLatestDate()
        {
            using var connection = new SqlConnection(connectionString);

            connection.Open();

            var command = new SqlCommand(" SELECT TOP 1 * FROM HelloWorld ORDER BY[DateID] DESC", connection);
            var reader = command.ExecuteReader();

            if (reader.Read())
            {
                LatestDateTime = reader.GetString(1);
            }

            connection.Close();

        }
    }
}
