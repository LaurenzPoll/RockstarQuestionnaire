using System.ComponentModel.DataAnnotations;

namespace RockstarsHealthCheck.Models
{
    public class Question
    {
        public int? Id { get; set; }
        public int? QuestionaireId { get; set; }
        public string? QuestionString { get; set; }
        public int? Answer { get; set; }
        public string? AnswerString { get; set; }

        public Question()
        {

        }

        public Question(int id, int qId, string q)
        {
            Id = id;
            QuestionaireId = qId;
            QuestionString = q;
        }
    }
}
