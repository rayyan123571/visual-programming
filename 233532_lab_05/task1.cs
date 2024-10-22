using System;

public enum Department
{
    ComputerScience,
    ElectricalEngineering,
    MechanicalEngineering,
    CivilEngineering
}

public class Person
{
    public string Name { get; set; }

    // No-argument constructor
    public Person()
    {
        Name = null;
    }

    // Multi-argument constructor
    public Person(string name)
    {
        Name = name;
    }
}

public class Student : Person
{
    public string RegNo { get; set; }
    public int Age { get; set; }
    public Department Program { get; set; }

    // No-argument constructor
    public Student() : base() // Calls the base class constructor
    {
        RegNo = null;
        Age = 0;
        Program = 0; // Default enum value
    }

    // Multi-argument constructor
    public Student(string name, string regNo, int age, Department program) : base(name)
    {
        RegNo = regNo;
        Age = age;
        Program = program;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Using no-argument constructor
        Student student1 = new Student();
        student1.Name = "John";
        student1.RegNo = "CS101";
        student1.Age = 20;
        student1.Program = Department.ComputerScience;

        // Using multi-argument constructor
        Student student2 = new Student("Alice", "EE102", 22, Department.ElectricalEngineering);

        // Output the details
        Console.WriteLine($"Student 1: {student1.Name}, {student1.RegNo}, {student1.Age}, {student1.Program}");
        Console.WriteLine($"Student 2: {student2.Name}, {student2.RegNo}, {student2.Age}, {student2.Program}");
    }
}
