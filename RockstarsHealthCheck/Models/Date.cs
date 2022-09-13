using Microsoft.AspNetCore.Hosting.Server;
using System.Data.SqlClient;

namespace RockstarsHealthCheck.Models
{
    public class Date
    {
        public DateTime checkpoint { get; set; }


        public void DateTime(DateTime date)
        {
            var connectionString = @"Server=tcp:rockstars-health-check-server.database.windows.net,1433;Initial Catalog=rockstars-health-check-database;Persist Security Info=False;User ID=rockstars-health-check-server-admin@rockstars-health-check-server.database.windows.net;Password=6BQX5BZ0UN07G2V6$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            using var connection = new SqlConnection(connectionString);

            connection.Open();

            var command = new SqlCommand("INSERT INTO TestTable(DateTime) VALUES( 'testtest' )", connection);
            var reader = command.ExecuteReader();

            connection.Close();
        }
    }
}
