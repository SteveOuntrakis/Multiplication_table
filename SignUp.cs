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
using System.Text.RegularExpressions;

namespace Multiplication_table1
{
    public partial class SignUp : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        public SignUp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Progress.accdb";            
            if (textBox1.TextLength < 4)
            {                
                MessageBox.Show("Το όνομα χρήστη πρέπει να έχει τουλάχιστον 4 χαρακτήρες");
            }
            else if (textBox2.TextLength < 4)
            {
                MessageBox.Show("O Κωδικός πρέπει να έχει τουλάχιστον 4 χαρακτήρες");
            }
            else if (!Regex.IsMatch(textBox3.Text, @"^[a-zA-Zα-ωΑ-Ω]+$")| textBox3.TextLength<3)
            {
                MessageBox.Show("Παρακαλώ τοποθετήστε έγκυρο όνομα");
            }
            else if (!Regex.IsMatch(textBox4.Text, @"^[a-zA-Zα-ωΑ-Ω]+$") | textBox4.TextLength < 4)
            {
                MessageBox.Show("Παρακαλώ τοποθετήστε έγκυρο επώνυμο");
            }           
            else
            {
                if (textBox2.Text.Equals(textBox5.Text))
                {
                    try
                    {
                        connection.Open();
                        string query = "SELECT * FROM users WHERE Username ='" + textBox1.Text + "'";
                        OleDbCommand comd = new OleDbCommand(query, connection);
                        OleDbDataReader rdr = comd.ExecuteReader();
                        if (rdr.Read())
                        {
                            MessageBox.Show("Ο χρήστης είναι ήδη εγγεγραμμένος!");
                        }
                        else
                        {
                            string query2 = "insert into Users ([Username], [Password], [Name], [Surname]) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
                            OleDbCommand com2 = new OleDbCommand(query2, connection);
                            com2.ExecuteNonQuery();
                        }
                        connection.Close();
                    }
                    catch
                    {

                    }
                    connection.Open();
                    string query3 = "SELECT * FROM users WHERE Username ='" + textBox1.Text + "'";
                    OleDbCommand com3 = new OleDbCommand(query3, connection);
                    OleDbDataReader rdr3 = com3.ExecuteReader();
                    if (rdr3.Read())
                    {
                        string query4 = "insert into progress ([ID], [ΠΡΟΠΑΙΔΕΙΑ 2], [ΠΡΟΠΑΙΔΕΙΑ 3], [ΠΡΟΠΑΙΔΕΙΑ 4], [ΠΡΟΠΑΙΔΕΙΑ 5], [ΠΡΟΠΑΙΔΕΙΑ 6], [ΠΡΟΠΑΙΔΕΙΑ 7], [ΠΡΟΠΑΙΔΕΙΑ 8], [ΠΡΟΠΑΙΔΕΙΑ 9], [ΠΡΟΠΑΙΔΕΙΑ 10],[ΜΟ]) values ('" + rdr3.GetString(0) + "','" + "NULL" + "','" + "NULL" + "','" + "NULL" + "','" + "NULL" + "','" + "NULL" + "','" + "NULL" + "','" + "NULL" + "','" + "NULL" + "','" + "NULL" + "','" + "NULL" + "')";
                        OleDbCommand com4 = new OleDbCommand(query4, connection);
                        com4.ExecuteNonQuery();
                    }

                    MessageBox.Show("Επιτυχής Εγγραφή");
                    this.Close();
                    connection.Close();
                }
                else
                {
                    MessageBox.Show("Το Συνθηματικό δεν είναι το ίδιο");
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SignUp_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void βοήθειαToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("• Το όνομα χρήστη πρέπει να έχει τουλάχιστον 4 χαρακτήρες.\n\n• Ο κωδικός πρέπει να έχει τουλάχιστον 4 χαρακτήρες και να γραφτεί ξανά στην επιβεβαίωση.\n\n• Το όνομα και το επώνυμο δέχονται μόνο γράμματα.");
        }
    }
}
