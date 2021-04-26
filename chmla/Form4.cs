using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using System.IO;

namespace chmla
{
    public partial class Form4 : Form
    {
        string size;
        int sizeForFunc;
        double[,] firstMatrix;
        double[] firtstVector;
        const string matrixFilePath = @"C:\Users\Sevka\source\repos\chmla\chmla\Matrix.txt";
        const string vectorFilePath = @"C:\Users\Sevka\source\repos\chmla\chmla\Vector.txt";
        const string pochNabl = @"C:\Users\Sevka\source\repos\chmla\chmla\PochatkoveNabl.txt";
        public Form4()
        {
            InitializeComponent();
            this.dataGridView1.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 17);
            this.dataGridView2.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 17);
        }
        public static double[,] ReadArrayFromFile(string file)
        {
            StreamReader file_ = new StreamReader(file);
            string s = file_.ReadToEnd();
            file_.Close();
            string[] row = s.Split('\n');
            string[] column = row[0].Split(' ');
            double[,] a = new double[row.Length, column.Length];
            int t = 0;
            int n = 0;
            for (int i = 0; i < row.Length; i++)
            {
                column = row[i].Split(' ');
                for (int j = 0; j < column.Length; j++)
                {
                    t = Convert.ToInt32(column[j]);
                    a[i, j] = t;
                }
            }

            return a;
        }

        public static double[] ReadVectorFromFile(string file)
        {

            StreamReader file_ = new StreamReader(file);
            string s = file_.ReadToEnd();
            file_.Close();
            string[] row = s.Split('\n');
            double[] a = new double[row.Length];
            double t = 0;
            for (int i = 0; i < row.Length; i++)
            {
                t = double.Parse(row[i]);
                a[i] = t;
            }
            return a;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();
            textBox1.Text = "";


            size = Interaction.InputBox("Введіть, будь ласка, кількість рядків та стовпців", "Кількість рядків та стовпців");

            dataGridView1.RowCount = int.Parse(size);
            dataGridView1.ColumnCount = int.Parse(size);

            dataGridView2.RowCount = int.Parse(size);
            dataGridView2.ColumnCount = 1;
            sizeForFunc = int.Parse(size);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();
            textBox1.Text = "";
            firstMatrix = ReadArrayFromFile(matrixFilePath);
            firtstVector = ReadVectorFromFile(vectorFilePath);
            dataGridView1.RowCount = firstMatrix.GetLength(0);
            dataGridView1.ColumnCount = firstMatrix.GetLength(0);
            sizeForFunc = firstMatrix.GetLength(0);

            dataGridView2.RowCount = firstMatrix.GetLength(0);
            dataGridView2.ColumnCount = 1;

            for (int i = 0; i < firstMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < firstMatrix.GetLength(0); j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = firstMatrix[i,j];
                }
            }

            for (int i = 0; i < firstMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    dataGridView2.Rows[i].Cells[j].Value = firtstVector[i];
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();
            textBox1.Text = "";

            size = Interaction.InputBox("Введіть, будь ласка, кількість рядків та стовпців", "Кількість рядків та стовпців");

            dataGridView1.RowCount = int.Parse(size);
            dataGridView1.ColumnCount = int.Parse(size);

            dataGridView2.RowCount = int.Parse(size);
            dataGridView2.ColumnCount = 1;

            Random r = new Random();
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = r.Next(3, 10);
                }
            }

            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                for (int j = 0; j < dataGridView2.ColumnCount; j++)
                {
                    dataGridView2.Rows[i].Cells[j].Value = r.Next(3, 10);
                }
            }
            sizeForFunc = int.Parse(size);
        }
        public Tuple<double[,],double[]> GetFromD()
        {
            double[,] A = new double[sizeForFunc, sizeForFunc];
            double[] B = new double[sizeForFunc];
            for(int i=0;i<sizeForFunc;i++)
            {
                for(int j=0;j<sizeForFunc;j++)
                {
                    A[i, j] = double.Parse(dataGridView1.Rows[i].Cells[j].Value.ToString());
                }
            }
            for (int i = 0; i < sizeForFunc; i++)
            {
                for (int j = 0; j < 1; j++)
                    {
                        B[i] = double.Parse(dataGridView2.Rows[i].Cells[j].Value.ToString());
                    }
            }
            var result = Tuple.Create(A, B);
            return result;
        }

        public static double Rax1(double[,] A, double[] B, double[] x0)
        {
            double[] res = new double[B.GetLength(0)];
            double[] res1 = new double[B.GetLength(0)];
            double[] res2 = new double[B.GetLength(0)];
            double[] res3 = new double[B.GetLength(0)];
            double r1 = 0;
            //1 формула
            for (int row = 0; row < A.GetLength(0); row++)
            {
                for (int col = 0; col < A.GetLength(1); col++)
                {
                    res[col] += A[row, col] * x0[row];
                }
            }
            for (int i = 0; i < res.Length; i++)
            {
                res[i] = res[i] - B[i];
            }
            //2 формула
            for (int row = 0; row < A.GetLength(0); row++)
            {
                for (int col = 0; col < A.GetLength(1); col++)
                {
                    res1[col] += A[row, col] * res[row];
                }
            }
            for (int i = 0; i < res1.Length; i++)
            {
                if (res1[i] < 0)
                {
                    res1[i] *= -1;
                }
            }
            var max = res1.ToList().Max();

            double result = 0;
            for (int i = 0; i < res.Length; i++)
            {
                result += res[i] * res1[i];
            }
            if (result < 0)
            {
                result *= -1;
            }
            r1 = result / Math.Pow(max, 2);
            return r1;
        }

            public static double[] Rax(double[,] A, double[] B, double[] x0)
        {
            double[] res = new double[B.GetLength(0)];
            double[] res1 = new double[B.GetLength(0)];
            double[] res2 = new double[B.GetLength(0)];
            double[] res3 = new double[B.GetLength(0)];
            double r1 = 0;
            //1 формула
            for (int row = 0; row < A.GetLength(0); row++)
            {
                for (int col = 0; col < A.GetLength(1); col++)
                {
                    res[col] += A[row, col] * x0[row];
                }
            }
            for (int i = 0; i < res.Length; i++)
            {
                res[i] = res[i] - B[i];
            }
            //2 формула
            for (int row = 0; row < A.GetLength(0); row++)
            {
                for (int col = 0; col < A.GetLength(1); col++)
                {
                    res1[col] += A[row, col] * res[row];
                }
            }
            for (int i = 0; i < res1.Length; i++)
            {
                if (res1[i] < 0)
                {
                    res1[i] *= -1;
                }
            }
            var max = res1.ToList().Max();

            double result = 0;
            for (int i = 0; i < res.Length; i++)
            {
                result += res[i] * res1[i];
            }
            if (result < 0)
            {
                result *= -1;
            }
            r1 = result / Math.Pow(max, 2);
            //3 формула
            double[] vidn = new double[B.GetLength(0)];
            for (int i = 0; i < vidn.Length; i++)
            {
                vidn[i] = r1 * res[i];
            }

            for (int i = 0; i < res2.Length; i++)
            {
                 res2[i] = x0[i] - vidn[i];
            }
            
            return res2;
        }
        private void OutPut(double[] A)
        {
            for (int i = 0; i < A.Length; i++)
            {
                textBox1.Text+=($"{Math.Round(A[i],4)} ");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            string epsInput = Interaction.InputBox("Введіть, будь ласка, наближення", "наближення");
            double[] x0 = new double[sizeForFunc];
            var h = GetFromD();
            if(checkBox1.Checked)
            {
                x0 = ReadVectorFromFile(pochNabl);
                var zeroIteration = ReadVectorFromFile(pochNabl);
                for (int i = 0; i < sizeForFunc; i++)
                {
                    textBox1.Text += ($"{Math.Round(zeroIteration[i], 4)} ");
                }
                textBox1.Text += "\r\n";
            }
            else
            {
                for (int i = 0; i < sizeForFunc; i++)
                {
                    for (int j = 0; j < 1; j++)
                    {
                        x0[i] = double.Parse(dataGridView2.Rows[i].Cells[j].Value.ToString());
                    }
                }
                var zeroIteration = x0 ;
                for (int i = 0; i < sizeForFunc; i++)
                {
                    textBox1.Text += ($"{Math.Round(zeroIteration[i], 4)} ");
                }
                textBox1.Text += "\r\n";
            }
            bool conti_iter = true;
            while (conti_iter)
            {
                double[] X = Rax(h.Item1, h.Item2, x0);
                double r = Rax1(h.Item1, h.Item2, x0);
                double[] rizn = new double[X.Length];
                for (int i = 0; i < X.Length; i++)
                {
                    rizn[i] = Math.Abs(X[i] - x0[i]);
                }
                textBox1.Text +=Math.Round(r,4)+"\r\n------------------------------------------------------------------------\r\n";
                OutPut(X);
                textBox1.Text += "\r\n";
                if (rizn.ToList().Max() < double.Parse(epsInput))
                {
                    conti_iter = false;
                }
                x0 = X;
                
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, textBox1.Text);
            }
            MessageBox.Show(
        "       Успішно збережено!",
        ""
        );
        }

        private void button5_Click(object sender, EventArgs e)
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
                SaveFileDialog sfd = new SaveFileDialog();
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(sfd.FileName, textBox1.Text);
                }
                MessageBox.Show(
            "       Успішно збережено!",
            ""
            );
                this.Close();
            }
            if (result == DialogResult.No)
            {
                this.Close();
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox2.Checked = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
        }
    }
}
