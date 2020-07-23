using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace PlannerPrototype
{
    class Planner
    {
        private const string PlannerFileName = "planner.json";

        public Dictionary<string, TimeSpan> ToDoList { get; set; }

        public Planner()
        {
            ToDoList = new Dictionary<string, TimeSpan>();
        }

        public void AddTask()
        {
            string projectName;
            TimeSpan duration = TimeSpan.Zero;

            while (duration == TimeSpan.Zero)
            {
                Console.WriteLine("Enter project name:");
                projectName = Console.ReadLine();

                if (!ToDoList.ContainsKey(projectName))
                {
                    Console.WriteLine("Enter the duration");

                    if (TimeSpan.TryParse(Console.ReadLine(), out duration))
                    {
                        ToDoList.Add(projectName, duration);
                        Save();
                        Console.WriteLine("Task successfully added.");
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

        public void ShowToDoList()
        {
            if (ToDoList.Count == 0)
            {
                Console.WriteLine("No tasks have been added.");
                return;
            }

            foreach (KeyValuePair<string, TimeSpan> kvp in ToDoList)
            {
                var hour = new TimeSpan(1, 0, 0);
                string suffix;
                if (TimeSpan.Compare(kvp.Value, hour) >= 0)
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

        public void ClearList()
        {
            int tasks = ToDoList.Count;
            ToDoList.Clear();
            Save();
            Console.WriteLine($"{tasks} task{(tasks > 1 ? "s" : "")} has been deleted successfully");

        }

        private void Save()
        {
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(PlannerFileName, json);
        }

        public static Planner Load()
        {
            string jsonRead = File.ReadAllText(PlannerFileName);
            return JsonConvert.DeserializeObject<Planner>(jsonRead);
        }
    }
}
