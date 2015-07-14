using System;

namespace Tasks
{
    public class Task : IComparable<Task>
    {
        //===================================================================== CLASSES
        public enum Type
        {
            Appointment, Assignment, Deadline, School, Task
        }

        //===================================================================== VARIABLES
        private string _name;
        private DateTime _date;
        private Type _type;
        private int _remindStart;

        //===================================================================== INITIALIZE
        public Task(string name, DateTime date, Type type, int remindStart)
        {
            Name = name;
            Date = date;
            TaskType = type;
            RemindStart = remindStart;
        }

        //===================================================================== FUNCTIONS
        public int CompareTo(Task task)
        {
            if (Date < task.Date) return -1;
            else if (Date > task.Date) return 1;

            return Name.CompareTo(task.Name);
        }

        //===================================================================== PROPERTIES
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }
        public Type TaskType
        {
            get { return _type; }
            set { _type = value; }
        }
        public int RemindStart
        {
            get { return _remindStart; }
            set{ _remindStart = Math.Max(value, 0); }
        }

        public long DaysUntilNow
        {
            get { return (long)(Date - DateTime.Today).TotalDays; }
        }
        public bool IsDue
        {
            get { return DaysUntilNow <= 0; }
        }
        public bool IsRemindRequired
        {
            get { return DateTime.Today >= Date.AddDays(-_remindStart); }
        }
    }
}
