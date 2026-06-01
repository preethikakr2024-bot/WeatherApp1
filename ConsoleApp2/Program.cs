using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string characterName = "john";
            int characterAge = 35;

            Console.WriteLine("there was a man named " + characterName);
            Console.WriteLine("he was " + characterAge + " years old");
            Console.WriteLine("he really liked the name " + characterName);
            Console.WriteLine("but did not like being " + characterAge + " years old");
            Console.ReadLine();
        }
    }
}