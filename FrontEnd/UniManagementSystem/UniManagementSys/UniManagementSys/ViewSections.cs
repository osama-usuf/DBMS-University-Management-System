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
    public partial class ViewSections : Form
    {
        public ViewSections()
        {
            InitializeComponent();
        }
        private void ViewSections_Load(object sender, EventArgs e)
        {
            DbConnection load = new DbConnection();
            DataTable temp = load.Select("SELECT * FROM Course;");
            temp.Columns.Add("FullName", typeof(string), "CourseID + ': ' + Name");
            comboBox1.DataSource = temp;
            comboBox1.DisplayMember = "FullName";
            comboBox1.ValueMember = "CourseID";
            comboBox1.Text = "Please Select a Course to see Details!";

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;

        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue == null) return;
            //Dept Field
            DbConnection load = new DbConnection();
            string query = "SELECT C.[Name] FROM Course C WHERE CourseID = '" + comboBox1.SelectedValue + "';";
            DataTable temp = load.Select(query);

            query = "SELECT SemesterID,Semester.Name,Semester.Year FROM CourseOffering,Course,Semester WHERE SemesterID = Semester_SemesterID AND CourseID = Course_CourseID AND Course_CourseID = '" + comboBox1.SelectedValue + "' ORDER BY Semester.Year";
            temp = load.Select(query);
            temp.Columns.Add("FullName", typeof(string), "Name + ' ' + Year");
            comboBox2.DataSource = temp;
            comboBox2.DisplayMember = "FullName";
            comboBox2.ValueMember = "SemesterID";
            comboBox2.Text = ""; comboBox3.Text = ""; comboBox3.DataSource = null;
            textBox2.Text = ""; textBox3.Text = ""; textBox4.Text = ""; textBox5.Text = "";


        }

        private void comboBox2_DropDownClosed(object sender, EventArgs e)
        {
            comboBox3.Text = ""; comboBox3.DataSource = null; textBox2.Text = ""; textBox3.Text = ""; textBox5.Text = "";
            if (comboBox2.SelectedValue == null) return;
            DbConnection load = new DbConnection();
            string query = "SELECT * from CourseOffering WHERE Semester_SemesterID = "+comboBox2.SelectedValue+" AND Course_CourseID = '"+comboBox1.SelectedValue+"'";
            DataTable temp = load.Select(query);
            if (temp.Rows.Count == 0) return;
            textBox4.Text = temp.Rows[0][0].ToString();

            query = "SELECT * FROM CourseSection WHERE CourseOffering_CourseOfferingID =" + textBox4.Text;
            temp = load.Select(query);
            if (temp.Rows.Count == 0) return;
            comboBox3.DataSource = temp;
            temp.Columns.Add("Name", typeof(string));
            int i = 1;
            foreach (DataRow row in temp.Rows)
            {
                row["Name"] = "L" + i.ToString();
                i++;
            }
            comboBox3.DisplayMember = "Name";
            comboBox3.ValueMember = "CourseSectionID";
            comboBox3.Text = ""; 
        }

        private void comboBox3_DropDownClosed(object sender, EventArgs e)
        {
            if (comboBox3.SelectedValue == null) return;
            DbConnection load = new DbConnection();
            string query = "SELECT * FROM CourseSection WHERE CourseOffering_CourseOfferingID = "+textBox4.Text+" AND CourseSectionID =" + comboBox3.SelectedValue;
            DataTable temp = load.Select(query);
            if (temp.Rows.Count == 0) return;
            textBox3.Text = temp.Rows[0][3].ToString();
            textBox5.Text = temp.Rows[0][4].ToString();
            query = "SELECT * FROM Faculty WHERE FacultyID = "+ temp.Rows[0][1].ToString(); ;
            temp = load.Select(query);
            if (temp.Rows.Count == 0) return;
            textBox2.Text = temp.Rows[0][2].ToString();

            /*
            //textBox1.Text = temp.Rows[0][0].ToString();
            //Cr hours
            query = "SELECT F.[Name] FROM Faculty F, CourseSection CS, CourseOffering CO WHERE CS.Faculty_FacultyID = F.FacultyID AND CS.CourseOffering_CourseOfferingID = CO.CourseOfferingID AND CO.Course_CourseID = '" + comboBox1.SelectedValue + "';";
            temp = load.Select(query);
           // textBox2.Text = temp.Rows[0][0].ToString();
            //Description
            query = "SELECT CS.[ClassCap] FROM CourseSection CS, CourseOffering CO WHERE  CS.CourseOffering_CourseOfferingID = CO.CourseOfferingID AND CO.Course_CourseID = '" + comboBox1.SelectedValue + "';";
            temp = load.Select(query);
           // textBox3.Text = temp.Rows[0][0].ToString();*/
        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void comboBox3_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
    }
}
