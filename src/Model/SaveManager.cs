using System;
using System.IO;
using System.Text;

namespace Tasks
{
    public class SaveManager
    {
        //===================================================================== CONSTANTS
        private static readonly string SAVE_PATH = AppDomain.CurrentDomain.BaseDirectory + "save.txt";
        private static readonly string BACKUP_PATH = AppDomain.CurrentDomain.BaseDirectory + "save_bak.txt";
        public const char DELIM = '|';

        //===================================================================== FUNCTIONS
        public static Tasks LoadTasks()
        {
            Tasks tasks = new Tasks();
            try
            {
                if (File.Exists(SAVE_PATH))
                {
                    foreach (string line in File.ReadAllLines(SAVE_PATH))
                    {
                        string[] split = line.Split(new char[] { DELIM }, StringSplitOptions.None);
                        string name = split[0];
                        DateTime date = new DateTime(long.Parse(split[1]));
                        Task.Type type = (Task.Type)Enum.Parse(typeof(Task.Type), split[2]);
                        int remindStart = int.Parse(split[3]);
                        tasks.Add(name, date, type, remindStart);
                    }
                }
            }
            catch (Exception ex)
            {
                Backup();
            }
            return tasks;
        }

        public static void SaveTasks(Tasks tasks)
        {
            StringBuilder save = new StringBuilder();
            foreach (Task task in tasks)
                save.AppendFormat("{1}{0}{2}{0}{3}{0}{4}{5}", DELIM, task.Name, task.Date.Ticks, task.TaskType.ToString(), task.RemindStart, Environment.NewLine);
            File.WriteAllText(SAVE_PATH, save.ToString());
        }

        public static void Backup()
        {
            if (File.Exists(SAVE_PATH))
                File.Copy(SAVE_PATH, BACKUP_PATH, true);
        }
    }
}
