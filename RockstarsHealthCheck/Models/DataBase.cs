using System.Collections.Generic;
using System.Data.SqlClient;

namespace RockstarsHealthCheck.Models
{
    public class DataBase
    {
        private string connectionString = @"Server=tcp:rockstars.database.windows.net,1433;Initial Catalog=RockstarsDataBase;Persist Security Info=False;User ID=RockstarAdmin;Password=Rockstars!;MultipleActiveResultSets=False; Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";


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
    }
}
