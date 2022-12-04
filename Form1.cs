using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Multiplication_table1
{
    public partial class Form1 : Form
    {
        Form2 form2 = new Form2();     
        public static int number;
        private OleDbConnection connection = new OleDbConnection();
        public static Button[] buttons = new Button[9];
        public static string id;

        public Form1(string name,string username)
        {
            InitializeComponent();
            label1.Text= " Γεια σου, " + name+ "!";
            id = username;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            buttons[0] = button2;
            buttons[1] = button3;
            buttons[2] = button4;
            buttons[3] = button5;
            buttons[4] = button6;
            buttons[5] = button7;
            buttons[6] = button8;
            buttons[7] = button9;
            buttons[8] = button10;
            button2.Click += new EventHandler(ButtonClicked);
            button3.Click += new EventHandler(ButtonClicked);
            button4.Click += new EventHandler(ButtonClicked);
            button5.Click += new EventHandler(ButtonClicked);
            button6.Click += new EventHandler(ButtonClicked);
            button7.Click += new EventHandler(ButtonClicked);
            button8.Click += new EventHandler(ButtonClicked);
            button9.Click += new EventHandler(ButtonClicked);
            button10.Click += new EventHandler(ButtonClicked);            

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        void ButtonClicked(Object sender, EventArgs e)
        {
            Button clicked = (Button)sender;          
            string resultString = Regex.Match(clicked.Name, @"\d+").Value;           
            number=Int32.Parse(resultString);          
            form2.ShowDialog();           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            Form4 form4 = new Form4();
            form4.ShowDialog();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            button11.Visible = true;
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Progress.accdb";
            try
            {
                connection.Open();
                string query = "SELECT * FROM progress  WHERE ID ='" + id + "'"; 
                OleDbCommand comd = new OleDbCommand(query, connection);
                OleDbDataReader rdr = comd.ExecuteReader();
                if (rdr.Read())
                {
                    for (int i = 0; i < 9; i++)
                    {
                        int num = 0;
                        try
                        {
                            num = Int32.Parse(rdr.GetString(i + 1));                            
                            if (num > 70)
                            {
                                buttons[i].BackColor = Color.Green;
                            }
                            else if (num > 50)
                            {
                                buttons[i].BackColor = Color.Yellow;
                            }
                            else
                            {
                                buttons[i].BackColor = Color.Red;
                                button11.Visible = false;
                            }
                                
                        }
                        catch
                        {
                            button11.Visible = false;
                        }


                    }
                }
                connection.Close();
                connection.Dispose();

            }
            catch
            {

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Visible = true;
            this.Close();
        }

        private void βοήθειαToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("• Με την επιλογή της προπαίδειας ενός αριθμού εμφανίζεται η προπαίδεια του αριθμού καθώς και η επιλογή να για τεστ.\n\n• Η επιλογή 'Απόσυνδεση' μας μεταφέρει στο μενού σύνδεσης.\n\n• Η επιλογή 'Η προοδός μου' παρουσιάζει την ατομική πρόοδου σε κάθε τεστ.\n\n• Πρέπει να περαστούν όλα τα τεστ για να εμφανιστεί η επιλογή 'Επαναληπτικό τεστ.'");
        }

        private void αποσύνδεσηToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Visible = true;
            this.Close();
        }
    }
}
