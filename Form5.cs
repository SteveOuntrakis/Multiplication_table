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
    public partial class Form5 : Form
    {
        int FirstNumber, SecondNumber;
        Random r = new Random();
        List<int> list1 = new List<int>();        
        public static decimal[] correct= new decimal[11];
        public static decimal[] all = new decimal[11];
        int Correct = 0;
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            for (int i = 0; i < 11; i++)
            {
                correct[i] = 0;
                all[i] = 0;
            } 
            timer1.Start();
        }
        int question = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text.Equals("Τέλος"))
            {
                button1.Text = "Εμφάνιση Συνολικών Αποτελεσμάτων";
                label1.Text = "Σωστές Απαντήσεις : \n " + "         " + Correct + "/20";
                label1.Location = new Point(30, 50);
                label6.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                textBox1.Visible = false;                

            }
            else if (button1.Text.Equals("Εμφάνιση Συνολικών Αποτελεσμάτων"))
            {
                Form6 form6 = new Form6();
                form6.ShowDialog();
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

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            int result = 0;
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
                    if (result == FirstNumber * SecondNumber)
                    {
                        label6.Text = "Σωστή απάντηση";
                        Correct++;
                        correct[FirstNumber] += 1;
                        correct[SecondNumber] += 1;
                    }
                    else
                    {
                        label6.Text = "Λάθος απάντηση";
                    }
                    all[FirstNumber] += 1;
                    all[SecondNumber] += 1;
                    label6.Visible = true;
                    button1.Visible = true;
                    textBox1.Enabled = false;
                }
                if (question == 20)
                {
                    button1.Text = "Τέλος";
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            question++;
            label1.Text = "Ερώτηση Νο " + question;
            bool flag = true;
            while (flag)
            {
                FirstNumber = r.Next(2, 11);
                SecondNumber = r.Next(2, 11);
                for (int i = 0; i <= list1.Count; i++)
                {
                    if (list1.Contains(FirstNumber*SecondNumber))
                        flag = true;
                    else
                        flag = false;
                }
            }
            list1.Add(FirstNumber*SecondNumber);
            label2.Text = FirstNumber.ToString();
            label4.Text = SecondNumber.ToString();
        }
        
    }
}
