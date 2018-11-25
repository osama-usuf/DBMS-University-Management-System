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
    public partial class ViewCourse : Form
    {
        public ViewCourse()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CourseDetails_Load(object sender, EventArgs e)
        {
            DbConnection load = new DbConnection();
            DataTable temp = load.Select("SELECT * FROM Course;");
            temp.Columns.Add("FullName", typeof(string), "CourseID + ': ' + Name");
            comboBox1.DataSource = temp;
            comboBox1.DisplayMember = "FullName";
            comboBox1.ValueMember = "CourseID";
            comboBox1.Text = "Please Select a Course to see Details!";
            
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            if(comboBox1.SelectedValue == null) return;
            //Dept Field
            DbConnection load = new DbConnection();
            string query = "SELECT Department.[Name] FROM Course, Department WHERE Course.Department_DepartmentID = Department.DepartmentID AND CourseID = '" + comboBox1.SelectedValue + "';";
            DataTable temp = load.Select(query);
            textBox1.Text = temp.Rows[0][0].ToString();
            //Cr hours
            query = "SELECT [Credit Hours] FROM Course WHERE CourseID = '" + comboBox1.SelectedValue + "';";
            temp = load.Select(query);
            textBox2.Text = temp.Rows[0][0].ToString();
            //Description
            query = "SELECT [Description] FROM Course WHERE CourseID = '" + comboBox1.SelectedValue + "';";
            temp = load.Select(query);
            richTextBox1.Text = temp.Rows[0][0].ToString();
            //PreReqs
            query = "SELECT CourseID, [Name] FROM Course WHERE CourseID IN (SELECT Course_PreReqID FROM Course, Course_Prereq WHERE Course.CourseID = Course_Prereq.Course_CourseID AND CourseID = '" + comboBox1.SelectedValue + "');";
            temp = load.Select(query);
            temp.Columns.Add("FullName", typeof(string), "CourseID + ': ' + Name");
            listBox1.DataSource = temp;
            listBox1.DisplayMember = "FullName";
            listBox1.ValueMember = "CourseID";
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
    }
}
