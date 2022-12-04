using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Multiplication_table1
{
    public partial class Login : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Progress.accdb";

            try
            {
                connection.Open();
                string query = "SELECT * FROM users WHERE Username ='" + textBox1.Text + "' AND Password ='" + textBox2.Text + "'";
                OleDbCommand comd = new OleDbCommand(query, connection);
                OleDbDataReader rdr = comd.ExecuteReader();
                if (rdr.Read())
                {
                    Form1 eisodos = new Form1(rdr.GetString(2),rdr.GetString(0));
                    eisodos.ShowDialog();
                    this.Visible = false ;
                    
                }
                else
                {
                    MessageBox.Show("Λάθος στοιχεία!");
                    textBox1.Text = "";
                    textBox2.Clear();
                }
                connection.Close();
            }
            catch
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SignUp signup = new SignUp();
            signup.ShowDialog();
        }

        private void Login_Activated(object sender, EventArgs e)
        {
            
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Βάλε το όνομα και τον κωδικό σου για είσοδο στην εφαρμογή!");
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
