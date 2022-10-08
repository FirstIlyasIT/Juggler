using JugglerClient;

var builder = new ConnectionBuilder();
using var connection = new JugglerConnection(builder);
connection.Open();
var response = connection.Query("");
Console.WriteLine(response);