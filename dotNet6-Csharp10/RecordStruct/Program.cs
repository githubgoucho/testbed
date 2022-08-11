using System;
using System.Text;

namespace Demo;

class Program
    {
        public abstract record Person(string FirstName, string LastName, string[] PhoneNumbers)
        {
            protected virtual bool PrintMembers(StringBuilder stringBuilder)
            {
                stringBuilder.Append($"FirstName = {FirstName}, LastName = {LastName}, ");
                stringBuilder.Append($"PhoneNumber1 = {PhoneNumbers[0]}, PhoneNumber2 = {PhoneNumbers[1]}");
                return true;
            }
        }

        public record Teacher(string FirstName, string LastName, string[] PhoneNumbers, int Grade)
            : Person(FirstName, LastName, PhoneNumbers)
        {
            protected override bool PrintMembers(StringBuilder stringBuilder)
            {
                if (base.PrintMembers(stringBuilder))
                {
                    stringBuilder.Append(", ");
                };
                stringBuilder.Append($"Grade = {Grade}");
                return true;
            }
        };

        public static void Main()
        {
            Person teacher = new Teacher("Nancy", "Davolio", new string[2] { "555-1234", "555-6789" }, 3);
            Console.WriteLine(teacher);
            // output: Teacher { FirstName = Nancy, LastName = Davolio, PhoneNumber1 = 555-1234, PhoneNumber2 = 555-6789, Grade = 3 }
        }
    }
