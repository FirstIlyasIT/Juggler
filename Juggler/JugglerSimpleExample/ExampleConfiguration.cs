using JugglerClient;

namespace JugglerSimpleExample;

public class ExampleConfiguration : JugglerConfiguration
{
    public ExampleConfiguration()
    {
        AddList(typeof(Employee));
    }
}