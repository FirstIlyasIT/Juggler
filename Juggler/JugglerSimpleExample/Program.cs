using JugglerClient.Connection;
using JugglerClient.StorageContext;
using JugglerSimpleExample;

var builder = new ConnectionParamsBuilder("localhost", 11000);
using var connection = new JugglerConnection(builder);
var context = new StorageContext(new ExampleConfiguration(), connection);
var employee = new Employee("smith", 32000);
context.Get<Employee>().Add(employee);
context.Push();
employee.Name = "Jonny";
context.Update();
var employee2 = context.Get<Employee>().First(x => x == employee);
Console.WriteLine(employee == employee2);
Console.WriteLine(employee2.Name);