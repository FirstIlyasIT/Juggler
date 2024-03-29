using JugglerCore.Attributes;

namespace JugglerSimpleExample;

[Preserved]
public class Employee
{
    public Employee(string name, int salary)
    {
        Name = name;
        Salary = salary;
    }

    public string Name { get; set; }
    
    public float Salary { get; set; }
}