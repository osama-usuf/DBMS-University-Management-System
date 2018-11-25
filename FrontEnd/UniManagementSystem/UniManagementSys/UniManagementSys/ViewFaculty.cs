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
    public partial class ViewFaculty : Form
    {
        public ViewFaculty()
        {
            InitializeComponent();
        }

        private void ViewFaculty_Load(object sender, EventArgs e)
        {
            DbConnection load = new DbConnection();
            string query = "SELECT * FROM Faculty";
            DataTable temp = load.Select(query);
            temp.Columns.Add("Faculty", typeof(string), "FacultyID + ' : ' + [Name]");
            comboBox1.DataSource = temp;
            comboBox1.DisplayMember = "Faculty";
            comboBox1.ValueMember = "FacultyID";
            comboBox1.Text = "Please Select...";
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            DbConnection load = new DbConnection();
            if (comboBox1.SelectedValue == null) return;
            string query = "SELECT * FROM Faculty, [Address] WHERE Address_AddressID = AddressID AND FacultyID = " + comboBox1.SelectedValue;
            DataTable temp = load.Select(query);
 
            textBox3.Text = temp.Rows[0][3].ToString();
            textBox1.Text = temp.Rows[0][4].ToString();
            textBox10.Text = Convert.ToDateTime(temp.Rows[0][5]).ToString("dd/MM/yyyy");
            textBox8.Text = temp.Rows[0][6].ToString();

            textBox4.Text = temp.Rows[0][8].ToString();
            textBox5.Text = temp.Rows[0][9].ToString();
            textBox6.Text = temp.Rows[0][10].ToString();
            textBox7.Text = temp.Rows[0][11].ToString();

            query = "SELECT DepartmentID, Department.[Name], IsMainDept FROM Faculty, Faculty_Department, Department WHERE FacultyID = Faculty_FacultyID AND Department_DepartmentID = DepartmentID AND FacultyID =" + comboBox1.SelectedValue + " ORDER BY IsMainDept DESC";
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

            query = "SELECT Designation.DesignationID, Designation.[PositionTitle], DATEDIFF(Year, DateStart,DateEnd) [Years] FROM Faculty, Faculty_Designation, Designation WHERE Faculty_FacultyID = FacultyID AND Designation_DesignationID = DesignationID AND FacultyID = " + comboBox1.SelectedValue;
            temp = load.Select(query);
            listBox2.DataSource = temp;
            listBox2.DisplayMember = "PositionTitle";
            listBox2.ValueMember = "DesignationID";
            textBox9.Text = temp.Rows[0][2].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
    }
}
