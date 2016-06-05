using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dotNET_HW2
{
    public partial class Dialog : Form
    {
        public DataGridView MainDataGridView { get; set; }
        public bool isMainGridChanged { get; private set; }

        private HW2LINQ2SQLDataContext db = new HW2LINQ2SQLDataContext();
        private ErrorProvider ep = new ErrorProvider();
        private Button selectedControl;

        public Dialog() { InitializeComponent(); }

        private void FillComboBoxData()
        {
            comboBox1.DataSource =
                from s in db.TblStudents
                select new ComboBoxInnerType { Id = s.Id, Name = s.Name};
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Validate(); isMainGridChanged = true;

            if (selectedControl == buttonA)
            {
                MainDataGridView.DataSource =
                    from l in db.TblLecturers
                    join lc in db.TblCourseLecturers on l.Id equals lc.idLecturer
                    join c in db.TblCourses on lc.idCourse equals c.Id
                    where l.Id == Convert.ToInt32(textBox1.Text)
                    select c;
            }
            else if (selectedControl == buttonB)
            {
                MainDataGridView.DataSource =
                    from s in db.TblStudents
                    group s by s.Name into g
                    select new { Name = g.FirstOrDefault().Name };

            }
            else if (selectedControl == buttonC)
            {
                MainDataGridView.DataSource =
                    from s in db.TblStudents
                    join sc in db.TblStudentCourses on s.Id equals sc.idStudent
                    group sc by sc.idStudent into g
                    select new {
                        Id = g.FirstOrDefault().TblStudent.Id,
                        Name = g.FirstOrDefault().TblStudent.Name,
                        Count = g.Count()
                    };
            }
            else if (selectedControl == buttonD)
            {
                MainDataGridView.DataSource =
                    from s in db.TblStudents
                    select new { Id = s.Id, Name = s.Name, Age = DateTime.Now.Year - s.Birthday.Year };
            }
            else { isMainGridChanged = false; }
            this.Dispose();
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            MainDataGridView.DataSource =
                from s in db.TblStudents
                join sc in db.TblStudentCourses on s.Id equals sc.idStudent
                join c in db.TblCourses on sc.idCourse equals c.Id
                join lc in db.TblCourseLecturers on c.Id equals lc.idCourse
                join l in db.TblLecturers on lc.idLecturer equals l.Id
                where s.Id == ((ComboBoxInnerType)comboBox1.SelectedItem).Id
                select new { LecturerId = l.Id, LecturerName = l.Name };
            this.Dispose();
        }

        private void buttonA_Click(object sender, EventArgs e)
        {
            selectedControl = buttonA;
            textBox1.Enabled = true;
            textBox1.Text = "Please enter Lecturer Id here...";
            textBox1.Focus();
            textBox1.SelectAll();
        }

        private void buttonB_Click(object sender, EventArgs e) { selectedControl = buttonB; }

        private void buttonC_Click(object sender, EventArgs e) { selectedControl = buttonC; }

        private void buttonD_Click(object sender, EventArgs e) { selectedControl = buttonD; }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int input = Convert.ToInt32(textBox1.Text);
                if (input < 0)
                {
                    ep.SetError(textBox1, "Only positive numbers allowed");
                    e.Cancel = true;
                }
                else
                {
                    ep.SetError(textBox1, string.Empty);
                }
            }
            catch (Exception ex)
            {
                ep.SetError(textBox1, "Only numbers allowed.");
                e.Cancel = true;
            }
        }

        private class ComboBoxInnerType
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public override string ToString() { return string.Format("{0} {1}", Id, Name); }
        }

        private void Dialog_Load(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(buttonA, "Show Lecturer Courses");
            toolTip.SetToolTip(buttonB, "Show DeDuplicated Student Names");
            toolTip.SetToolTip(buttonC, "Show Students Courses Count");
            toolTip.SetToolTip(buttonD, "Show Students Ages");
            toolTip.SetToolTip(comboBox1, "Show Students Lecturers");
            toolTip.SetToolTip(buttonOK, "Submit Dialog ");
            FillComboBoxData();
        }
    }
}
