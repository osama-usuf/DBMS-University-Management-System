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
    public partial class FacultySemester : Form
    {
        public FacultySemester()
        {
            InitializeComponent();
        }

        private void FacultySemester_Load(object sender, EventArgs e)
        {
            DbConnection load = new DbConnection();
            string query = "EXEC FacultySemesterSearch "+Variables.fid;
            DataTable temp = load.Select(query);
            temp.Columns.Add("FullName", typeof(string), "Name + ' - ' + [Year]");
            comboBox2.DataSource = temp;
            comboBox2.DisplayMember = "FullName";
            comboBox2.ValueMember = "SemesterID";
            comboBox2.Text = "";

        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void comboBox2_DropDownClosed(object sender, EventArgs e)
        {
            textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = ""; textBox4.Text = "";
            comboBox3.Text = ""; comboBox3.DataSource = null;
            if (comboBox2.SelectedValue == null) return;
            string query = "EXEC FacultySemCourseSearch "+Variables.fid+", "+comboBox2.SelectedValue;
            DbConnection load = new DbConnection();
            DataTable temp = load.Select(query);
            temp.Columns.Add("FullName", typeof(string), "CourseID + ' : ' + [Name]");
            comboBox1.DataSource = temp;
            comboBox1.DisplayMember = "FullName";
            comboBox1.ValueMember = "CourseID";
            comboBox1.Text = "";
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = ""; textBox4.Text = "";
            comboBox3.Text = ""; comboBox3.DataSource = null;
            if (comboBox1.SelectedValue == null) return;
            string query = "SELECT * FROM CourseOffering WHERE Semester_SemesterID = "+comboBox2.SelectedValue+" AND Course_CourseID = '" + comboBox1.SelectedValue + "'";
            DbConnection load = new DbConnection();
            DataTable temp = load.Select(query);
            textBox1.Text = temp.Rows[0][0].ToString();

            query = "SELECT * FROM CourseSection WHERE Faculty_FacultyID = "+Variables.fid+" AND CourseOffering_CourseOfferingID = "+textBox1.Text;
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
            
            query = "SELECT * FROM Course WHERE CourseID = '"+comboBox1.SelectedValue+"'";
            temp = load.Select(query);
            if (temp.Rows.Count == 0) return;
            textBox4.Text = temp.Rows[0][4].ToString();


        }

        private void comboBox3_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void comboBox3_DropDownClosed(object sender, EventArgs e)
        {
            if (comboBox3.SelectedValue == null) return;
            string query = "SELECT * FROM CourseSection WHERE CourseSectionID = " + comboBox3.SelectedValue;
            DbConnection load = new DbConnection();
            DataTable temp = load.Select(query);
            if (temp.Rows.Count == 0) return;
            textBox2.Text = temp.Rows[0][3].ToString();
            textBox3.Text = temp.Rows[0][4].ToString();

            //query = "SELECT * FROM Student_Course_Enrolment, Student WHERE Student_StudentID = StudentID AND CourseSection_CourseSectionID = " + comboBox3.SelectedValue;
            query = "SELECT * FROM Student,(SELECT Student_StudentID FROM Student_Course_Enrolment WHERE  CourseSection_CourseSectionID = " + comboBox3.SelectedValue + ") AS TEMP WHERE StudentID = Student_StudentID";
            load = new DbConnection();
            temp = load.Select(query);
            if (temp.Rows.Count == 0) return;
            temp.Columns.Add("FullName", typeof(string), "StudentID + ' - ' + [Name]");
            listBox1.DataSource = temp;
            listBox1.DisplayMember = "FullName";
            listBox1.ValueMember = "StudentID";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {
                //MessageBox.Show(listBox1.SelectedValue.ToString());
                string query = "SELECT * FROM Student_Course_Enrolment WHERE Student_StudentID = " + listBox1.SelectedValue.ToString() + " AND CourseSection_CourseSectionID = " + comboBox3.SelectedValue;
                DbConnection load = new DbConnection();
                DataTable temp = load.Select(query);
                textBox5.Text = temp.Rows[0][2].ToString();
            }
            catch (Exception)
            {
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDouble(textBox5.Text) < 0 || Convert.ToDouble(textBox5.Text) > 4.0)
                {
                    MessageBox.Show("Invalid grade entered. Valid range [0.0,4.0]");
                    return;
                }
                string stID = listBox1.SelectedValue.ToString();
                string query = "UPDATE Student_Course_Enrolment SET GPA = " + textBox5.Text + " WHERE Student_StudentID = " + stID + " AND CourseSection_CourseSectionID = " + comboBox3.SelectedValue;
                DbConnection add = new DbConnection();
                add.Inserts(query);
                MessageBox.Show("Grade updated.");
            }
            catch(Exception)
            {
                MessageBox.Show("Exception caught! Be careful.");
            }
        }

        private void listBox1_ValueMemberChanged(object sender, EventArgs e)
        {

        }
    }
}
