using System.ComponentModel.DataAnnotations;

namespace RockstarsHealthCheck.Models
{
    public class Question
    {
        public int? Id { get; set; }
        public string? QuestionString { get; set; }
        public int? Answer { get; set; }
        public string? AnswerString { get; set; }
        public string? category { get; set; }

        public Question()
        {

        }

        public Question(int id, string q, string c)
        {
            Id = id;
            QuestionString = q;
            category = c;
        }
    }
}
