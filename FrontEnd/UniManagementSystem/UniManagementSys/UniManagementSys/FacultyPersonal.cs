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
    public partial class FacultyPersonal : Form
    {
        public FacultyPersonal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FacultyPortal_Load(object sender, EventArgs e)
        {
            DbConnection load = new DbConnection();
            if (Variables.fid == null) return;
            string query = "SELECT * FROM Faculty, [Address] WHERE Address_AddressID = AddressID AND FacultyID = " + Variables.fid;
            DataTable temp = load.Select(query);

            textBox12.Text = temp.Rows[0][2].ToString();
            textBox3.Text = temp.Rows[0][3].ToString();
            textBox1.Text = temp.Rows[0][4].ToString();
            textBox10.Text = Convert.ToDateTime(temp.Rows[0][5]).ToString("dd/MM/yyyy");
            textBox8.Text = temp.Rows[0][6].ToString();

            textBox4.Text = temp.Rows[0][8].ToString();
            textBox5.Text = temp.Rows[0][9].ToString();
            textBox6.Text = temp.Rows[0][10].ToString();
            textBox7.Text = temp.Rows[0][11].ToString();

            query = "SELECT DepartmentID, Department.[Name], IsMainDept FROM Faculty, Faculty_Department, Department WHERE FacultyID = Faculty_FacultyID AND Department_DepartmentID = DepartmentID AND FacultyID =" + Variables.fid + " ORDER BY IsMainDept DESC";
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

            query = "SELECT Designation.DesignationID, Designation.[PositionTitle], DATEDIFF(Year, DateStart,DateEnd) [Years] FROM Faculty, Faculty_Designation, Designation WHERE Faculty_FacultyID = FacultyID AND Designation_DesignationID = DesignationID AND FacultyID = " + Variables.fid;
            temp = load.Select(query);
            listBox2.DataSource = temp;
            listBox2.DisplayMember = "PositionTitle";
            listBox2.ValueMember = "DesignationID";
            textBox9.Text = temp.Rows[0][2].ToString();
        }
    }
}
