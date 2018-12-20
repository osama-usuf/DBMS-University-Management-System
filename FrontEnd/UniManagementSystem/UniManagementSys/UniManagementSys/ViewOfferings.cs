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
    public partial class ViewOfferings : Form
    {
        public ViewOfferings()
        {
            InitializeComponent();
        }

        private void ViewOfferings_Load(object sender, EventArgs e)
        {
            DbConnection load = new DbConnection();
            DataTable temp = load.Select("SELECT * FROM Course;");
            temp.Columns.Add("FullName", typeof(string), "CourseID + ': ' + Name");
            comboBox1.DataSource = temp;
            comboBox1.DisplayMember = "FullName";
            comboBox1.ValueMember = "CourseID";
            comboBox1.Text = "Please Select a Course to see Details!";
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void comboBox1_DropDownClosed_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue == null) return;
            //Dept Field
            DbConnection load = new DbConnection();
            string query = "SELECT Department.[Name] FROM Course, Department WHERE Course.Department_DepartmentID = Department.DepartmentID AND CourseID = '" + comboBox1.SelectedValue + "';";
            DataTable temp = load.Select(query);
            textBox1.Text = temp.Rows[0][0].ToString();


            query = "SELECT SemesterID,Semester.Name,Semester.Year FROM CourseOffering,Course,Semester WHERE SemesterID = Semester_SemesterID AND CourseID = Course_CourseID AND Course_CourseID = '"+comboBox1.SelectedValue+"' ORDER BY Semester.Year";
            temp = load.Select(query);
            temp.Columns.Add("FullName", typeof(string), "Name + ' ' + Year");
            listBox1.DataSource = temp;
            listBox1.DisplayMember = "FullName";
            listBox1.ValueMember = "SemesterID";


        }

        private void comboBox1_KeyDown_1(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
    }
}
