using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");

        int ab = Add(5, 6);

        Console.WriteLine(ab);

        int sb = Subtract(10, 5);

        Console.WriteLine(sb);

        Console.WriteLine(IsEven(5));

        Console.WriteLine(IsOdd(5));
    }

    public static int Add(int a, int b)
    {
        return a + b;
    }

    public static int Subtract(int a, int b)
    {
        return a - b;
    }

    public static bool IsEven(int a)
    {
        return a % 2 == 0;
    }

    public static bool IsOdd(int a)
    {
        return a % 2 != 0;
    }
}
