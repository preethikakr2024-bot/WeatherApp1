using System;

// Parent class
class Chef
{
    public void MakeChicken()
    {
        Console.WriteLine("Chef makes chicken");
    }

    public void MakeSalad()
    {
        Console.WriteLine("Chef makes salad");
    }
}
// Child class
class ItalianChef : Chef
{
    public void MakePasta()
    {
        Console.WriteLine("Italian Chef makes pasta");
    }
}

class Program
{
    static void Main(string[] args)
    {
        ItalianChef chef = new ItalianChef();

        chef.MakeChicken(); // inherited
        chef.MakeSalad();   // inherited
        chef.MakePasta();   // own method
    }
}