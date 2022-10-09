using JugglerClient;
using JugglerSimpleExample;

var builder = new ConnectionParamsBuilder("localhost", 11000);
using var connection = new JugglerConnection(builder);
var context = new StorageContext<object>(new ExampleConfiguration());
var employee = new Employee("smith", 32000);
context[typeof(Employee)].Add(employee);
context.Push();
