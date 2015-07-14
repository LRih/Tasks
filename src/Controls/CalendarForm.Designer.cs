namespace Tasks
{
    partial class CalendarForm
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
            this.calendar = new Calendar();
            this.SuspendLayout();
            // 
            // calendar
            // 
            this.calendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calendar.Location = new System.Drawing.Point(0, 0);
            this.calendar.Name = "calendar";
            this.calendar.Size = new System.Drawing.Size(484, 361);
            this.calendar.TabIndex = 0;
            // 
            // CalendarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.calendar);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "CalendarForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calendar";
            this.ResumeLayout(false);

        }

        #endregion

        private Calendar calendar;
    }
}