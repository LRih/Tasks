using System;
using System.Collections;
using System.Collections.Generic;

namespace Tasks
{
    public class Tasks : IEnumerable
    {
        //===================================================================== VARIABLES
        private List<Task> _tasks = new List<Task>();

        //===================================================================== FUNCTIONS
        public void Add(string name, DateTime date, Task.Type type, int remindStart)
        {
            Add(new Task(name, date, type, remindStart));
        }
        public void Add(Task task)
        {
            _tasks.Add(task);
            _tasks.Sort();
        }
        public void Set(int index, Task task)
        {
            _tasks[index] = task;
            _tasks.Sort();
        }
        public void Delete(int index)
        {
            _tasks.RemoveAt(index);
        }

        public Task Get(int index)
        {
            return _tasks[index];
        }
        public List<Task> GetTasksOn(DateTime date)
        {
            List<Task> tasks = new List<Task>();
            foreach (Task task in _tasks)
                if (task.Date.Date == date.Date) tasks.Add(task);
            return tasks;
        }

        //===================================================================== PROPERTIES
        public IEnumerator GetEnumerator()
        {
            return _tasks.GetEnumerator();
        }

        public IList<Task> List
        {
            get { return _tasks; }
        }

        public bool IsRemindRequired
        {
            get
            {
                foreach (Task task in _tasks)
                    if (task.IsRemindRequired) return true;
                return false;
            }
        }
    }
}
