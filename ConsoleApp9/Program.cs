using System;
namespace adds
{
    class act
    {
        static void Main(string[] args)
        {
            string color, pluralNoun, celebrity;
            Console.Write("enter a color:");
            color = Console.ReadLine();
            Console.Write("enter a pluralnoun:");
            pluralNoun = Console.ReadLine();
            Console.Write("enter the celebrity:");
            celebrity = Console.ReadLine();

            Console.WriteLine("roses are"+color);
            Console.WriteLine(pluralNoun+" are blue");
            Console.WriteLine("i like"+celebrity);
            Console.ReadLine();
        }
    }
}