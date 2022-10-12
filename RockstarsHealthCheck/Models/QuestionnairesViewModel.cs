namespace RockstarsHealthCheck.Models;

public class QuestionnairesViewModel
{
    private List<QuestionnaireViewModel> questionnaireList = new List<QuestionnaireViewModel>();

    public QuestionnairesViewModel()
    {

    }

    public void AddToQuestionnaireList(QuestionnaireViewModel questionnaire)
    {
        questionnaireList.Add(questionnaire);
    }

    public List<QuestionnaireViewModel> GetquestionnaireList()
    {
        return questionnaireList;
    }
}
