using System;
using System.Collections.Generic;

namespace LABValidationData
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type with integer how many persons you will add:");
            int info = int.Parse(Console.ReadLine());
            Console.WriteLine("Now input on one line for every person: first name, last name, age and salary.");
            Console.WriteLine("After that you need to put the percentage of salary increase");
            List<Person> persons = new List<Person>();
            for (int i = 0; i < info; i++)
            {
                string[] input = Console.ReadLine().Split();
                try
                {
                    Person person = new Person(input[0], input[1], int.Parse(input[2]), decimal.Parse(input[3]));
                    persons.Add(person);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
            decimal bonus = decimal.Parse(Console.ReadLine());
            persons.ForEach(p => p.IncreaseSalary(bonus));
            persons.ForEach(p => Console.WriteLine(p.ToString()));
        }
    }
}
