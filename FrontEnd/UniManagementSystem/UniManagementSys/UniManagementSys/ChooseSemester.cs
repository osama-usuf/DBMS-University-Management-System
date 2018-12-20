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
    public partial class ChooseSemester : Form
    {
        string id;
        public ChooseSemester()
        {
            InitializeComponent();
            
        }

        private void ChooseSemester_Load(object sender, EventArgs e)
        {
            DbConnection load = new DbConnection();
            DataTable temp = load.Select("select * from semester S, Student_Semester_Enrolment SS where SS.Semester_SemesterID = S.SemesterID and SS.Student_StudentID =" + Variables.sid);
            temp.Columns.Add("Namer", typeof(string), "Name + '  ' + Year");
            comboBox1.DataSource = temp;
            comboBox1.DisplayMember = "Namer";
            comboBox1.ValueMember = "S.SemesterID";
            comboBox1.Text = "Please Select a Semester to see Courses!";
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            DbConnection load = new DbConnection();
            string query = "select * from Course where CourseID in (select CO.Course_CourseID from CourseOffering CO where CO.CourseOfferingID in (select CS.CourseOffering_CourseOfferingID from CourseSection CS where CS.CourseSectionID in (select CourseSection_CourseSectionID from Student_Course_Enrolment where SemesterGradeReport_Student_Semester_Enrolment_Semester_SemesterID ="+ comboBox1.ValueMember+"  and Student_StudentID = "+ Variables.sid+")))";
            DataTable temp = load.Select(query);
            if (temp.Rows.Count != 0)
            {
                temp.Columns.Add("FullName", typeof(string), "CourseID + ': ' + Name");
                listBox1.DataSource = temp;
                listBox1.DisplayMember = "FullName";
                listBox1.ValueMember = "CourseID";
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ChooseSemester_Load(sender, e);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DbConnection load = new DbConnection();
            string query = "select C.CourseID, C.[Name], CS.CourseSectionID  from Course C ,CourseOffering CO ,CourseSection CS where C.CourseID = CO.Course_CourseID and CO.CourseOfferingID = CS.CourseOffering_CourseOfferingID and CS.CourseSectionID in (select CourseSection_CourseSectionID from Student_Course_Enrolment where SemesterGradeReport_Student_Semester_Enrolment_Semester_SemesterID = 8 and Student_StudentID = "+Variables.sid+")";
            DataTable temp = load.Select(query);
            if (temp.Rows.Count != 0)
            {
                temp.Columns.Add("FullName", typeof(string), "CourseID + ': ' + Name");
                listBox1.ValueMember = "CourseSectionID ";
                listBox1.DisplayMember = "FullName";
                listBox1.DataSource = temp;
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataRowView r = (DataRowView)listBox1.SelectedItem;
            id = r["CourseSectionID"].ToString();
            
            
            Grade grade = new Grade(id);
            grade.Show();
            this.Hide();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            id = listBox1.ValueMember;
        }
    }
}
