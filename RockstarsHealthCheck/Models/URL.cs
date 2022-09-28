namespace RockstarsHealthCheck.Models
{
    public class URL
    {
        int questionnaireID = 1;

        string GenerateQuestionnaireURL(int questionaireID)
        {
            return "https://rockstarshealthcheck.azurewebsites.net/questionaire/" + questionnaireID.ToString();
        }
    }
}

