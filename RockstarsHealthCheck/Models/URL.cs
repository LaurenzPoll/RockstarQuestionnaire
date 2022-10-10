using Newtonsoft.Json.Serialization;

namespace RockstarsHealthCheck.Models;

public class URL
{
    //int questionnaireID = 1;

    public static string GenerateQuestionnaireURL(int questionnaireID)
    {
        return "https://rockstarshealthcheck.azurewebsites.net/questionaire/" + questionnaireID.ToString();
    }
}
