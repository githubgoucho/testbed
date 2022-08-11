using System;
using System.Collections.Generic;
using System.Linq;

var users = new List<User>
{
    new ("Robert", "Novak", 1770),
    new ("John", "Doe", 1230),
    new ("Lucy", "Novak", 670),
    new ("Ben", "Walter", 2050),
    new ("Robin", "Brown", 2300),
    new ("Amy", "Doe", 1250),
    new ("Joe", "Draker", 1190),
    new ("Janet", "Doe", 980),
    new ("Peter", "Novak", 990),
    new ("Albert", "Novak", 1930),
};

Console.WriteLine("sort descending by last name and salary");

var sortedUsers = from user in users
                  orderby user.LastName descending, user.Salary descending
                  select user;

foreach (var user in sortedUsers)
{
    Console.WriteLine(user);
}

Console.WriteLine("-------------------------");

Console.WriteLine("sort ascending by last name and salary");

var sortedUsers2 = from user in users
                   orderby user.LastName ascending, user.Salary ascending
                   select user;

foreach (var user in sortedUsers2)
{
    Console.WriteLine(user);
}

record User(string FirstName, string LastName, int Salary);