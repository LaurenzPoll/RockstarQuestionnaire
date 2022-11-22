using System.ComponentModel.DataAnnotations;

namespace RockstarsHealthCheck.Models
{
    public class Question
    {
        public int? Id { get; set; }
        public string? QuestionString { get; set; }
        public int? Answer { get; set; }
        public string? AnswerString { get; set; }
        public string? Category { get; set; }

        public Question()
        {

        }

        public Question(int id, string question, string category)
        {
            Id = id;
            Category = category;
            QuestionString = question;
        }
    }
}
