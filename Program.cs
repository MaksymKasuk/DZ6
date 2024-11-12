using System;
using System.Collections;
using System.Collections.Generic;

public class Employee : IComparable<Employee>
{
    public string Name { get; set; }
    public int Age { get; set; }
    public int Experience { get; set; }

    public Employee(string name, int age, int experience)
    {
        Name = name;
        Age = age;
        Experience = experience;
    }

    public int CompareTo(Employee other)
    {
        if (other == null) return 1;
        return Age.CompareTo(other.Age);
    }

    public override string ToString()
    {
        return $"Ім'я: {Name}, Вік: {Age}, Стаж: {Experience} років";
    }
}

public class ExperienceComparer : IComparer<Employee>
{
    public int Compare(Employee x, Employee y)
    {
        if (x == null || y == null)
            throw new ArgumentException("Об'єкти для порівняння не можуть бути null");

        return x.Experience.CompareTo(y.Experience);
    }
}

public class EmployeeCollection : IEnumerable<Employee>
{
    private List<Employee> employees = new List<Employee>();

    public void AddEmployee(Employee employee)
    {
        employees.Add(employee);
    }

    public IEnumerator<Employee> GetEnumerator()
    {
        employees.Sort(new ExperienceComparer());
        return employees.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public class Program
{
    public static void Main()
    {
        var employees = new EmployeeCollection();
        employees.AddEmployee(new Employee("Олексій", 30, 5));
        employees.AddEmployee(new Employee("Ірина", 25, 3));
        employees.AddEmployee(new Employee("Василь", 35, 10));
        employees.AddEmployee(new Employee("Марина", 40, 8));

        Console.WriteLine("Список співробітників, впорядкований за стажем роботи:");
        foreach (var employee in employees)
        {
            Console.WriteLine(employee);
        }
    }
}
