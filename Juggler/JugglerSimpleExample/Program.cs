using JugglerClient.Connection;
using JugglerClient.StorageContext;
using JugglerSimpleExample;

var builder = new ConnectionParams("localhost", 11000);
var context = new StorageContext(builder);
var employee = new Employee("smith", 32000);
context.Get<Employee>().Add(employee);
Console.WriteLine(context.Push());
employee.Name = "Jonny";
Console.WriteLine(context.Update());
var employee2 = context.Get<Employee>().First(x => x == employee);
Console.WriteLine(employee == employee2);
Console.WriteLine(employee2.Name, employee.Salary);