using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace RockstarsHealthCheck.Models
{
    public class QuestionViewModel
    {
        private DataBase _dataBase = new DataBase();

        public string? Email { get; set; }
        [BindProperty] public List<Question> Questions { get; set; }
        public int QuestionnaireId { get; set; }

        public QuestionViewModel()
        {
            Questions = _dataBase.GetQuestionsFromQuestionnaire(1);
            OrderList();
            QuestionnaireId = 1;
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