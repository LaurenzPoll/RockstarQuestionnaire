namespace RockstarsHealthCheck.Models;

public class QuestionnaireViewModel
{
    private int QuestionnaireID;
    private string QuestionnaireName;

    public QuestionnaireViewModel(int questionnaireID, string questionnaireName)
    {
        this.QuestionnaireID = questionnaireID;
        this.QuestionnaireName = questionnaireName;
    }

    public int questionnaireID { get; set; }
    public string questionnaireName { get; set; }

    public int GetId()
    {
        return QuestionnaireID;
    }

    public string GetName()
    {
        return QuestionnaireName;
    }
}
