using System;

namespace AdaBot
{
    [Serializable]
    public class TaskIn
    {
        public string Condition { get; set; }
        public int Answer { get; set; }
        public string Explanation { get; set; }

        public TaskIn(string cond, int ans, string exp)
        {
            Condition = cond;
            Answer = ans;
            Explanation = exp;
        }
        
    }
}