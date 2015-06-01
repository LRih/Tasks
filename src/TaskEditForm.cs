using System;
using System.Windows.Forms;

namespace Tasks
{
    public partial class TaskEditForm : Form
    {
        //===================================================================== INITIALIZE
        public TaskEditForm()
        {
            InitializeComponent();

            foreach (Task.Type type in Enum.GetValues(typeof(Task.Type)))
                comType.Items.Add(type);
            comType.SelectedIndex = comType.Items.Count - 1;
        }
        private void TaskEditForm_Load(object sender, EventArgs e)
        {
            this.Font = Owner.Font;
        }

        //===================================================================== PROPERTIES
        public Task Task
        {
            get
            {
                return new Task(
                    txtName.Text.Replace(SaveManager.DELIM.ToString(), ""),
                    datePicker.Value.Date,
                    (Task.Type)comType.SelectedItem,
                    (int)numRemindStart.Value);
            }
            set
            {
                txtName.Text = value.Name;
                datePicker.Value = value.Date;
                comType.SelectedItem = value.TaskType;
                numRemindStart.Value = value.RemindStart;
            }
        }

        //===================================================================== EVENTS
        private void TaskEditForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
