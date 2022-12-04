using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multiplication_table1
{
    public partial class Form2 : Form
    {      
        public static int MainNumber;        
        TableLayoutPanel tableLayoutPanel;    
        
        public Form2()
        {
            InitializeComponent();
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            if (Form4.num2 > 0)
            {
                MainNumber = Form4.num2;
                Form4.num2 = 0;
            }
            else
            {
                MainNumber = Form1.number;
            }
            
            label1.Text = "Η προπαίδεια του " + MainNumber;
            
            tableLayoutPanel = new TableLayoutPanel();
       
            tableLayoutPanel.Location = new System.Drawing.Point(10, 90);
            tableLayoutPanel.Name = "Multiplication Table";
            tableLayoutPanel.Size = new System.Drawing.Size(540, 420);          

            //tableLayoutPanel.BackColor = Color.LightBlue;        
            tableLayoutPanel.ColumnCount = 5;
            tableLayoutPanel.RowCount = 10;

            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 3F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 3F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 3F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 3F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 3F));


            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute,40f));            
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute,40f));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute,40F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute,40F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute,40F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute,40F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute,40F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute,40F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute,40F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute,40F));
          
            


            tableLayoutPanel.TabIndex = 0;
            this.Controls.Add(tableLayoutPanel);         
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();          
            Form1.ActiveForm.Activate();
            timer1.Stop();
            dur = 1;
            tableLayoutPanel.Dispose();
            
        }

        int dur = 1;
        private void timer1_Tick(object sender, EventArgs e)
        {
            Label label = new Label()
            {
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Comic Sans MS",24,FontStyle.Bold)
                
            };
            
            Label label2 = new Label()
            {
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Comic Sans MS", 24, FontStyle.Bold)

            };
           
            Label label3 = new Label()
            {
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Comic Sans MS", 24, FontStyle.Bold)

            };
            Label label4 = new Label()
            {
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Comic Sans MS", 24, FontStyle.Bold)

            };
            Label label5 = new Label()
            {
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Comic Sans MS", 24, FontStyle.Bold)

            };


            if (dur!=11)
            {
                
                label.Text = MainNumber.ToString();
                tableLayoutPanel.Controls.Add(label, 0,dur-1);
                label2.Text = "*";
                tableLayoutPanel.Controls.Add(label2,1,dur-1);
                label3.Text = dur.ToString();
                tableLayoutPanel.Controls.Add(label3,2,dur-1);
                label4.Text = "=";
                tableLayoutPanel.Controls.Add(label4,3,dur-1);
                label5.Text =(MainNumber * dur).ToString();
                tableLayoutPanel.Controls.Add(label5,4,dur-1);

            }
            else
            {
                timer1.Stop();
            }
           
                
            dur++;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            timer1.Stop();
            this.Hide();
            dur = 1;
            tableLayoutPanel.Dispose();
            Form3 form3 = new Form3();          
            form3.ShowDialog();
            

        }
    }
}
