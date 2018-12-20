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
    public partial class ViewStudent : Form
    {
        public ViewStudent()
        {
            InitializeComponent();
        }

        private void ViewStudent_Load(object sender, EventArgs e)
        {
            DbConnection load = new DbConnection();
            string query = "SELECT * FROM Student";
            DataTable temp = load.Select(query);
            temp.Columns.Add("Student", typeof(string), "StudentID + ' : ' + [Name]");
            comboBox2.DataSource = temp;
            comboBox2.DisplayMember = "Student";
            comboBox2.ValueMember = "StudentID";
            comboBox2.Text = "Please Select...";
        }
        private void comboBox2_DropDownClosed(object sender, EventArgs e)
        {
            DbConnection load = new DbConnection();
            if (comboBox2.SelectedValue == null) return;
            string query = "SELECT * FROM Student, [Address] WHERE Address_AddressID = AddressID AND StudentID = " + comboBox2.SelectedValue;
            DataTable temp = load.Select(query);

            textBox3.Text = temp.Rows[0][3].ToString();
            textBox1.Text = temp.Rows[0][4].ToString();
            textBox10.Text = Convert.ToDateTime(temp.Rows[0][5]).ToString("dd/MM/yyyy");
            textBox8.Text = temp.Rows[0][6].ToString();

            textBox4.Text = temp.Rows[0][8].ToString();
            textBox5.Text = temp.Rows[0][9].ToString();
            textBox6.Text = temp.Rows[0][10].ToString();
            textBox7.Text = temp.Rows[0][11].ToString();

            query = "SELECT DepartmentID, Department.[Name], IsMajorDept FROM Student, Student_Department, Department WHERE StudentID = Student_StudentID AND Department_DepartmentID = DepartmentID AND StudentID =" + comboBox2.SelectedValue + " ORDER BY IsMajorDept DESC";
            temp = load.Select(query);

            textBox2.Text = temp.Rows[0][1].ToString();
            if (temp.Rows.Count > 1)
            {
                checkBox1.Checked = true;
                textBox11.Text = temp.Rows[1][1].ToString();
            }
            else
            {
                checkBox1.Checked = false;
                textBox11.Text = "";
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("ASD");
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox2_KeyDown_1(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
    }
}
    
