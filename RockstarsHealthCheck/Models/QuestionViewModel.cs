using Microsoft.AspNetCore.Mvc;

namespace RockstarsHealthCheck.Models
{
    public class QuestionViewModel
    {
        private DataBase _dataBase = new DataBase();

        public string? Name { get; set; }
        public string? Email { get; set; }
        [BindProperty] public List<Question> Questions { get; set; }
        public int QuestionnaireId { get; set; }

        public QuestionViewModel()
        {

        }

        public void GetQuestions(int id)
        {
            QuestionnaireId = id;
            Questions = _dataBase.GetQuestionsFromQuestionnaire(QuestionnaireId);
            OrderList();
        }

        private void OrderList()
        {
            Questions.Sort(delegate (Question x, Question y) {
                return x.Type.CompareTo(y.Type);
            });
            Questions.Sort(delegate (Question x, Question y) {
                return x.Category.CompareTo(y.Category);
            });
        }
    }
}