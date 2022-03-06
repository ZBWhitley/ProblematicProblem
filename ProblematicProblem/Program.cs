using System;
using System.Collections.Generic;
using System.Threading;

namespace ProblematicProblem
{
    static class Program
    {
        static bool cont = true;
        static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };
        static Random rng = new Random();
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
            if (Console.ReadLine().ToLower() == "yes") 
            {
                cont = true;
            }
            else 
            {
                Console.WriteLine("Have a great day!");
                Environment.Exit(0);
            }            
            Console.WriteLine();

            Console.WriteLine("We are going to need your information first! What is your name?");
            string userName = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("What is your age?");
            int userAge = Convert.ToInt32(Console.ReadLine());            
            Console.WriteLine();

            Console.WriteLine("Would you like to see the current list of activities? yes/no: ");
            bool seeList = (Console.ReadLine().ToLower() == "yes");
            Console.WriteLine();

            if (seeList)
            {
                foreach (string activity in activities)
                {
                    Console.Write($"{activity}, ");
                    Thread.Sleep(250);
                }

                Console.WriteLine();

                Console.WriteLine("Would you like to add any activities before we generate one? yes/no: ");
                bool addToList = (Console.ReadLine().ToLower() == "yes");
                Console.WriteLine();


                while (addToList)
                {
                    Console.WriteLine("What would you like to add? ");
                    string userAddition = Console.ReadLine();
                    activities.Add(userAddition);
                    foreach (string activity in activities)
                    {
                        Console.Write($"{activity}, ");
                        Thread.Sleep(250);
                    }
                    Console.WriteLine();

                    Console.WriteLine("Would you like to add more? yes/no: ");
                    addToList = Console.ReadLine().ToLower() == "yes";
                }
            }        
            while (cont) 
            { 
                Console.Write("Connecting to the database");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write("..");
                    Thread.Sleep(500);
                }

                Console.WriteLine();
                Console.Write("Choosing your random activity");

                for (int i = 0; i < 9; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }
                Console.WriteLine();

            
            
                
                int randomNumber = rng.Next(activities.Count);
                string randomActivity = activities[randomNumber];

                if (userAge < 21 && randomActivity == "Wine Tasting")
                {
                    Console.WriteLine($"Oh no! Looks like you are too young to do Wine Tasting!");
                    Console.WriteLine("Pick something else!");

                    activities.Remove(randomActivity);

                    randomNumber = rng.Next(activities.Count);

                    randomActivity = activities[randomNumber];
                }

                Console.Write($"Ah got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                Console.WriteLine();

                cont = Console.ReadLine().ToLower() == "redo";                
            }


        }
    }
}