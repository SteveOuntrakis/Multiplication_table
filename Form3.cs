using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multiplication_table1
{
    public partial class Form3 : Form
    {
        Random r = new Random();
        int MainNumber = Form2.MainNumber;
        public static int sendnumber = 0;
        int SecondNumber;
        public static int Correct;
        List<int> list1 = new List<int>();
        
        
        
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Correct = 0;
            this.ControlBox = false;
            timer1.Start();
            label2.Text = MainNumber.ToString();
            list1.Add(0);
            sendnumber = MainNumber;
        }
        int question = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {            
            timer1.Stop();
            question++;
            label1.Text = "Ερώτηση Νο " + question;
            bool flag = true;
               while (flag)
               {
                    SecondNumber = r.Next(1, 11);
                    for (int i = 0; i <= list1.Count; i++)
                    {
                        if (list1.Contains(SecondNumber))
                            flag = true;
                        else
                            flag = false;
                    }
                }
                list1.Add(SecondNumber);
                label4.Text = SecondNumber.ToString();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            int result=0;
            try
            {
                result = Int32.Parse(textBox1.Text);
            }
            catch
            {
                textBox1.Text = "";
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (!textBox1.Text.Equals(""))
                {
                    if (result == MainNumber * SecondNumber)
                    {
                        label6.Text = "Σωστή απάντηση";
                        Correct++;
                    }
                    else
                    {
                        label6.Text = "Λάθος απάντηση";
                    }
                    label6.Visible = true;
                    button1.Visible = true;
                    textBox1.Enabled = false;
                }
                if (question == 10)
                {
                    button1.Text = "Τέλος"; 
                }               
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text.Equals("Τέλος"))
            {
                button1.Text = "Έξοδος";
                label1.Text = "Σωστές Απαντήσεις : \n " +"      "+ Correct +"/10";
                label1.Location = new Point(30, 50);
                label6.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                textBox1.Visible = false; 
            }
            else if (button1.Text.Equals("Έξοδος"))
            {
                Form4 form4 = new Form4();
                form4.ShowDialog();
                this.Close();
            }
           
            else
            {
                textBox1.Enabled = true;
                timer1.Start();
                textBox1.Clear();
                label6.Visible = false;
                button1.Visible = false;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
