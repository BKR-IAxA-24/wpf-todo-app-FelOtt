using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    internal class Task
    {
        public string Description { get; private set; }
        public bool isComplete { get; private set; }

        public DateTime date { get; private set; }

        public Task(string description)
        {
            this.Description = description;
            this.date = DateTime.Now;
            isComplete = false;
        }

        public void CompleteTask()
        {
            isComplete = true;
        }

        public override string ToString()
        {
            //if (isComplete) is true say completed else say not completed
            return $"{Description} / {(isComplete ? "Completed" : "Not Completed")} / {date.ToShortDateString()}";
        }
    }
}
