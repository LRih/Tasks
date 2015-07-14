using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;

namespace Tasks
{
    public class Calendar : Control
    {
        //===================================================================== CONSTANTS
        private const int ROWS = 6;
        private const int COLUMNS = 7;

        private static readonly Color _colFill = Color.White;
        private static readonly Color _colFillToday = Color.FromArgb(210, 230, 255);
        private static readonly Color _colFillHoliday = Color.FromArgb(255, 215, 170);

        //===================================================================== VARIABLES
        private Tasks _tasks = new Tasks();

        private int _selectedYear;
        private int _selectedMonth;

        //===================================================================== INITIALIZE
        public Calendar()
        {
            this.DoubleBuffered = true;

            _selectedMonth = DateTime.Now.Month;
            _selectedYear = DateTime.Now.Year;
        }

        //===================================================================== FUNCTIONS
        public void PreviousMonth()
        {
            DateTime datePrev = new DateTime(_selectedYear, _selectedMonth, 1).AddMonths(-1);

            _selectedMonth = datePrev.Month;
            _selectedYear = datePrev.Year;

            this.Invalidate();
        }
        public void NextMonth()
        {
            DateTime dateNext = new DateTime(_selectedYear, _selectedMonth, 1).AddMonths(1);

            _selectedMonth = dateNext.Month;
            _selectedYear = dateNext.Year;

            this.Invalidate();
        }

        private Rectangle GetDayHeaderRect(int day)
        {
            int left = (day * ClientSize.Width) / COLUMNS;
            int right = ((day + 1) * ClientSize.Width) / COLUMNS;
            return new Rectangle(left, TitleHeight, right - left, HeaderHeight);
        }
        private Rectangle GetDateRect(Point coord)
        {
            int left = (coord.X * ClientSize.Width) / COLUMNS;
            int right = ((coord.X + 1) * ClientSize.Width) / COLUMNS;
            int top = (coord.Y * TableHeight) / ROWS;
            int bottom = ((coord.Y + 1) * TableHeight) / ROWS;
            return new Rectangle(left, TableTop + top, right - left, bottom - top);
        }

        private DateTime? GetDate(Point coord, int month, int year)
        {
            int day = GetDay(coord, month, year);
            if (day < 1 || day > DateTime.DaysInMonth(year, month)) return null;
            else return new DateTime(year, month, day);
        }
        private int GetDay(Point coord, int month, int year)
        {
            int id = coord.Y * COLUMNS + coord.X;
            int firstDayOfMonth = (int)new DateTime(year, month, 1).DayOfWeek;
            return id - firstDayOfMonth + 1;
        }

        private Color GetFillColor(Point coord, int month, int year)
        {
            DateTime? date = GetDate(coord, month, year);
            if (date == null) return this.BackColor;
            else if (date == DateTime.Today) return _colFillToday;
            else if (coord.X >= 1 && coord.X <= 5) return _colFill;
            else return _colFillHoliday;
        }
        private Color GetTaskColor(Task task)
        {
            switch (task.TaskType)
            {
                case Task.Type.Appointment: return Color.FromArgb(80, 170, 50);
                case Task.Type.Assignment: return Color.FromArgb(225, 50, 50);
                case Task.Type.Deadline: return Color.FromArgb(50, 170, 80);
                case Task.Type.School: return Color.FromArgb(80, 50, 200);
                default: return Color.FromArgb(51, 51, 51);
            }
        }

        //===================================================================== PROPERTIES
        public Tasks Tasks
        {
            set
            {
                _tasks = value;
                this.Invalidate();
            }
        }

        private int TitleHeight
        {
            get { return 40; }
        }
        private int HeaderHeight
        {
            get { return 30; }
        }
        private int TableTop
        {
            get { return TitleHeight + HeaderHeight; }
        }
        private int TableHeight
        {
            get { return ClientSize.Height - TitleHeight - HeaderHeight; }
        }

        //===================================================================== EVENTS
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            DrawCalendar(e.Graphics, new DateTime(_selectedYear, _selectedMonth, 1));
        }
        private void DrawCalendar(Graphics g, DateTime date)
        {
            DrawMonthName(g, date.Month, date.Year);
            DrawDaysOfWeek(g);
            DrawDays(g, date.Month, date.Year);
        }

