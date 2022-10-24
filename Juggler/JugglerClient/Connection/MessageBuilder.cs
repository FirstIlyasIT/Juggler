namespace JugglerClient.Connection;

public class MessageBuilder
{
    public string Build(string connectionString, List<string> pushDates)
    {
        var result = $"< connectionString: {connectionString};  /> ";
        foreach (var date in pushDates) 
            result += date;
        return result;
    }

    public List<string> ReBuild(string dates)
    {
        var result = new List<string>();
        return result;
    }
}