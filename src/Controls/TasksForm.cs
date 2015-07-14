using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Tasks
{
    public partial class TasksForm : Form
    {
        //===================================================================== VARIABLES
        private Tasks _tasks = new Tasks();

        //===================================================================== INITIALIZE
        public TasksForm()
        {
            InitializeComponent();

            this.Location = new Point(SystemInformation.PrimaryMonitorSize.Width - this.Width, SystemInformation.WorkingArea.Bottom - this.Height);

            _tasks = SaveManager.LoadTasks();
            RefreshList();
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (_tasks.IsRemindRequired)
                ShowForm();
            else
                this.Hide();
        }

        //===================================================================== TERMINATE
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            SaveManager.SaveTasks(_tasks);
        }

        //===================================================================== FUNCTIONS
        private void RefreshList()
        {
            lstTasks.DataSource = null;
            lstTasks.DataSource = _tasks.List;
        }

        private void ShowForm()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        //===================================================================== EVENTS
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            if (e.KeyCode == Keys.F12)
            {
                using (CalendarForm dialog = new CalendarForm())
                {
                    dialog.Tasks = _tasks;
                    dialog.ShowDialog(this);
                }
            }
        }

        private void menuList_Opening(object sender, CancelEventArgs e)
        {
            menuList.Items[1].Enabled = menuList.Items[2].Enabled = (lstTasks.SelectedIndex != -1);
        }
        private void menuAdd_Click(object sender, EventArgs e)
        {
            using (TaskEditForm dialog = new TaskEditForm())
            {
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    _tasks.Add(dialog.Task);
                    RefreshList();
                }
            }
        }
        private void menuCopy_Click(object sender, EventArgs e)
        {
            Task task = _tasks.Get(lstTasks.SelectedIndex);
            _tasks.Add(task.Name, task.Date, task.TaskType, task.RemindStart);
            RefreshList();
        }
        private void menuDelete_Click(object sender, EventArgs e)
        {
            _tasks.Delete(lstTasks.SelectedIndex);
            RefreshList();
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lstTasks_DoubleClick(object sender, EventArgs e)
        {
            if (lstTasks.SelectedIndex != -1)
            {
                using (TaskEditForm dialog = new TaskEditForm())
                {
                    dialog.Task = _tasks.Get(lstTasks.SelectedIndex);
                    if (dialog.ShowDialog(this) == DialogResult.OK)
                    {
                        _tasks.Set(lstTasks.SelectedIndex, dialog.Task);
                        RefreshList();
                    }
                }
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (this.WindowState == FormWindowState.Minimized) this.Hide();
        }
        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowForm();
        }
    }
}
