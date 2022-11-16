using System.Collections.Generic;
using System.Data.SqlClient;

namespace RockstarsHealthCheck.Models
{
    public class DataBase
    {
        private string ConnectionString = @"Server=tcp:rockstars.database.windows.net,1433;Initial Catalog=RockstarsDataBase;Persist Security Info=False;User ID=RockstarAdmin;Password=Rockstars!;MultipleActiveResultSets=False; Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private int userID;

        public List<QuestionnaireViewModel> GetAllQuestionnaires()
        {
            QuestionnairesViewModel questionnaires = new QuestionnairesViewModel();

            using var connection = new SqlConnection(ConnectionString);

            connection.Open();

            var command = new SqlCommand("SELECT QuestionnaireID, QuestionnaireName FROM Questionnaires", connection);
            var reader = command.ExecuteReader();

            while(reader.Read())
            {
                questionnaires.AddToQuestionnaireList(new QuestionnaireViewModel(reader.GetInt32(0), reader.GetString(1)));
            }

            connection.Close();

            return questionnaires.GetquestionnaireList();
        }

        public void SendAnswersToDataBase(QuestionViewModel viewModel)
        {
            int userID = GetUserIDFromDataBase(viewModel.Email);

            using var connection = new SqlConnection(ConnectionString);

            foreach (Question question in viewModel.Questions)
            {
                connection.Open();
                var command = new SqlCommand(" insert into Answers (UserID, QuestionID, Answer, AnswerRange) " +
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

        public void AddQuestionToDataBase(int QuestionCategory, string Question)
        {
            using var connection = new SqlConnection(ConnectionString);

            connection.Open();

            var command = new SqlCommand("INSERT INTO Questions(QuestionCategory, Question) VALUES (" + QuestionCategory + " , '" + Question + "' )", connection);

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
                questionList.Add(new Question(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
            }

            connection.Close();

            return questionList;
        }

        public List<Question> GetQuestionsFromQuestionnaire(int questionnaireId)
        {
            List<int> questionIds = new List<int>();
            List<Question> questionList = new List<Question>();

            using var connection = new SqlConnection(ConnectionString);

            connection.Open();
            var command = new SqlCommand("SELECT * FROM Questionnaires_Questions WHERE QuestionnaireID = " + questionnaireId, connection);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                questionIds.Add(reader.GetInt32(0));
            }
            connection.Close();

            foreach (int id in questionIds)
            {
                connection.Open();
                command = new SqlCommand("SELECT * FROM Questions WHERE QuestionID = " + id, connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    questionList.Add(new Question(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
                }
                connection.Close();
            }

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
