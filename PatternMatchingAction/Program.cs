using System;

namespace ConsoleApp1
{
    class Program
    {
        public static void Main()
        {
            Action<string> greet = name =>
            {
                string greeting = $"Hello {name}!";
                Console.WriteLine(greeting);
            };

            greet("Paule");
            //Pattern matching
            Console.WriteLine(IsLetter('a'));
            bool IsLetter(char c) => c is >= 'a' and <= 'z' or >= 'A' and <= 'Z';
            Console.WriteLine(IsLetter('-'));
        }
    }
}