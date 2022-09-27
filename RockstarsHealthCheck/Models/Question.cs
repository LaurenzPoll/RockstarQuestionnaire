using System.Data.SqlClient;

namespace RockstarsHealthCheck.Models
{
    public class Question
    {
        public readonly int Id;
        public readonly int QuestionaireId;
        public readonly string QuestionString;
        public int? Answer;
        public string? AnswerString;

        public Question(int id, int qid, string question)
        {
            Id = id;
            QuestionaireId = qid;
            QuestionString = question;
        }
    }
}
