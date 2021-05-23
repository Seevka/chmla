using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Windows.Forms;

namespace chmla
{
    public partial class Form5 : Form
    {
        string size;
        int sizeForFunc;
        double[,] firstMatrix;
        double[] firtstVector;
        const string matrixFilePath = @"C:\Users\Sevka\source\repos\chmla\chmla\Matrix.txt";
        const string firstNablFilePath = @"C:\Users\Sevka\source\repos\chmla\chmla\Vector.txt";
        public Form5()
        {
            InitializeComponent();
            this.dataGridView1.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 17);
            this.dataGridView2.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 17);
        }

        private void Form5_Load(object sender, EventArgs e)
        {

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

        static double[,] Gaus(double[,] a, int n)
        {
            int k, i, j;
            double[,] b = new double[n, n];
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        b[i, j] = 1;
                    }
                    else
                    {
                        b[i, j] = 0;
                    }
                }
            }

            for (k = 0; k < n; k++)
            {
                int i_m = k;
                double max = Math.Abs(a[k, k]);
                for (i = k + 1; i < n; i++)
                {
                    if (max < Math.Abs(a[i, k]))
                    {
                        max = Math.Abs(a[i, k]);
                        i_m = i;
                    }
                }
                if (max == 0)
                {
                    MessageBox.Show("Incorrect matrix; Max 0");
                    break;
                }
                else
                {
                    for (j = k; j < n; j++)
                    {
                        double x = a[k, j];
                        a[k, j] = a[i_m, j];
                        a[i_m, j] = x;

                    }
                    for (j = 0; j < n; j++)
                    {
                        double x = b[k, j];
                        b[k, j] = b[i_m, j];
                        b[i_m, j] = x;
                    }
                    double r = 1 / a[k, k];
                    for (j = 0; j < n; j++)
                    {
                        a[k, j] = a[k, j] * r;
                        b[k, j] = b[k, j] * r;
                    }
                    for (i = k + 1; i < n; i++)
                    {
                        double res = a[i, k];
                        for (int z = 0; z < n; z++)
                        {
                            a[i, z] = a[i, z] - a[k, z] * res;
                            b[i, z] = b[i, z] - b[k, z] * res;
                        }

                    }

                }
            }

            if (Double.IsNaN(Det(a, n)) || Det(a, n) == 0)
            {
                MessageBox.Show("Incorrect matrix!Determinant = 0");
            }
            else
            {
                for (k = n - 1; k >= 0; k--)
                {
                    for (i = k - 1; i >= 0; i--)
                    {
                        double rez = a[i, k];
                        for (int z = n - 1; z >= 0; z--)
                        {
                            a[i, z] = a[i, z] - a[k, z] * rez;
                            b[i, z] = b[i, z] - b[k, z] * rez;
                        }
                    }
                }
            }
            return b;

        }
        static double Det(double[,] a, int n)
        {
            double det = 1;
            for (int i = 0; i < n; i++)
            {
                det *= Math.Round(a[i, i]);
            }
            return det;
        }
        static double scalar(double[] a, double[] b, int n)
        {
            double c = 0;
            for (int i = 0; i < n; i++)
            {
                c += a[i] * b[i];
            }
            return c;
        }
        static double[] dil(double[] a, double b, int n)
        {
            double[] c = new double[n];
            for (int i = 0; i < n; i++)
            {
                c[i] = a[i] / b;
            }
            return c;
        }
        static double[] matr_vec(double[,] a, double[] b, int n)
        {
            double[] c = new double[n];
            for (int i = 0; i < n; i++)
            {
                c[i] = 0;
                for (int j = 0; j < n; j++)
                {
                    c[i] += a[i, j] * b[j];
                }
            }
            return c;
        }
        static double min(double[] a, int n)
        {
            double min = Math.Abs(a[0]);
            for (int i = 1; i < n; i++)
            {
                if (min > Math.Abs(a[i]))
                {
                    min = Math.Abs(a[i]);
                }
            }
            return min;
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
            firtstVector = ReadVectorFromFile(firstNablFilePath);
            dataGridView1.RowCount = firstMatrix.GetLength(0);
            dataGridView1.ColumnCount = firstMatrix.GetLength(0);
            sizeForFunc = firstMatrix.GetLength(0);

            dataGridView2.RowCount = firstMatrix.GetLength(0);
            dataGridView2.ColumnCount = 1;

            for (int i = 0; i < firstMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < firstMatrix.GetLength(0); j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = firstMatrix[i, j];
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

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            int n = sizeForFunc;
            string epsInput = Interaction.InputBox("Введіть, будь ласка, точність", "Точність");
            double[,] a = new double[n, n];
            double[,] a_1 = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    a[i, j] = double.Parse(dataGridView1.Rows[i].Cells[j].Value.ToString());
                }
            }
            double eps = double.Parse(epsInput);
            double[] y = new double[n];
            double[] x = new double[n];
            double l;
            double l_k;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    y[i] = double.Parse(dataGridView2.Rows[i].Cells[j].Value.ToString());
                }
            }
            double s0 = scalar(y, y, n);
            x = dil(y, Math.Sqrt(s0), n);

            a_1 = Gaus(a, n);
            y = matr_vec(a_1, x, n);
            s0 = scalar(y, y, n);
            double t = scalar(y, x, n);
            l = s0 / t;

            for (int i = 0; i < n; i++)
            {
                l += y[i] / x[i] / n;
            }
            x = dil(y, Math.Sqrt(s0), n);
            double u;
            do
            {
                u = l;
                y = matr_vec(a_1, x, n);
                s0 = scalar(y, y, n);
                l_k = 0;
                for (int i = 0; i < n; i++)
                {
                    l_k += y[i] / x[i] / n;
                }
                l = l_k;
                x = dil(y, Math.Sqrt(s0), n);
            } while (Math.Abs(u - l_k) > eps);
            x = dil(x, min(x, n), n);
            textBox1.Text+=($"Lambda: {Math.Round(1 / l_k, 5)}\r\n");
            for (int i = 0; i < n; i++)
            {
                textBox1.Text+=($"x{i} = {Math.Round(x[i], 5)}\r\n");
            }

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
    }
}
