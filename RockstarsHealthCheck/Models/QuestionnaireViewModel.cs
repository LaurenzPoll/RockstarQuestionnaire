namespace RockstarsHealthCheck.Models;

public class QuestionnaireViewModel
{
    private int QuestionnaireID;
    private string QuestionnaireName;
    private string QuestionnaireLink;

    public QuestionnaireViewModel(int questionnaireID, string questionnaireName)
    {
        this.QuestionnaireID = questionnaireID;
        this.QuestionnaireName = questionnaireName;
    }

    //public QuestionnaireViewModel(int questionnaireID, string questionnaireName, string questionnaireLink)
    //{
    //    this.QuestionnaireID = questionnaireID;
    //    this.QuestionnaireName = questionnaireName;
    //    this.QuestionnaireLink = questionnaireLink;
    //}

    public int questionnaireID { get; set; }
    public string questionnaireName { get; set; }
}
