using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.IO;
using System.Drawing;

namespace chmla
{
    public partial class Form3 : Form
    {
        string size;
        int sizeForFunc;
        double[][] firstMatrix;
        double[] firtstVector;
        double[][] U;
        double[][] V;
        double[] temp;
        double[] L;
        double[] T;
        const string matrixFilePath = @"C:\Users\Sevka\source\repos\chmla\chmla\Matrix.txt";
        const string vectorFilePath = @"C:\Users\Sevka\source\repos\chmla\chmla\Vector.txt";


        public Form3()
        {
            InitializeComponent();
            this.dataGridView1.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 17);
            this.dataGridView2.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 17);

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

        static double scalar(double[] a, double[] b, int size)
        {
            double P = 0;
            for (int j = 0; j < size; j++)
            {
                P += a[j] * b[j];
            }
            return P;
        }
        private void Calculate(int size_)
        {
            U = new double[size_][];
            V = new double[size_][];
            double[][] A = new double[size_][];
            for (int i = 0; i < (size_); i++)
            {
                A[i] = new double[size_];
                U[i] = new double[size_];
                V[i] = new double[size_];
                for (int j = 0; j < size_; j++)
                {
                    A[i][j] = double.Parse(dataGridView1.Rows[i].Cells[j].Value.ToString());
                }
            }

            double[] F = new double[size_];
            for (int i = 0; i < size_; i++)
                for (int j = 0; j < 1; j++)
                {
                    {
                        F[i] = double.Parse(dataGridView2.Rows[i].Cells[j].Value.ToString());
                    }
                }
            temp = new double[size_];
            L = new double[size_];
            T = new double[size_];
            //Начальная иттерация:

            for (int i = 0; i < size_; i++)
            {
                U[0][i] = (A[0][i]);               //U[0]
            }
            L[0] = Math.Sqrt(scalar(U[0], U[0], size_));       //L[0]
            for (int i = 0; i < size_; i++)
            {
                V[0][i] = U[0][i] * (1 / L[0]);    //V[0]
            }
            T[0] = F[0] / L[0];                     //H[0]

            //Последующие иттерации
            int count = 1; //Счетчик переменных для которых уже найдены первые значения 
            int n = 0;
            double t;


            do
            {
                double temp_h;
                temp_h = 0;

                for (int i = 0; i < size_; i++)
                {
                    temp[i] = 0;
                }
                //U_i
                for (int j = 0; j <= count - 1; j++)
                {
                    t = scalar(A[count], V[j], size_); //Получили c[i,j] 

                    for (int i = 0; i < size_; i++)
                    {
                        temp[i] = temp[i] + (t * V[j][i]); //Получили c[i,j]*v[k]

                    }
                    temp_h += t * T[j];
                }


                //Нашли U
                for (int i = 0; i < size_; i++)
                {
                    U[count][i] = A[count][i] - temp[i];
                }

                //Нашли L
                L[count] = Math.Sqrt(scalar(U[count], U[count], size_));

                //Нашли H
                T[count] = (F[count] - temp_h) / (L[count]);

                //V_[i]
                for (int i = 0; i <size_; i++)
                {
                    V[count][i] = (1 / L[count]) * (U[count][i]);
                }

                n++;
                count++;

            } while (count < size_);

            double x = 0;
            for (int i = 0; i < size_; i++)
            {
                for (int j = 0; j < size_; j++)
                {
                    x += V[j][i] * T[j];
                }
                textBox1.Text+=($"X_{i + 1} = {Math.Round(x,3)}{Environment.NewLine}");
                //cout << "X_" << i + 1 << " = " << x << endl;
                x = 0;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Calculate(sizeForFunc);
            
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
                    dataGridView1.Rows[i].Cells[j].Value = firstMatrix[i][j];
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

        private double[][] ReadArrayFromFile(string file)
        {
            StreamReader file_ = new StreamReader(file);
            string s = file_.ReadToEnd();
            file_.Close();
            string[] row = s.Split('\n');
            string[] column = row[0].Split(' ');
            double[][] a = new double[row.Length][];
            double t = 0;
            int n = 0;
            for (int i = 0; i < row.Length; i++)
            {
                a[i] = new double[column.Length];
                column = row[i].Split(' ');
                for (int j = 0; j < column.Length; j++)
                {
                    t = double.Parse(column[j]);
                    a[i][j] = t;
                }
            }

            return a;
        }

        private double[] ReadVectorFromFile(string file)
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
                    dataGridView1.Rows[i].Cells[j].Value =r.Next(3, 10);
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
    }
}
