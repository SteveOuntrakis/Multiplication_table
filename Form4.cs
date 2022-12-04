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
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Multiplication_table1
{
    public partial class Form4 : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        public static Label[] Label = new Label[10];
        public static Label[] Label2 = new Label[9];
        public static Button[] Button = new Button[9];
        int correct = Form3.Correct;
        int number = Form3.sendnumber;
        int avg = 0;
        Form2 form2 = new Form2();
        public static int num2 = 0;       
        
        public Form4()
        {
            InitializeComponent();           
        }

        private void progressBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.progressBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.progressDataSet);
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            Label[0] = label1;
            Label[1] = label2;
            Label[2] = label3;
            Label[3] = label4;
            Label[4] = label5;
            Label[5] = label6;
            Label[6] = label7;
            Label[7] = label8;
            Label[8] = label9;
            Label[9] = label10;

            Label2[0] = label30;
            Label2[1] = label31;
            Label2[2] = label32;
            Label2[3] = label33;
            Label2[4] = label34;
            Label2[5] = label35;
            Label2[6] = label36;
            Label2[7] = label37;
            Label2[8] = label38;

            Button[0] = button2;
            Button[1] = button3;
            Button[2] = button4;
            Button[3] = button5;
            Button[4] = button6;
            Button[5] = button7;
            Button[6] = button8;
            Button[7] = button9;
            Button[8] = button10;

            button2.Click += new EventHandler(ButtonClicked);
            button3.Click += new EventHandler(ButtonClicked);
            button4.Click += new EventHandler(ButtonClicked);
            button5.Click += new EventHandler(ButtonClicked);
            button6.Click += new EventHandler(ButtonClicked);
            button7.Click += new EventHandler(ButtonClicked);
            button8.Click += new EventHandler(ButtonClicked);
            button9.Click += new EventHandler(ButtonClicked);
            button10.Click += new EventHandler(ButtonClicked);

            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Progress.accdb";

            try
            {
                connection.Open();
                string query = "SELECT * FROM progress  WHERE ID ='" + Form1.id + "'";
                OleDbCommand comd = new OleDbCommand(query, connection);
                OleDbDataReader rdr = comd.ExecuteReader();
                if (rdr.Read())
                {
                    for (int i = 0; i < 9; i++)
                    {
                        Label[i+1].Text = rdr.GetString(i+1);
                        progress(i);
                }
                }
                if (number > 1)
                {
                    for (int i = 0; i < 9; i++)
                    {
                        if (number == i+2)
                        {
                            Label[i+1].Text = (correct*10).ToString();
                        }
                        progress(i);
                    }
                }
            }
            catch
            {

            }
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    int num = Int32.Parse(Label[i].Text);
                    avg = avg + num;
                }
                catch { }

            }

            label1.Text = (avg )/9  + "%";

            connection.Close();
            connection.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Progress.accdb";
            try
            {
                connection.Open();            
                string query1= "DELETE * FROM progress WHERE ID ='" + Form1.id + "'"; 
                OleDbCommand com1 = new OleDbCommand(query1, connection);              
                com1.ExecuteNonQuery();
                string query2 = "insert into progress ([ID], [ΠΡΟΠΑΙΔΕΙΑ 2], [ΠΡΟΠΑΙΔΕΙΑ 3], [ΠΡΟΠΑΙΔΕΙΑ 4], [ΠΡΟΠΑΙΔΕΙΑ 5], [ΠΡΟΠΑΙΔΕΙΑ 6], [ΠΡΟΠΑΙΔΕΙΑ 7], [ΠΡΟΠΑΙΔΕΙΑ 8], [ΠΡΟΠΑΙΔΕΙΑ 9], [ΠΡΟΠΑΙΔΕΙΑ 10],[ΜΟ]) values ('" +Form1.id  + "','" + label2.Text + "','" + label3.Text + "','" + label4.Text + "','" + label5.Text + "','" + label6.Text + "','" + label7.Text + "','" + label8.Text + "','" + label9.Text + "','" + label10.Text +"','"+ label1.Text+ "')";
                OleDbCommand com2 = new OleDbCommand(query2, connection);
                com2.ExecuteNonQuery();               
                connection.Close();
                connection.Dispose();
                this.Close();

            }
            catch
            {
                
            }            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        public void progress(int i)
        {
            try
            {
                int num = Int32.Parse(Label[i + 1].Text);
                if (num >= 90)
                {
                    Label2[i].Text = "Αριστα";
                    Button[i].Visible = false;
                }
                else if (num < 60)
                {
                    Label2[i].Text = "Μέτρια";
                    Button[i].Visible = true;

                }
                else
                {
                    Label2[i].Text = "Καλά";
                    Button[i].Visible = false;
                }

            }
            catch {
                Label2[i].Text = "Αναβαθμολόγητο";
                Button[i].Visible = false;
            }
        }
        void ButtonClicked(Object sender, EventArgs e)
        {
            
            Button clicked = (Button)sender;           
            for (int i = 0; i<9; i++)
            {
                if(Button[i].Name.Equals(clicked.Name)){
                    num2 = i+2;
                    this.Hide();
                    form2.ShowDialog();
                }
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }
    }
}
