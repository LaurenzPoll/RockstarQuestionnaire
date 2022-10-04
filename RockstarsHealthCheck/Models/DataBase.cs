using System.Collections.Generic;
using System.Data.SqlClient;

namespace RockstarsHealthCheck.Models
{
    public class DataBase
    {
        private string connectionString = @"Server=tcp:rockstars.database.windows.net,1433;Initial 
                                    Catalog=RockstarsDataBase;Persist Security Info=False;
                                    User ID=RockstarAdmin;Password=Rockstars!;MultipleActiveResultSets=False;
                                    Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        private int userID;

        /*
        public void AddCompleteQuestionnaireToDateBase()
        {
            using var connection = new SqlConnection(connectionString);

            connection.Open();
            //foreach(Question question in QuestionList)
            //{
            var command = new SqlCommand("INSERT INTO Answers(UserID, QuestionID, AnswerRange) VALUES( '" + checkpoint.ToString() + " ' )", connection);
            var reader = command.ExecuteReader();
            //}

            connection.Close();
        }
        */

        public int GetUserIDFromDataBase(string email)
        {
            using var connection = new SqlConnection(connectionString);

            connection.Open();

            var command = new SqlCommand("IF not exists(SELECT * FROM users WHERE Email = '" + email + "')" +
                                         "BEGIN" +
                                         "INSERT INTO Users(Email) VALUES('" + email + "')"+
                                         "END" +
                                         "SELECT * FROM users WHERE Email = '" + email + "'", connection);

            var reader = command.ExecuteReader();

            if(reader.Read())
            {
                userID = reader.GetInt32(0);
            }

            connection.Close();

            return userID;
        }


    }
}
