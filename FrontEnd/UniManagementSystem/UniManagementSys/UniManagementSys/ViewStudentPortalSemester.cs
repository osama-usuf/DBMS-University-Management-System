using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniManagementSys
{
    public partial class ViewStudentPortalSemester : Form
    {
        public ViewStudentPortalSemester()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ViewStudentPortalSemester_Load_1(object sender, EventArgs e)
        {
            DbConnection load = new DbConnection();
            DataTable temp = load.Select("SELECT * FROM Student_Semester_Enrolment, Semester WHERE SemesterID = Semester_SemesterID AND Student_StudentID = "+Variables.sid.ToString());
            if (temp.Rows.Count == 0) return;
            temp.Columns.Add("[Name]", typeof(string), "Semester_SemesterID + ': ' + [Name]");
            comboBox2.DataSource = temp;
            comboBox2.DisplayMember = "[Name]";
            comboBox2.ValueMember = "Semester_SemesterID";
            comboBox2.Text = "Please Select a Semester to see Details!";
        }

        private void comboBox2_DropDownClosed(object sender, EventArgs e)
        {
            if (comboBox2.SelectedValue == null) return;
            //Dept Field
            DbConnection load = new DbConnection();
            string query = "SELECT * FROM Semester, Student_Semester_Enrolment WHERE SemesterID = Semester_SemesterID AND semester_semesterID = " + comboBox2.SelectedValue + " AND student_studentID = " + Variables.sid ;
            DataTable temp = load.Select(query);
            if (temp.Rows.Count == 0) return;
            textBox3.Text = temp.Rows[0][5].ToString();
            textBox1.Text = temp.Rows[0][6].ToString();

        }
    }
}
