using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace PlannerPrototype
{
    class Planner
    {
        public Dictionary<string, TimeSpan> ToDoList
        {
             get; set;
        }

        public Planner()
        {
            ToDoList = new Dictionary<string, TimeSpan>();
        }
    }
}
