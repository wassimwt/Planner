using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace PlannerPrototype
{
    class Program
    {


        static void Main(string[] args)
        {

            var plannerList = new List<Object>();
            // Initialize input variable
            int input;
            var toQuit = false;
            var planner = new Planner();
            PlannerMethods.DeserializeDict(planner);

            // Ask the user what task they want to do
            while (!toQuit)
            {
                Console.WriteLine("Do you want to:");
                Console.WriteLine("1: Add project");
                Console.WriteLine("2: Show to-do list");
                Console.WriteLine("3: Clear to do list");
                Console.WriteLine("4: Exit");

                // Register user input
                input = Convert.ToInt32(Console.ReadLine());

                var newToDoList = new Dictionary<string, TimeSpan>();
                // Add a project if the input is 1
                switch (input)
                {
                    case 1:
                        PlannerMethods.AddTask(planner);
                        Console.WriteLine("=============");
                        break;

                    // Show to-do list if the input is 2
                    case 2:
                        PlannerMethods.ShowToDoList(planner);
                        Console.WriteLine("=============");
                        break;

                    // Clear to-do list if the input is 3
                    case 3:
                        PlannerMethods.ClearList(planner);
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
