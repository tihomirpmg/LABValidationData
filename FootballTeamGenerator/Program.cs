using System;
using System.Collections.Generic;

namespace FootballTeamGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Team> teams = new Dictionary<string, Team>();
            Console.WriteLine("Input Team;(team name)");
            Console.WriteLine("After that you can add players in teame->Add;(team;)(player name;) and stats for endurance;, sprint;, dribble;, passing; and shooting");
            Console.WriteLine("You also can remove a player with->Remove;(team name;)(player name)");
            Console.WriteLine("You can show the rating of the team-> Rating;(team name)");
            Console.WriteLine("Type END for ending!!!");
            Console.WriteLine("HAVE FUN");
            Console.WriteLine("===============================================================");
            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] inputInfo = input.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                string inp = inputInfo[0];
                string teamName = inputInfo[1];
                try
                {
                    switch (inp.ToLower())
                    {
                        case "team":
                            teams.Add(teamName, new Team(teamName));
                            break;
                        case "add":
                            if (!teams.ContainsKey(teamName))
                            {
                                throw new ArgumentException($"Team {teamName} does not exist.");
                            }
                            Player player = new Player(inputInfo[2], int.Parse(inputInfo[3]), int.Parse(inputInfo[4]),int.Parse(inputInfo[5]), int.Parse(inputInfo[6]), int.Parse(inputInfo[7]));
                            teams[teamName].AddPlayer(player);
                            break;
                        case "remove":
                            string playerName = inputInfo[2];
                            teams[teamName].RemovePlayer(playerName);
                            break;
                        case "rating":
                            if (!teams.ContainsKey(teamName))
                            {
                                throw new ArgumentException($"Team {teamName} does not exist.");
                            }
                            Console.WriteLine(teams[teamName]);
                            break;
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                input = Console.ReadLine();
            }
        }
    }
}
