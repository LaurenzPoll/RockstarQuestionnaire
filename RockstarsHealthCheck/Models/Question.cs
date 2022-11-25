namespace RockstarsHealthCheck.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionString { get; set; }
        public int? Answer { get; set; }
        public string? AnswerString { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }

        public Question(int id, string question, string category, string type)
        {
            Id = id;
            Category = category;
            QuestionString = question;
            Type = type;
        }
    }
}
