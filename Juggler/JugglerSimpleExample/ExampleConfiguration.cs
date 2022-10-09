using JugglerClient.StorageContext;

namespace JugglerSimpleExample;

public class ExampleConfiguration : JugglerConfiguration
{
    public ExampleConfiguration()
    {
        AddType<Employee>();
    }
}