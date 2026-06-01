using System;
namespace red
{
    class csharp
    {
        static void Main(string[] args)
        {
            Console.WriteLine(cube(6));
            Console.ReadLine();
        }
        static int cube(int num)
        {
            int result = num * num * num;
            return result;
        }
    }
}