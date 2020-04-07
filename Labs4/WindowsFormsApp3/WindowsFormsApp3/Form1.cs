using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
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
        List<int> collect = new List<int> { };
        Random rand = new Random();
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if(textBox1.Text.Length>=4)
                {
                    textBox1.Clear();
                }
                textBox2.Clear();
                collect.Clear();
                for (int i = 0; i < Convert.ToInt32(textBox1.Text); i++)
                {
                    collect.Add(rand.Next(999));
                }
                foreach (int p in collect)
                {
                    textBox2.Text += Convert.ToString(p) + "\r\n";
                }
            }
            catch
            {
                textBox1.Text = "Ошибка ввода";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PoVozrast sortirovka = new PoVozrast();
            collect.Sort(sortirovka);
            textBox2.Clear();
            foreach(int p in collect)
            {
                textBox2.Text += Convert.ToString(p) + "\r\n";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PoUbivan sortirovka = new PoUbivan();
            collect.Sort(sortirovka);
            textBox2.Clear();
            foreach (int p in collect)
            {
                textBox2.Text += Convert.ToString(p) + "\r\n";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            int min = collect.Min();
            int max = collect.Max();
            double average = collect.Average();
            textBox3.Text ="min:" + Convert.ToString(min) + "\r\n";
            textBox3.Text += "max:"+ Convert.ToString(max);
            textBox3.Text += "Average: " + Convert.ToString(average);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            var selected = from t in collect
                           where t <= 100 && t >= 0
                           select t;
            foreach (int p in selected)
            {
                textBox3.Text += Convert.ToString(p) + "\r\n";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
             int a = collect.Sum();

            textBox3.Text += Convert.ToString(a);
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    class PoVozrast : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (x == 0 || y == 0)
            {
                return 0;
            }
            return x.CompareTo(y);
        }
    }
    class PoUbivan : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (x == 0 || y == 0)
            {
                return 0;
            }
            return y.CompareTo(x);
        }
    }
}
