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
    public partial class StudentPortal : Form
    {
        public StudentPortal()
        {            
            InitializeComponent();
        }

        private void StudentPortal_Load(object sender, EventArgs e)
        {
                DbConnection load = new DbConnection();
                if (Variables.sid == null) return;
                string query = "SELECT * FROM Student, [Address] WHERE Address_AddressID = AddressID AND StudentID = " + Variables.sid;
                DataTable temp = load.Select(query);
                if (temp.Rows.Count == 0) return;
                textBox9.Text = temp.Rows[0][2].ToString();

                query = "SELECT DepartmentID, Department.[Name], IsMajorDept FROM Student, Student_Department, Department WHERE StudentID = Student_StudentID AND Department_DepartmentID = DepartmentID AND StudentID =" + Variables.sid + " ORDER BY IsMajorDept DESC";
                temp = load.Select(query);

                textBox3.Text = temp.Rows[0][1].ToString();
                if (temp.Rows.Count > 1)
                {
                    checkBox1.Checked = true;
                    textBox1.Text = temp.Rows[1][1].ToString();
                }
                else
                {
                    checkBox1.Checked = false;
                    textBox1.Text = "";
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            PersonalDetails pd = new PersonalDetails();
            pd.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ViewStudentPortalSemester vsps = new ViewStudentPortalSemester();
            vsps.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Grade g = new Grade();
            g.Show(); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StudentPortal_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
