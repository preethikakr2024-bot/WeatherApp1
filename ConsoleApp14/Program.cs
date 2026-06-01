using System;

class Program
{
    static double Add(double a, double b)
    {
        return a + b;
    }

    static double Subtract(double a, double b)
    {
        return a - b;
    }

    static double Multiply(double a, double b)
    {
        return a * b;
    }

    static double Divide(double a, double b)
    {
        return a / b;
    }

    static void Main(string[] args)
    {
        Console.Write("Enter first number: ");
        double num1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter operator (+, -, *, /): ");
        char op = Convert.ToChar(Console.ReadLine());

        Console.Write("Enter second number: ");
        double num2 = Convert.ToDouble(Console.ReadLine());

        double result = 0;

        if (op == '+')
            result = Add(num1, num2);
        else if (op == '-')
            result = Subtract(num1, num2);
        else if (op == '*')
            result = Multiply(num1, num2);
        else if (op == '/')
            result = Divide(num1, num2);
        else
            Console.WriteLine("Invalid operator");

        Console.WriteLine("Result = " + result);
        Console.ReadLine();
    }
}