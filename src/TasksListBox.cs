using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tasks
{
    public class TasksListBox : ListBox
    {
        //===================================================================== CONSTANTS
        private const int MARKER_WIDTH = 6;
        private const int TIME_WIDTH = 55;
        private const int CELL_SPACING = 10;
        private const int ITEM_PADDING = 6;

        //===================================================================== INITIALIZE
        public TasksListBox()
        {
            this.BorderStyle = BorderStyle.None;
            this.DoubleBuffered = true;
            this.DrawMode = DrawMode.OwnerDrawVariable;
            this.IntegralHeight = false;
        }

        //===================================================================== FUNCTIONS
        private Color GetItemBackColor(Task task, bool isSelected)
        {
            if (isSelected) return Color.FromArgb(215, 240, 240);
            else if (task.IsDue) return Color.FromArgb(255, 225, 240);
            else if (task.IsRemindRequired) return Color.FromArgb(255, 255, 190);
            else return this.BackColor;
        }
        private Color GetItemForeColor(Task task)
        {
            switch (task.TaskType)
            {
                case Task.Type.Appointment: return Color.FromArgb(80, 170, 50);
                case Task.Type.Assignment: return Color.FromArgb(225, 50, 50);
                case Task.Type.Deadline: return Color.FromArgb(50, 170, 80);
                case Task.Type.School: return Color.FromArgb(80, 50, 200);
                default: return this.ForeColor;
            }
        }
        private Color GetMarkerColor(Task task)
        {
            if (task.IsDue) return Color.IndianRed;
            else if (task.IsRemindRequired) return Color.Orange;
            else return Color.Transparent;
        }
        private string GetItemName(Task task)
        {
            long absDays = Math.Abs(task.DaysUntilNow);
            if (absDays == 0) return "Today";
            else if (absDays < 2 * 7) return task.DaysUntilNow + " d";
            else if (absDays < 2 * 30) return task.DaysUntilNow / 7 + " wk";
            else if (absDays < 2 * 365) return task.DaysUntilNow / 30 + " mth";
            else return task.DaysUntilNow / 365 + " yr";
        }

        //===================================================================== EVENTS
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);

            if (e.Index != -1 && e.Index < Items.Count)
            {
                Task task = (Task)this.Items[e.Index];

                // draw background
                using (Brush brush = new SolidBrush(GetItemBackColor(task, e.State.HasFlag(DrawItemState.Selected))))
                    e.Graphics.FillRectangle(brush, e.Bounds);

                // draw marker
                using (Brush brush = new SolidBrush(GetMarkerColor(task)))
                    e.Graphics.FillRectangle(brush, e.Bounds.X, e.Bounds.Y, MARKER_WIDTH, e.Bounds.Height);

                DrawItemText(task, e);
            }
        }
        private void DrawItemText(Task task, DrawItemEventArgs e)
        {
            Color col = GetItemForeColor(task);

            Rectangle rect = e.Bounds;
            rect.X += MARKER_WIDTH;
            rect.Width = TIME_WIDTH;
            TextRenderer.DrawText(e.Graphics, GetItemName(task), this.Font, rect, col, TextFormatFlags.Right | TextFormatFlags.VerticalCenter);

            rect = e.Bounds;
            rect.X += MARKER_WIDTH + TIME_WIDTH + CELL_SPACING;
            rect.Width -= MARKER_WIDTH - TIME_WIDTH - CELL_SPACING;
            TextRenderer.DrawText(e.Graphics, task.Name, this.Font, rect, col, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
        }


        protected override void OnMeasureItem(MeasureItemEventArgs e)
        {
            base.OnMeasureItem(e);
            e.ItemHeight = this.Font.Height + ITEM_PADDING;
        }

        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            if (Parent != null) this.BackColor = Parent.BackColor;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            int index = IndexFromPoint(e.X, e.Y);
            if (index < Items.Count) SelectedIndex = index;
        }
    }
}
