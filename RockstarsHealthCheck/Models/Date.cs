using Microsoft.AspNetCore.Hosting.Server;
using System.Data.SqlClient;

namespace RockstarsHealthCheck.Models
{
    public class Date
    {
        private string LatestDateTime;

        public string latestDateTime { get { return LatestDateTime; } }
        public DateTime checkpoint { get; set; }


        public void DateTimeDataBase()
        {
            var connectionString = @"Server=tcp:rockstars-health-check-server.database.windows.net,1433;Initial Catalog=rockstars-health-check-database;Persist Security Info=False;User ID=rockstars-health-check-server-admin@rockstars-health-check-server.database.windows.net;Password=6BQX5BZ0UN07G2V6$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            using var connection = new SqlConnection(connectionString);

            connection.Open();

            var command = new SqlCommand("INSERT INTO TestTable(DateTime) VALUES( '" + checkpoint + " ' )", connection);
            var reader = command.ExecuteReader();

            connection.Close();
        }

        public void GetLatestDate()
        {
            var connectionString = @"Server=tcp:rockstars-health-check-server.database.windows.net,1433;Initial Catalog=rockstars-health-check-database;Persist Security Info=False;User ID=rockstars-health-check-server-admin@rockstars-health-check-server.database.windows.net;Password=6BQX5BZ0UN07G2V6$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            using var connection = new SqlConnection(connectionString);

            connection.Open();

            var command = new SqlCommand(" SELECT TOP 1 * FROM[dbo].[TestTable] ORDER BY[DateID] DESC", connection);
            var reader = command.ExecuteReader();

            if(reader.Read())
            {
                LatestDateTime = reader.GetString(0);
            }

            connection.Close();

        }
    }
}
