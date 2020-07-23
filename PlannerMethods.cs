using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace PlannerPrototype
{
    class PlannerMethods
    {
       public static void AddTask(Planner planner)
        {

            string projectName;
            TimeSpan duration = TimeSpan.Zero;

            while (duration == TimeSpan.Zero)
            {
                Console.WriteLine("Enter project name:");
                projectName = Console.ReadLine();

                if (!planner.ToDoList.ContainsKey(projectName))
                {
                    Console.WriteLine("Enter the duration");

                    if (TimeSpan.TryParse(Console.ReadLine(), out duration))
                    {
                        planner.ToDoList.Add(projectName, duration);
                        Console.WriteLine("Task successfully added.");
                        SerializeDict(planner);
                    }
                    else
                    {
                        Console.WriteLine("You've entered an invalid duration format. Try again please.");
                    }

                }
                else
                {
                    Console.WriteLine("This task is already added, choose another name please.");
                }
            }

        }

        public static void ShowToDoList(Planner planner)
        {
            if(planner.ToDoList.Count == 0)
            {
                Console.WriteLine("No tasks have been added.");
            }
            foreach(KeyValuePair<string, TimeSpan> kvp in planner.ToDoList)
            {
                var hour = new TimeSpan(1, 0, 0);
                string suffix = "";

                if(TimeSpan.Compare(kvp.Value, hour) >= 0)
                {
                    suffix = "hours";
                }
                else
                {
                    suffix = "minutes";
                }

                Console.WriteLine($"{kvp.Key} for {kvp.Value} {suffix}");
            }
        }

        public static void ClearList(Planner planner)
        {
            var plannerCount = planner.ToDoList.Count;
            planner.ToDoList.Clear();
            if(plannerCount == 1)
            {
                Console.WriteLine($"{plannerCount} task has been deleted successfully");
            }
            else
            {
                Console.WriteLine($"{plannerCount} tasks has been deleted successfully");
            }
            SerializeDict(planner);
        }

        public static void SerializeDict(Planner planner)
        {
            string json = JsonConvert.SerializeObject(planner.ToDoList, Formatting.Indented);
            File.WriteAllText(Environment.CurrentDirectory + @"\planner.json", json);
        }

        public static void DeserializeDict(Planner planner)
        {
            string jsonRead = File.ReadAllText(Environment.CurrentDirectory + @"\planner.json");
            planner.ToDoList = JsonConvert.DeserializeObject<Dictionary<string, TimeSpan>>(jsonRead);
        }

    }
}
