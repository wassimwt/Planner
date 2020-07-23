using System;

namespace PlannerPrototype
{
    class Program
    {
        static void Main(string[] args)
        {
            var toQuit = false;
            var planner = Planner.Load();

            // Ask the user what task they want to do
            while (!toQuit)
            {
                Console.WriteLine("Do you want to:");
                Console.WriteLine("1: Add project");
                Console.WriteLine("2: Show to-do list");
                Console.WriteLine("3: Clear to-do list");
                Console.WriteLine("4: Exit");

                // Register user input
                int.TryParse(Console.ReadLine(), out var input);

                switch (input)
                {
                    // Add a project if the input is 1
                    case 1:
                        planner.AddTask();
                        Console.WriteLine("=============");
                        break;

                    // Show to-do list if the input is 2
                    case 2:
                        planner.ShowToDoList();
                        Console.WriteLine("=============");
                        break;

                    // Clear to-do list if the input is 3
                    case 3:
                        planner.ClearList();
                        Console.WriteLine("=============");
                        break;

                    // Escape the loop and exit the program if the input is 4
                    case 4:
                        toQuit = true;
                        break;

                    // Tell the user that the input was invalid >= 0 or > 4
                    default:
                        Console.WriteLine("invalid input");
                        Console.WriteLine("=============");
                        break;
                }
                // Keep looping through the programm
            }
        }
    }
}
