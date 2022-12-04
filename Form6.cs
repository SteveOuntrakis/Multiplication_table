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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;


namespace Multiplication_table1
{
    public partial class Form6 : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        Label[] label = new Label[9];
        Label[] avg = new Label[9];
        int mo = 0;
        int average = 0;
        String name, surname;
        public Form6()
        {
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void Form6_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            label[0] = label52;
            label[1] = label53;
            label[2] = label54;
            label[3] = label55;
            label[4] = label56;
            label[5] = label57;
            label[6] = label58;
            label[7] = label59;
            label[8] = label60;

            avg[0] = label43;
            avg[1] = label44;
            avg[2] = label45;
            avg[3] = label46;
            avg[4] = label47;
            avg[5] = label48;
            avg[6] = label49;
            avg[7] = label50;
            avg[8] = label51;         

            label15.Text = Form5.correct[2].ToString();
            label16.Text = Form5.correct[3].ToString();
            label17.Text = Form5.correct[4].ToString();
            label18.Text = Form5.correct[5].ToString();
            label19.Text = Form5.correct[6].ToString();
            label20.Text = Form5.correct[7].ToString();
            label21.Text = Form5.correct[8].ToString();
            label22.Text = Form5.correct[9].ToString();
            label23.Text = Form5.correct[10].ToString();

            label33.Text = Form5.all[2].ToString();
            label34.Text = Form5.all[3].ToString();
            label35.Text = Form5.all[4].ToString();
            label36.Text = Form5.all[5].ToString();
            label37.Text = Form5.all[6].ToString();
            label38.Text = Form5.all[7].ToString();
            label39.Text = Form5.all[8].ToString();
            label40.Text = Form5.all[9].ToString();
            label41.Text = Form5.all[10].ToString();
            for (int i = 0; i < 9; i++)
            {
                int average = Convert.ToInt32(Form5.all[i + 2] * 100 / Form5.correct[i + 2]);
                avg[i].Text = average.ToString() + "%";
                mo = mo + average;
            }          
            for (int i=0; i < 9; i++)
            {
                if ((Form5.correct[i + 2] / Form5.all[i + 2]) * 100 >= 90)                
                    label[i].Text = "Άριστα";                
                else if ((Form5.correct[i + 2] / Form5.all[i + 2]) * 100 < 60)                
                    label[i].Text = "Μέτρια";                
                else
                    label[i].Text = "Καλά";
            }
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Progress.accdb";
            try
            {
                connection.Open();
                string query = "SELECT * FROM progress  WHERE ID ='" + Form1.id + "'";
                OleDbCommand comd = new OleDbCommand(query, connection);
                OleDbDataReader rdr = comd.ExecuteReader();

                string query2 = "SELECT * FROM Users WHERE Username='" + Form1.id + "'";
                OleDbCommand com2 = new OleDbCommand(query2, connection);
                OleDbDataReader rdr2 = com2.ExecuteReader();

                if (rdr.Read())
                {
                    mo = mo / 9;
                    string resultString = Regex.Match(rdr.GetString(10), @"^[^%]*").Value;
                    int result = Int32.Parse(resultString);
                    average = (mo + result) / 2;
                    label62.Text = (average).ToString() + "%";                   
                }  
                if (rdr2.Read())
                {
                    name = rdr2.GetString(2);
                    surname = rdr2.GetString(3);
                    //MessageBox.Show("diavase to 2!!!");
                }
            }
            catch
            {

            }
            connection.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //σύνδεση
            Document doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(Form1.id + ".pdf", FileMode.Create));
            doc.Open();
            //ορισμός ελληνικών , γραμματοσειράς αριαλ και μέγεθος γραμματων
            string ARIALUNI_TFF = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIALUNI.TTF");
            BaseFont bf = BaseFont.CreateFont(ARIALUNI_TFF, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font titleFont = new iTextSharp.text.Font(bf, 32);
            iTextSharp.text.Font paragraphFont = new iTextSharp.text.Font(bf, 14);

            //iTextSharp.text.Image img1 = iTextSharp.text.Image.GetInstance("fonto_blue.jpg");
            //iTextSharp.text.Image img2 = iTextSharp.text.Image.GetInstance("sima.jpg");
            //μέγεθος εικόνας
            //img1.ScaleAbsolute(600, 850);
            //img2.ScaleAbsolute(80, 80);
            //θέση εικόνας , στο ύψος ξεκινάει το 1 από το τέλος της σελίδας και όσο ανεβαίνουμε μεγαλώνει
            //img1.SetAbsolutePosition(1, 1);
           // img2.SetAbsolutePosition(255, 610);
            Paragraph t1 = new Paragraph("Συγχαρητήρια \n\n\n\n\n", titleFont);
            t1.Alignment = Element.ALIGN_CENTER;           
            Paragraph p1 = new Paragraph("Δίπλωμα επιτυχίας για " + surname + " " + name + "\n\n", paragraphFont);
            Paragraph p2 = new Paragraph(" ");
            Paragraph p3 = new Paragraph(" ");
            if (average >= 90)
            {
                p2 = new Paragraph("Ο/Η " + surname + " " + name + " αρίστευσε στην προπαίδεια με τελικό μέσο όρο : "+average+  " %\n\n", paragraphFont);
                p3 = new Paragraph("Συγχαρητήρια για την επιτυχία και σου ευχόμαστε καλή πρόοδου", paragraphFont);
            }
            else if (average >=60)
            {
                p2 = new Paragraph("Ο/Η " + surname + " " + name + " πήγε πολύ καλά στην προπαίδεια με τελικό μέσο όρο : " + average + " %\n\n", paragraphFont);
                p3 = new Paragraph("Συγχαρητήρια για την επιτυχία και σου ευχόμαστε καλή πρόοδου", paragraphFont);
            }
            else
            {
                p2 = new Paragraph("Ο/Η " + surname + " " + name + " πήγε μέτρια στην προπαίδεια με τελικό μέσο όρο : " + average + " %\n\n", paragraphFont);
                p3 = new Paragraph("Συγχαρητήρια για την επιτυχία ωστόσο χρήζεις βελτίωση ", paragraphFont);
            }
            
            doc.Add(t1);
            doc.Add(p1);
            doc.Add(p2);
            doc.Add(p3);            
            //doc.Add(img1);
            //doc.Add(img2);
            doc.Close();
            MessageBox.Show("Το δίπλωμα δημιουργήθηκε!!");
            System.Diagnostics.Process.Start(Form1.id + ".pdf");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1.ActiveForm.Activate();
        }
    }
}
