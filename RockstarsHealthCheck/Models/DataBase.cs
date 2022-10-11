using System.Collections.Generic;
using System.Data.SqlClient;

namespace RockstarsHealthCheck.Models
{
    public class DataBase
    {
        private string ConnectionString = @"Server=tcp:rockstars.database.windows.net,1433;Initial Catalog=RockstarsDataBase;Persist Security Info=False;User ID=RockstarAdmin;Password=Rockstars!;MultipleActiveResultSets=False; Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private int userID;

        public void SendAnswersToDataBase(QuestionViewModel viewModel)
        {
            int userID = GetUserIDFromDataBase(viewModel.Email);

            using var connection = new SqlConnection(ConnectionString);

            foreach (Question question in viewModel.Questions)
            {
                connection.Open();
                var command = new SqlCommand(" insert into Answers" +
                    "\nvalues " +
                    "\n(" +
                    userID + " ," +
                    question.Id + " ,'" +
                    question.AnswerString + "' ," +
                    question.Answer +
                    " )", connection);

                command.ExecuteReader();
                connection.Close();
            }
        }

        public void SendAnswersToDataBase(QuestionViewModel viewModel, string table)
        {
            int userID = GetUserIDFromDataBase(viewModel.Email);

            using var connection = new SqlConnection(ConnectionString);

            foreach (Question question in viewModel.Questions)
            {
                connection.Open();
                var command = new SqlCommand(" insert into + " + table + " " +
                    "values " +
                    "(" +
                    userID + " ," +
                    question.Id + " ,'" +
                    question.AnswerString + "' ," +
                    question.Answer +
                    " )", connection);

                command.ExecuteReader();
                connection.Close();
            }
        }

        public void AddQuestionToDataBase(int QuestionnaireId, string Question)
        {
            using var connection = new SqlConnection(ConnectionString);

            connection.Open();

            var command = new SqlCommand("INSERT INTO Questions(questionnaireID, question) VALUES (" + QuestionnaireId + " , '" + Question + "' )", connection);

            command.ExecuteReader();

            connection.Close();
        }

        public void AddQuestionToDataBase(int QuestionnaireId, string Question, string Table)
        {
            using var connection = new SqlConnection(ConnectionString);

            connection.Open();

            var command = new SqlCommand("INSERT INTO " + Table + "(questionnaireID, question) VALUES (" + QuestionnaireId + " , '" + Question +"' )",connection);

            command.ExecuteReader();

            connection.Close();
        }

        public void DeleteEverythingFromTable(string table)
        {
            using var connection = new SqlConnection(ConnectionString);

            connection.Open();

            var command = new SqlCommand("DELETE FROM " + table, connection);

            command.ExecuteReader();

            connection.Close();
        }

        public List<Question> GetAllQuestionsFromDataBase()
        {
            List<Question> questionList = new List<Question>();

            using var connection = new SqlConnection(ConnectionString);

            connection.Open();

            var command = new SqlCommand("SELECT * FROM Questions", connection);

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                questionList.Add(new Question(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2)));
            }

            connection.Close();

            return questionList;
        }

        public List<Question> GetAllQuestionsFromDataBase(string Table)
        {
            List<Question> questionList = new List<Question>();

            using var connection = new SqlConnection(ConnectionString);

            connection.Open();

            var command = new SqlCommand("SELECT * FROM " + Table, connection);

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                questionList.Add(new Question(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2)));
            }

            connection.Close();

            return questionList;
        }

        public List<Question> GetQuestionsFromQuestionnaire(int questionnaireId)
        {
            List<Question> questionList = new List<Question>();

            using var connection = new SqlConnection(ConnectionString);

            connection.Open();

            var command = new SqlCommand("SELECT * FROM Questions WHERE QuestionnaireID = " + questionnaireId, connection);

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                questionList.Add(new Question(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2)));
            }

            connection.Close();

            return questionList;
        }

        public List<Question> GetQuestionsFromQuestionnaire(int questionnaireId, string Table)
        {
            List<Question> questionList = new List<Question>();

            using var connection = new SqlConnection(ConnectionString);

            connection.Open();

            var command = new SqlCommand("SELECT * FROM " + Table + " WHERE QuestionnaireID = " + questionnaireId, connection);

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                questionList.Add(new Question(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2)));
            }

            connection.Close();

            return questionList;
        }

        public int GetUserIDFromDataBase(string email)
        {
            using var connection = new SqlConnection(ConnectionString);

            connection.Open();

            var command = new SqlCommand("IF not exists(SELECT * FROM users WHERE Email = '" + email + "')" +
                                         "\nBEGIN" +
                                         "\nINSERT INTO Users(Email) VALUES('" + email + "')"+
                                         "\nEND" +
                                         "\nSELECT * FROM users WHERE Email = '" + email + "'", connection);

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
