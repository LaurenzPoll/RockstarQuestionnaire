using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace RockstarsHealthCheck.Models
{
    public class QuestionViewModel
    {
        private DataBase _dataBase = new DataBase();

        public string? Email { get; set; }
        [BindProperty] public List<Question> Questions { get; set; }

        public QuestionViewModel()
        {
            Questions = _dataBase.GetQuestionsFromQuestionnaire(2);
        }

        public void OnGet()
        {
            Questions = _dataBase.GetQuestionsFromQuestionnaire(2);
        }

        public void OnPost(List<Question> questions)
        {

        }
    }
}
