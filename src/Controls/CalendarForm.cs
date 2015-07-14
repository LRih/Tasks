using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Tasks
{
    public partial class CalendarForm : Form
    {
        //===================================================================== INITIALIZE
        public CalendarForm()
        {
            InitializeComponent();
        }

        //===================================================================== PROPERTIES
        public Tasks Tasks
        {
            set { calendar.Tasks = value; }
        }

        //===================================================================== EVENTS
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.F12)
                this.Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData & Keys.KeyCode)
            {
                case Keys.Left: calendar.PreviousMonth(); return true;
                case Keys.Right: calendar.NextMonth(); return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
