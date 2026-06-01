using System;
class Student
{
    public string name;
    public Student()
    {
        name = "Default Name";
    }
}
class Program
{
    static void Main(string[] args)
    {
        Student s1 = new Student();
        Console.WriteLine(s1.name);
    }
}