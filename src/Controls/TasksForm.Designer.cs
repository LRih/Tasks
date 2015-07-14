namespace Tasks
{
    partial class TasksForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TasksForm));
            this.menuList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.lstTasks = new TasksListBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuNotify = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuList.SuspendLayout();
            this.menuNotify.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuList
            // 
            this.menuList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAdd,
            this.menuCopy,
            this.menuDelete});
            this.menuList.Name = "menuList";
            this.menuList.Size = new System.Drawing.Size(108, 70);
            this.menuList.Opening += new System.ComponentModel.CancelEventHandler(this.menuList_Opening);
            // 
            // menuAdd
            // 
            this.menuAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.menuAdd.Name = "menuAdd";
            this.menuAdd.Size = new System.Drawing.Size(107, 22);
            this.menuAdd.Text = "Add";
            this.menuAdd.Click += new System.EventHandler(this.menuAdd_Click);
            // 
            // menuCopy
            // 
            this.menuCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.menuCopy.Name = "menuCopy";
            this.menuCopy.Size = new System.Drawing.Size(107, 22);
            this.menuCopy.Text = "Copy";
            this.menuCopy.Click += new System.EventHandler(this.menuCopy_Click);
            // 
            // menuDelete
            // 
            this.menuDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.menuDelete.Name = "menuDelete";
            this.menuDelete.Size = new System.Drawing.Size(107, 22);
            this.menuDelete.Text = "Delete";
            this.menuDelete.Click += new System.EventHandler(this.menuDelete_Click);
            // 
            // lstTasks
            // 
            this.lstTasks.BackColor = System.Drawing.Color.White;
            this.lstTasks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstTasks.ContextMenuStrip = this.menuList;
            this.lstTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstTasks.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.lstTasks.FormattingEnabled = true;
            this.lstTasks.IntegralHeight = false;
            this.lstTasks.ItemHeight = 24;
            this.lstTasks.Location = new System.Drawing.Point(0, 0);
            this.lstTasks.Margin = new System.Windows.Forms.Padding(5);
            this.lstTasks.Name = "lstTasks";
            this.lstTasks.Size = new System.Drawing.Size(234, 311);
            this.lstTasks.TabIndex = 0;
            this.lstTasks.DoubleClick += new System.EventHandler(this.lstTasks_DoubleClick);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.menuNotify;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Tasks";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // menuNotify
            // 
            this.menuNotify.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuExit});
            this.menuNotify.Name = "menuNotify";
            this.menuNotify.Size = new System.Drawing.Size(93, 26);
            // 
            // menuExit
            // 
            this.menuExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(92, 22);
            this.menuExit.Text = "Exit";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // TasksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(234, 311);
            this.Controls.Add(this.lstTasks);
            this.Font = new System.Drawing.Font("Meiryo", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "TasksForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Tasks";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.menuList.ResumeLayout(false);
            this.menuNotify.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TasksListBox lstTasks;
        private System.Windows.Forms.ContextMenuStrip menuList;
        private System.Windows.Forms.ToolStripMenuItem menuAdd;
        private System.Windows.Forms.ToolStripMenuItem menuCopy;
        private System.Windows.Forms.ToolStripMenuItem menuDelete;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip menuNotify;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
    }
}

