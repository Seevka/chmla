using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            TextBox t = new TextBox();
            Label l = new Label();
            l.Name = "q";
            t.Name = "t";
            TextBox t1 = new TextBox();
            t1.Name = "e";
            Label l1 = new Label();
            l1.Name = "q";
            TextBox t2 = new TextBox();
            Label l2 = new Label();
            l2.Name = "q";
            t2.Name = "t";
            Label l3 = new Label();
            l3.Name = "e1";
            TextBox t3 = new TextBox();
            t3.Name = "t";
            if (comboBox1.SelectedIndex == 1)
            {
                t.Location = new Point(72, 280);
                this.Controls.Add(t);
                l.Text = "X1";
                l.Location = new Point(178, 285);
                this.Controls.Add(l);
                //
                t1.Location = new Point(296, 280);
                this.Controls.Add(t1);
                l1.Text = "X2";
                l1.Location = new Point(402, 285);
                l1.AutoSize = true;
                this.Controls.Add(l1);
                //
                t2.Location = new Point(498, 280);
                this.Controls.Add(t2);
                l2.Text = "X3";
                l2.Location = new Point(604, 285);
                l2.AutoSize = true;
                this.Controls.Add(l2);
                //
                l3.Text = "=";
                l3.Font = new Font("Microsoft Sans Serif", 16);
                l3.Location = new Point(630, 276);
                l3.AutoSize = true;
                this.Controls.Add(l3);
                //
                t3.Location = new Point(680, 280);
                this.Controls.Add(t3);
            }
            if(comboBox1.SelectedIndex==0)
            {
                foreach (Control ctrl in this.Controls.OfType<Label>().Where(x => x.Name == "q")) { this.Controls.Remove(ctrl); }
                foreach (Control ctrl in this.Controls.OfType<TextBox>().Where(x => x.Name == "t")) { this.Controls.Remove(ctrl); }
                foreach (Control ctrl in this.Controls.OfType<TextBox>().Where(x => x.Name == "e")) { this.Controls.Remove(ctrl); }
                foreach (Control ctrl in this.Controls.OfType<Label>().Where(x => x.Name == "e1")) { this.Controls.Remove(ctrl); }
            }
                


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
    }
}
