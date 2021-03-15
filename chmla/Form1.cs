using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace chmla
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                textBox10.Location = new Point(700, 87);
                textBox11.Location = new Point(700, 149);
                textBox12.Location = new Point(700, 221);
                label25.Location = new Point(588, 84);
                label24.Location = new Point(588, 143);
                label23.Location = new Point(588, 216);
                label21.Location = new Point(564, 152);
                label10.Location = new Point(655, 84);
                label11.Location = new Point(655, 146);
                label12.Location = new Point(655, 215);
                textBox16.Visible = false;
                textBox15.Visible = false;
                textBox14.Visible = false;
                textBox13.Visible = false;
                label16.Visible = false;
                label15.Visible = false;
                label14.Visible = false;
                label13.Visible = false;
                textBox18.Visible = false;
                label18.Visible = false;
                textBox21.Visible = false;
                textBox19.Visible = false;
                textBox20.Visible = false;
                label20.Visible = false;
                label19.Visible = false;
                label17.Visible = false;
                label22.Visible = false;


            }
            else
            {
                textBox10.Location = new Point(899, 88);
                textBox11.Location = new Point(899, 150);
                textBox12.Location = new Point(899, 221);
                textBox13.Location = new Point(899, 278);
                label25.Location = new Point(752, 86);
                label24.Location = new Point(752, 145);
                label23.Location = new Point(752, 218);
                label21.Location = new Point(726, 186);
                label10.Location = new Point(829, 83);
                label11.Location = new Point(829, 145);
                label12.Location = new Point(829, 214);
                textBox16.Visible = true;
                textBox15.Visible = true;
                textBox14.Visible = true;
                textBox13.Visible = true;
                label16.Visible = true;
                label15.Visible = true;
                label14.Visible = true;
                label13.Visible = true;
                textBox21.Visible = true;
                label18.Visible = true;
                textBox19.Visible = true;
                textBox20.Visible = true;
                label20.Visible = true;
                label19.Visible = true;
                label17.Visible = true;
                label22.Visible = true;
                textBox18.Visible = true;

            }
            //TextBox t = new TextBox();
            //Label l = new Label();
            //l.Name = "q";
            //t.Name = "t";
            //TextBox t1 = new TextBox();
            //t1.Name = "e";
            //Label l1 = new Label();
            //l1.Name = "q";
            //TextBox t2 = new TextBox();
            //Label l2 = new Label();
            //l2.Name = "q";
            //t2.Name = "t";
            //Label l3 = new Label();
            //l3.Name = "e1";
            //TextBox t3 = new TextBox();
            //t3.Name = "t";
            //if (comboBox1.SelectedIndex == 1)
            //{
            //    t.Location = new Point(72, 280);
            //    this.Controls.Add(t);
            //    l.Text = "X1";
            //    l.Location = new Point(178, 285);
            //    this.Controls.Add(l);
            //    //
            //    t1.Location = new Point(296, 280);
            //    this.Controls.Add(t1);
            //    l1.Text = "X2";
            //    l1.Location = new Point(402, 285);
            //    l1.AutoSize = true;
            //    this.Controls.Add(l1);
            //    //
            //    t2.Location = new Point(498, 280);
            //    this.Controls.Add(t2);
            //    l2.Text = "X3";
            //    l2.Location = new Point(604, 285);
            //    l2.AutoSize = true;
            //    this.Controls.Add(l2);
            //    //
            //    l3.Text = "=";
            //    l3.Font = new Font("Microsoft Sans Serif", 16);
            //    l3.Location = new Point(630, 276);
            //    l3.AutoSize = true;
            //    this.Controls.Add(l3);
            //    //
            //    t3.Location = new Point(680, 280);
            //    this.Controls.Add(t3);
            //}
            //if(comboBox1.SelectedIndex==0)
            //{
            //    l.Visible = false;
            //    foreach (Control ctrl in this.Controls.OfType<Label>().Where(x => x.Name == "q")) { this.Controls.Remove(ctrl); }
            //    foreach (Control ctrl in this.Controls.OfType<TextBox>().Where(x => x.Name == "t")) { this.Controls.Remove(ctrl); }
            //    foreach (Control ctrl in this.Controls.OfType<TextBox>().Where(x => x.Name == "e")) { this.Controls.Remove(ctrl); }
            //    foreach (Control ctrl in this.Controls.OfType<Label>().Where(x => x.Name == "e1")) { this.Controls.Remove(ctrl); }
            //}
            //можна було це все через visible!!!



        }
 
        

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void Print(double[,] a, double[] b, int n)
        {
            string s = "";
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    s+=(Math.Round(a[i, j], 6).ToString() + "\t");
                    textBox17.Text+=(Math.Round(a[i, j], 6).ToString()+"\t");
                }
                s +=(Math.Round(b[i], 6).ToString()+"\t");
                textBox17.Text+=(Math.Round(b[i], 6).ToString()+"\t");
                s +=('\n');
                textBox17.Text += "\r\n";          
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            { 
                double x1 = double.Parse(textBox1.Text);
                double x2 = double.Parse(textBox2.Text);
                double x3 = double.Parse(textBox5.Text);
                double x1m = double.Parse(textBox3.Text);
                double x2m = double.Parse(textBox4.Text);
                double x3m = double.Parse(textBox9.Text);
                double x1l = double.Parse(textBox6.Text);
                double x2l = double.Parse(textBox7.Text);
                double x3l = double.Parse(textBox8.Text);
                double y1 = double.Parse(textBox10.Text);
                double y2 = double.Parse(textBox11.Text);
                double y3 = double.Parse(textBox12.Text);
                //textBox17.Text += (x1, x2, x3, x1m, x2m, x3m, x1l, x2l, x3l, y1, y2, y3);
                double d, s;

                int row = 0;
                if (comboBox1.SelectedIndex == 0)
                {
                    row = 3;
                }
                else
                {
                    row = 4;
                }

                double[,] A = new double[row, row];
                double[,] a = new double[row, row];
                double[] B = new double[row];
                double[] x = new double[row];
                double[] b = new double[row];
                A[0, 0] = x1;
                A[0, 1] = x2;
                A[0, 2] = x3;
                B[0] = y1;
                A[1, 0] = x1m;
                A[1, 1] = x2m;
                A[1, 2] = x3m;
                B[1] = y2;
                A[2, 0] = x1l;
                A[2, 1] = x2l;
                A[2, 2] = x3l;
                B[2] = y3;
                int countt = 0;
                double det = 1;
                for (int k = 0; k < row; k++)
                {
                    int noob = k;
                    if (A[k,k]==0)
                    {
                        while(A[noob,k]==0&&k!=row-1)
                        {
                            noob += 1;
                        }
                        for (int j=0;j<row;j++)
                        {
                            double c = A[noob, j];
                            A[noob, j] = A[k, j];
                            A[k, j] = c;
                        }
                        double y = B[k];
                        B[k] = B[noob];
                        B[noob] = y;
                    }
                    for (int j = k + 1; j < row; j++)
                    {
                        d = A[j, k] / A[k, k];
                        for (int i = k; i < row; i++)
                        {
                            A[j, i] = A[j, i] - d * A[k, i];
                        }
                        B[j] = B[j] - d * B[k];
                    }
                    Print(A, B, 3);
                    textBox17.Text += "\r\n";
                }
                for (int i = 0; i < 3; i++)
                {
                    det = det * A[i, i];
                }
                if (A[row-1,row-1]==0&&B[row-1]==0)
                {
                    textBox17.Text += "0x3=0 тому безліч розв'язків!";
                    countt += 3;
                }
                if (Double.IsNaN(det) || det == 0)
                {
                    countt += 1;
                }
                else
                {
                    for (int k = row - 1; k >= 0; k--)
                    {
                        d = 0;
                        for (int j = k; j < row; j++)
                        {
                            s = A[k, j] * x[j];
                            d += s;
                        }
                        x[k] = (B[k] - d) / A[k, k];

                    }
                }

                if (countt == 1)
                {
                    textBox17.Text += "Матриця недійсна, визначник = 0";
                }
                if (countt==0)
                {
                    textBox17.Text += ($"\r\nYour system\r\n");
                    for (int i = 0; i < row; i++)
                    {
                        textBox17.Text += ($"x[{i}]= {x[i]}\r\n");
                    }
                    textBox17.Text += ($"Your determinant: {det}\r\n");
                }

            }

            else
            {
                double x1 = double.Parse(textBox1.Text);
                double x2 = double.Parse(textBox2.Text);
                double x3 = double.Parse(textBox5.Text);
                double x4 = double.Parse(textBox21.Text);
                double x1m = double.Parse(textBox3.Text);
                double x2m = double.Parse(textBox4.Text);
                double x3m = double.Parse(textBox9.Text);
                double x4m = double.Parse(textBox19.Text);
                double x1l = double.Parse(textBox6.Text);
                double x2l = int.Parse(textBox7.Text);
                double x3l = int.Parse(textBox8.Text);
                double x4l = int.Parse(textBox20.Text);
                double x1ll = int.Parse(textBox16.Text);
                double x2ll = int.Parse(textBox15.Text);
                double x3ll = int.Parse(textBox14.Text);
                double x4ll = int.Parse(textBox18.Text);
                double y1 = double.Parse(textBox10.Text);
                double y2 = double.Parse(textBox11.Text);
                double y3 = double.Parse(textBox12.Text);
                double y4 = double.Parse(textBox13.Text);
                //textBox17.Text += (x1, x2, x3, x1m, x2m, x3m, x1l, x2l, x3l,x1ll,x2ll,x3ll, y1, y2, y3,y4);
                double d, s;
                int row = 0;
                if (comboBox1.SelectedIndex == 0)
                {
                    row = 3;
                }
                else
                {
                    row = 4;
                }
                int four = 0;
                int count = 0;

                double[,] A = new double[row, row];
                double[,] a = new double[row, row];
                double[] B = new double[row];
                double[] x = new double[row];
                double[] b = new double[row];
                A[0, 0] = x1;
                A[0, 1] = x2;
                A[0, 2] = x3;
                A[0, 3] = x4;
                B[0] = y1;
                A[1, 0] = x1m;
                A[1, 1] = x2m;
                A[1, 2] = x3m;
                A[1, 3] = x4m;
                B[1] = y2;
                A[2, 0] = x1l;
                A[2, 1] = x2l;
                A[2, 2] = x3l;
                A[2, 3] = x4l;
                B[2] = y3;
                A[3, 0] = x1ll;
                A[3, 1] = x2ll;
                A[3,2]= x3ll;
                A[3, 3] = x4ll;
                B[3] = y4;
                double det = 1;
                for (int k = 0; k < row; k++)
                {
                    int noob = k;
                    if (A[k, k] == 0)
                    {
                        while (A[noob, k] == 0&&k!=row-1)
                        {
                            noob += 1;
                        }
                        for (int j = 0; j < row; j++)
                        {
                            double c = A[noob, j];
                            A[noob, j] = A[k, j];
                            A[k, j] = c;
                        }
                        double y = B[k];
                        B[k] = B[noob];
                        B[noob] = y;
                    }
                    for (int j = k + 1; j < row; j++)
                    {
                        d = A[j, k] / A[k, k];
                        for (int i = k; i < row; i++)
                        {
                            A[j, i] = A[j, i] - d * A[k, i];
                        }
                        B[j] = B[j] - d * B[k];
                    }
                    Print(A, B, 4);
                    textBox17.Text += "\r\n";
                }
                for (int i = 0; i < 4; i++)
                {
                    det = det * A[i, i];
                }
                if (A[row - 1, row - 1] == 0 && B[row - 1] == 0)
                {
                    textBox17.Text += "0x4=0 тому безліч розв'язків!";
                    count += 3;
                }
                if (Double.IsNaN(det) || det == 0)
                {
                    count += 1;
                }
                else
                {
                    for (int k = row - 1; k >= 0; k--)
                    {
                        d = 0;
                        for (int j = k; j < row; j++)
                        {
                            s = A[k, j] * x[j];
                            d += s;
                        }
                        x[k] = (B[k] - d) / A[k, k];

                    }
                }

                if (count == 1)
                {
                    textBox17.Text += "Матриця недійсна, визначник = 0";
                }
                if(count==0)
                {
                    textBox17.Text += ($"\r\nYour system\r\n");
                    for (int i = 0; i < row; i++)
                    {
                        textBox17.Text += ($"x[{i}]= {x[i]}\r\n ");
                    }
                    textBox17.Text += ($"Your determinant: {det}\r\n");
                }

            }
        }



        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox5.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox9.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox16.Text = "";
            textBox15.Text = "";
            textBox14.Text = "";
            textBox18.Text = "";
            textBox20.Text = "";
            textBox19.Text = "";
            textBox21.Text = "";
            textBox13.Text = "";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            textBox17.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, textBox17.Text);
            }
            MessageBox.Show(
        "       Успішно збережено!",
        ""
        );
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
        "Бажаєте зберегти дані перед виходом?",
        "Увага!",
        MessageBoxButtons.YesNoCancel,
        MessageBoxIcon.Information,
        MessageBoxDefaultButton.Button1,
        MessageBoxOptions.DefaultDesktopOnly);

            if (result == DialogResult.Yes)
            {
                button1.BackColor = Color.Red;
                SaveFileDialog sfd = new SaveFileDialog();
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(sfd.FileName, textBox17.Text);
                }
                MessageBox.Show(
            "       Успішно збережено!",
            ""
            );
                Application.Exit();
            }
            if (result == DialogResult.No)
            {
                Application.Exit();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"D:",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };
            if (comboBox1.SelectedIndex==0&& openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;
                string fileText = File.ReadAllText(filename);
                string phrase = fileText;
                phrase = phrase.Replace(Environment.NewLine, " ");
                string[] chysla = phrase.Split(' ');
                List<string> str = new List<string>();
                foreach(var ch in chysla)
                {
                    str.Add(ch);
                }

                textBox1.Text = str[0];
                textBox2.Text = str[1];
                textBox5.Text = str[2];
                textBox10.Text = str[3];
                textBox3.Text = str[4];
                textBox4.Text = str[5];
                textBox9.Text = str[6];
                textBox11.Text = str[7];
                textBox6.Text = str[8];
                textBox7.Text = str[9];
                textBox8.Text = str[10];
                textBox12.Text = str[11];

            }
            if (comboBox1.SelectedIndex == 1 && openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;
                string fileText = File.ReadAllText(filename);
                string phrase = fileText;
                phrase = phrase.Replace(Environment.NewLine, " ");
                string[] chysla = phrase.Split(' ');
                List<string> str = new List<string>();
                foreach (var ch in chysla)
                {
                    str.Add(ch);
                }

                textBox1.Text = str[0];
                textBox2.Text = str[1];
                textBox5.Text = str[2];
                textBox21.Text = str[3];
                textBox10.Text = str[4];
                textBox3.Text = str[5];
                textBox4.Text = str[6];
                textBox9.Text = str[7];
                textBox19.Text = str[8];
                textBox11.Text = str[9];
                textBox6.Text = str[10];
                textBox7.Text = str[11];
                textBox8.Text = str[12];
                textBox20.Text = str[13];
                textBox12.Text = str[14];
                textBox16.Text = str[15];
                textBox15.Text = str[16];
                textBox14.Text = str[17];
                textBox18.Text = str[18];
                textBox13.Text = str[19];
            }
        }
    }
}
