namespace RockstarsHealthCheck.Models
{
    public class URL
    {
        int questionaireID = 1;

        string GenerateQuestionaireURL(int questionaireID)
        {
            return "https://rockstarshealthcheck.azurewebsites.net/questionaire/" + questionaireID.ToString();
        }
    }
}

