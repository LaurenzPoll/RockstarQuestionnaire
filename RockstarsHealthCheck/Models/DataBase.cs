using System.Data.SqlClient;

namespace RockstarsHealthCheck.Models
{
    public class DataBase
    {
        private string ConnectionString = @"Server=tcp:rockstars.database.windows.net,1433;Initial Catalog=RockstarsDataBase;Persist Security Info=False;User ID=RockstarAdmin;Password=Rockstars!;MultipleActiveResultSets=False; Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private int userID;
        Random rnd = new Random();

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
            using var connection = new SqlConnection(ConnectionString);

            SqlCommand command;
            DateTime now = DateTime.Now;
            double randomdays = rnd.Next(0, 30) * 7;
            now.AddDays(randomdays);
            string nowstring = now.ToString("yyyy-MM-dd hh:mm:ss");
            int? id = GetUserIDFromDataBase(viewModel.Email, viewModel.Name);

            connection.Open();
            command = new SqlCommand(" insert into FilledOutQuestionnaires (DateTime, UserID, QuestionnaireID) " +
                "\nvalues " +
                "\n( '" +
                nowstring + "' , " +
                id + " , " +
                viewModel.QuestionnaireId + " )", connection);

            command.ExecuteReader();
            connection.Close();

            connection.Open();
            command = new SqlCommand("SELECT FilledOutQuestionnaireID FROM FilledOutQuestionnaires WHERE DateTime = '" + nowstring + "'", connection);
            var reader = command.ExecuteReader();

            if (reader.Read())
            {
                id = reader.GetInt32(0);
            }
            connection.Close();

            if (id != null)
            {
                foreach(Question question in viewModel.Questions)
                {
                    connection.Open();
                    command = new SqlCommand(" insert into Answers (FilledOutQuestionnaireID, QuestionID, AnswerRange, AnswerComment) " +
                        "\nvalues " +
                        "\n( " +
                        id + " , " +
                        question.Id + " , " +
                        question.Answer + " , '" +
                        question.AnswerString + "' )", connection);

                    command.ExecuteReader();
                    connection.Close();
                }
            }
        }

        public void AddQuestionToDataBase(Question Question)
        {
            using var connection = new SqlConnection(ConnectionString);

            connection.Open();

            var command = new SqlCommand("INSERT INTO Questions(Question, CategoryID, Type) VALUES ('" + Question.QuestionString + "'," + Question.Category + ",'" + Question.Type + "')", connection);

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
                questionList.Add(new Question(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3)));
            }

            connection.Close();

            return questionList;
        }

        public List<Question> GetQuestionsFromQuestionnaire(int questionnaireId)
        {
            List<Question> questionList = new List<Question>();
            List<int> QuestionIds = GetQuestionIds(questionnaireId);

            foreach (int id in QuestionIds)
            {
                using var connection = new SqlConnection(ConnectionString);
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Questions WHERE QuestionID = " + id, connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    questionList.Add(new Question(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3)));
                }
                connection.Close();
            }

            return questionList;
        }

        private List<int> GetQuestionIds(int questionnaireId)
        {
            List<int> QuestionIds = new List<int>();

            using var connection = new SqlConnection(ConnectionString);

            connection.Open();
            var command = new SqlCommand("SELECT * FROM Questionnaires_Questions WHERE QuestionnaireID = " + questionnaireId, connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                QuestionIds.Add(reader.GetInt32(0));
            }
            connection.Close();

            return QuestionIds;
        }

        public int GetUserIDFromDataBase(string email, string name)
        {
            using var connection = new SqlConnection(ConnectionString);

            connection.Open();

            var command = new SqlCommand("IF not exists(SELECT * FROM users WHERE Email = '" + email + "')" +
                                         "\nBEGIN" +
                                         "\nINSERT INTO Users(Email, Name) VALUES('" + email + "','" + name + "')"+
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
