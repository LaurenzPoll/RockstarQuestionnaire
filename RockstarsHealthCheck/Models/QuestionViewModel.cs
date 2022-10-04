using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace RockstarsHealthCheck.Models
{
    public class QuestionViewModel
    {
        private readonly string connectionString = @"Server=tcp:rockstars.database.windows.net,1433;Initial Catalog=RockstarsDataBase;Persist Security Info=False;User ID=RockstarAdmin;Password=Rockstars!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public string? Email { get; set; }
        [BindProperty] public List<Question> Questions { get; set; }

        public QuestionViewModel()
        {
            Questions = new List<Question>();
            using var connection = new SqlConnection(connectionString);

            connection.Open();

            var command = new SqlCommand(" SELECT * FROM Questions", connection);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Questions.Add(new Question(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2)));
            }
            connection.Close();
        }

        public void OnGet()
        {
            Questions = new List<Question>();
            using var connection = new SqlConnection(connectionString);

            connection.Open();

            var command = new SqlCommand(" SELECT * FROM Questions", connection);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Questions.Add(new Question(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2)));
            }
            connection.Close();
        }

        public void OnPost(List<Question> questions)
        {

        }
    }
}
