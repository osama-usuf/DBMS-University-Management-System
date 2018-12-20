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
    public partial class PersonalDetails : Form
    {
        public PersonalDetails()
        {
            InitializeComponent();
        }
        private void PersonalDetails_Load(object sender, EventArgs e)
        {
            
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PersonalDetails_Load_1(object sender, EventArgs e)
        {
            DbConnection load = new DbConnection();
            if (Variables.sid == null) return;
            string query = "SELECT * FROM Student, [Address] WHERE Address_AddressID = AddressID AND StudentID = " + Variables.sid;
            DataTable temp = load.Select(query);

            textBox3.Text = temp.Rows[0][3].ToString();
            textBox1.Text = temp.Rows[0][4].ToString();
            textBox10.Text = Convert.ToDateTime(temp.Rows[0][5]).ToString("dd/MM/yyyy");

            textBox4.Text = temp.Rows[0][8].ToString();
            textBox5.Text = temp.Rows[0][9].ToString();
            textBox6.Text = temp.Rows[0][10].ToString();
            textBox7.Text = temp.Rows[0][11].ToString();
        }
    }
}