        private void DrawMonthName(Graphics g, int month, int year)
        {
            string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month) + ", " + year;
            Rectangle rect = new Rectangle(0, 0, ClientSize.Width, TitleHeight);
            using (SolidBrush brush = new SolidBrush(_colFill))
                g.FillRectangle(brush, rect);
            DrawText(g, monthName, this.Font, rect, this.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }
        private void DrawDaysOfWeek(Graphics g)
        {
            using (SolidBrush brush = new SolidBrush(_colFill))
            {
                for (int day = 0; day < COLUMNS; day++)
                {
                    string dayName = CultureInfo.CurrentCulture.DateTimeFormat.GetDayName((DayOfWeek)day);
                    Rectangle rect = GetDayHeaderRect(day);
                    g.FillRectangle(brush, rect);
                    DrawText(g, dayName, this.Font, rect, this.ForeColor, TextFormatFlags.EndEllipsis | TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                }
            }
        }

        private void DrawDays(Graphics g, int month, int year)
        {
            for (int y = 0; y < ROWS; y++)
                for (int x = 0; x < COLUMNS; x++)
                    DrawDay(g, new Point(x, y), month, year);
        }
        private void DrawDay(Graphics g, Point coord, int month, int year)
        {
            DrawDayBackground(g, coord, month, year);
            DrawDayForeground(g, coord, month, year);
        }
        private void DrawDayBackground(Graphics g, Point coord, int month, int year)
        {
            using (SolidBrush brush = new SolidBrush(GetFillColor(coord, month, year)))
                g.FillRectangle(brush, GetDateRect(coord));
        }
        private void DrawDayForeground(Graphics g, Point coord, int month, int year)
        {
            Rectangle rect = GetDateRect(coord);
            DateTime? date = GetDate(coord, month, year);
            if (date != null)
            {
                // draw date number
                DrawText(g, date.Value.Day.ToString(), this.Font, new Point(rect.X + 5, rect.Y + 5), this.ForeColor);

                // draw entries
                List<Task> tasks = _tasks.GetTasksOn(date.Value);
                int height = this.Font.Height + 4;
                for (int i = 0; i < tasks.Count; i++)
                {
                    int y = rect.Y + 20 + height * i;
                    Rectangle entryRect = new Rectangle(rect.X + 2, y, rect.Width - 4, height);
                    FillRoundedRectangle(g, entryRect, 6, GetTaskColor(tasks[i]));
                    DrawText(g, tasks[i].Name, this.Font, entryRect, Color.White, TextFormatFlags.EndEllipsis | TextFormatFlags.VerticalCenter);
                }
            }
        }

        private void FillRoundedRectangle(Graphics g, Rectangle rect, int radius, Color color)
        {
            using (SolidBrush brush = new SolidBrush(color))
            using (GraphicsPath path = GetRoundedRectanglePath(rect, radius))
                g.FillPath(brush, path);
        }
        private GraphicsPath GetRoundedRectanglePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddLine(rect.Left + radius, rect.Top, rect.Right - radius, rect.Top);
            path.AddArc(rect.Right - radius, rect.Top, radius, radius, 270, 90);
            path.AddLine(rect.Right, rect.Top + radius, rect.Right, rect.Bottom - radius);
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
            path.AddLine(rect.Right - radius, rect.Bottom, rect.Left + radius, rect.Bottom);
            path.AddArc(rect.Left, rect.Bottom - radius, radius, radius, 90, 90);
            path.AddLine(rect.Left, rect.Bottom - radius, rect.Left, rect.Top + radius);
            path.AddArc(rect.Left, rect.Top, radius, radius, 180, 90);
            path.CloseFigure();
            return path;
        }
        private void DrawText(Graphics g, string s, Font font, Point point, Color color)
        {
            using (SolidBrush brush = new SolidBrush(color)) g.DrawString(s, font, brush, point);
        }
        private void DrawText(Graphics g, string s, Font font, Rectangle rect, Color color, TextFormatFlags flags = TextFormatFlags.Default)
        {
            StringFormat format = new StringFormat();
            format.FormatFlags = StringFormatFlags.NoWrap;
            if (flags.HasFlag(TextFormatFlags.HorizontalCenter)) format.Alignment = StringAlignment.Center;
            if (flags.HasFlag(TextFormatFlags.VerticalCenter)) format.LineAlignment = StringAlignment.Center;
            if (flags.HasFlag(TextFormatFlags.EndEllipsis)) format.Trimming = StringTrimming.EllipsisCharacter;
            using (SolidBrush brush = new SolidBrush(color))
            {
                g.DrawString(s, font, brush, rect, format);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            this.Invalidate();
            base.OnResize(e);
        }
    }
}
