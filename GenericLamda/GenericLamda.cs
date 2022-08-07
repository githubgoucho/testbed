using System;
using System.Collections.Generic;
using System.Linq;

public delegate T add<T>(T param1, T param2); // generic delegate

class GenericLamda
{
    static void Main(string[] args)
    {
        add<int> sum = Sum;
        Console.WriteLine(sum(10, 20));

        add<string> con = Concat;
        Console.WriteLine(con("Hello ", "World!!"));

        add<int> sumL = (a, b) => a + b;
        Console.WriteLine(sumL(10, 20));

        add<string> conL = (a, b) => a + b;
        Console.WriteLine(conL("Hello ", "World!!"));
    }

    public static int Sum(int val1, int val2)
    {
        return val1 + val2;
    }

    public static string Concat(string str1, string str2)
    {
        return str1 + str2;
    }
}