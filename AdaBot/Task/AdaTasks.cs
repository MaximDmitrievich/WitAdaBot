using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdaBot.Task
{
    [Serializable]
    public class AdaTasks
    {
        public bool Tasking { get; set; }
        public bool Unreaded { get; set; }
        public int Number { get; set; }
        public List<TaskIn> Tasks;

        public AdaTasks()
        {
            Tasks = Helpers.GetTasks();
            Random rand = new Random();
            Tasking = true;
            Unreaded = true;
            Number = rand.Next(0, Tasks.Count);
        }
        
    }
}