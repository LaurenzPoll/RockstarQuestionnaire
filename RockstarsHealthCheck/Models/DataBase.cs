using System.Collections.Generic;
using System.Data.SqlClient;

namespace RockstarsHealthCheck.Models
{
    public class DataBase
    {
        private string connectionString = @"Server=tcp:rockstars.database.windows.net,1433;Initial Catalog=RockstarsDataBase;Persist Security Info=False;User ID=RockstarAdmin;Password=Rockstars!;MultipleActiveResultSets=False; Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        private int userID;

        public List<QuestionnaireViewModel> GetAllQuestionnaires()
        {
            QuestionnairesViewModel questionnaires = new QuestionnairesViewModel();

            using var connection = new SqlConnection(connectionString);

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

        public void SendAnswersToDataBase(QuestionViewModel viewModel)
        {
            int userID = GetUserIDFromDataBase(viewModel.Email);

            using var connection = new SqlConnection(connectionString);


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

                var reader = command.ExecuteReader();
                connection.Close();
            }

        }

        public List<Question> GetQuestionsFromQuestionnaire(int questionnaireId)
        {
            List<Question> questionList = new List<Question>();

            using var connection = new SqlConnection(connectionString);

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

        public int GetUserIDFromDataBase(string email)
        {
            using var connection = new SqlConnection(connectionString);

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
