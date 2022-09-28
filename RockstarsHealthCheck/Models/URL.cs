namespace RockstarsHealthCheck.Models
{
    public class URL
    {
        int questionnaireID = 1;

        string GenerateQuestionnaireURL(int questionnaireID)
        {
            return "https://rockstarshealthcheck.azurewebsites.net/questionaire/" + questionnaireID.ToString();
        }
    }
}

