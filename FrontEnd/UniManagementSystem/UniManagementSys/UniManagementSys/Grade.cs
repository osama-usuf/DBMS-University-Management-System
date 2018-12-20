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
    public partial class Grade : Form
    {
        string id;
        public Grade()
        {
            InitializeComponent();
        }
        public Grade(string id)
        {
            InitializeComponent();
            this.id = id;
        }


        private void Grade_Load(object sender, EventArgs e)
        {
            DbConnection load = new DbConnection();
            DataTable temp = load.Select("SELECT * FROM Course;");
            if (temp.Rows.Count == 0) return;
            temp.Columns.Add("FullName", typeof(string), "CourseID + ': ' + Name");
            comboBox1.DataSource = temp;
            comboBox1.DisplayMember = "FullName";
            comboBox1.ValueMember = "CourseID";
            comboBox1.Text = "Please Select a Course";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue == null) return;
            //Dept Field
            DbConnection load = new DbConnection();
            string query = "select c.[Name], f.[Name], d.[Name], c.[Credit Hours], sce.[GPA] from student_course_enrolment sce,coursesection cs, department d,course c, faculty f, faculty_department fd where f.facultyID = fd.faculty_facultyID and fd.department_departmentID = c.department_departmentID and c.department_departmentID = d.departmentID and cs.faculty_facultyID = f.facultyID and c.courseID like '" + comboBox1.SelectedValue + "' and sce.coursesection_coursesectionID = cs.coursesectionID and sce.student_studentID ='" + Variables.sid + "';";
            DataTable temp = load.Select(query);
            //textBox3.Text = temp.Rows[0][0].ToString();
            //Cr hours
            if (temp.Rows.Count == 0) return;
            textBox3.Text = temp.Rows[0][2].ToString();
            textBox4.Text = temp.Rows[0][3].ToString();
            //grade
            textBox5.Text = temp.Rows[0][4].ToString();
            //faculty
            textBox2.Text = temp.Rows[0][1].ToString();
        }
    }
}
