using System;

namespace LABFirstAndReserveTeam
{
    class Program
    {
        static void Main(string[] args)
        {
            Team team = new Team("DavidHolding");
            Console.WriteLine("Type with integer how many persons you will add:");
            int info = int.Parse(Console.ReadLine());
            Console.WriteLine("Now input on one line for every person: first name, last name, age and salary.");
            for (int i = 0; i < info; i++)
            {
                string[] input = Console.ReadLine().Split();
                try
                {
                    Person person = new Person(input[0], input[1], int.Parse(input[2]), decimal.Parse(input[3]));
                    team.AddPlayer(person);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            Console.WriteLine(team);
        }
    }
}
