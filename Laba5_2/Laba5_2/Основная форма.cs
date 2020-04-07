using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Laba5_2
{
    public partial class Основная_форма : Form
    {
        ToolStripLabel dateLabel;
        ToolStripLabel timeLabel;
        ToolStripLabel infoLabel;
        Timer timer;
        public class product
        {
            public string name;
            public DateTime date;
            public string number;
            public string type;
            public string weight;
            public string count;
            public string cost;

            public product(string name1,  string number1,  string weight1,  string count1, string type1, DateTime date1, string cost1)
            {
                name = name1;
                number = number1;
                weight = weight1;
                count = count1;
                type = type1;
                date = date1;
                cost = cost1;
            }

            public product ()
            {

            }

        }
        [Serializable]
        public class manufacture
        {
            public List<product> products;
            public string name;
            public string address;
            public string country;
            public string phone_number;

            public manufacture(List<product> m, string n, string a, string c,  string phone)
            {
                products = m;
                name = n;
                address = a;
                country = c;
                phone_number = phone;
              
            }
            public manufacture()
            {

            }
        }
        public Основная_форма()
        {
            InitializeComponent();
            infoLabel = new ToolStripLabel();
            infoLabel.Text = "Текущие дата и время:";
            dateLabel = new ToolStripLabel();
            timeLabel = new ToolStripLabel();

            statusStrip1.Items.Add(infoLabel);
            statusStrip1.Items.Add(dateLabel);
            statusStrip1.Items.Add(timeLabel);

            timer = new Timer() { Interval = 1000 };
            timer.Tick += timer_Tick;
            timer.Start();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            dateLabel.Text = DateTime.Now.ToLongDateString();
            timeLabel.Text = DateTime.Now.ToLongTimeString();
            Countlabel.Text = buff.Count.ToString();
        }
        public List<product> buff = new List<product>();
        void show_product(int pos)
        {
            textBox1.Text = buff[pos].name;
            textBox2.Text = buff[pos].number;
            trackBar1.Value = Convert.ToInt32(buff[pos].weight);
            domainUpDown1.Text = buff[pos].count;
            comboBox1.Text = buff[pos].type;
            dateTimePicker1.Value = buff[pos].date;
            textBox3.Text = buff[pos].cost;

        }
        public void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private bool Validate()
        {
            if (string.IsNullOrEmpty(textBox2.Text))
                return false;
            if (string.IsNullOrEmpty(textBox1.Text))
                return false;
            if (string.IsNullOrEmpty(dateTimePicker1.Text))
                return false;
            if (string.IsNullOrEmpty(domainUpDown1.Text))
                return false;
            if (string.IsNullOrEmpty(comboBox1.Text))
                return false;
            if (string.IsNullOrEmpty(textBox6.Text))
                return false;
            if (string.IsNullOrEmpty(textBox3.Text))
                return false;
            return true;
        }
        private bool Validate1()
        {
            if (string.IsNullOrEmpty(textBox4.Text))
                return false;
            if (string.IsNullOrEmpty(country.Text))
                return false;
            if (string.IsNullOrEmpty(phone_number.Text))
                return false;
            if (string.IsNullOrEmpty(textBox6.Text))
                return false;
            return true;
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        int position = 0;
        private void button2_Click(object sender, EventArgs e)
        {


            if (position != buff.Count - 1)

                position++;
            show_product(position);

       
           

        }
        private void button3_Click(object sender, EventArgs e)
        {
            
                if (position != 0)
               {
                    position--;
                }
              
               
                show_product(position);
        
        }
        // Добавление
        private void button1_Click(object sender, EventArgs e)
        {
            if (!Validate())
            {
                MessageBox.Show("Не вся информацию о товаре!",
                   "Ошибка",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Warning);
                return;
            }

            if (Regex.IsMatch(textBox2.Text, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])\S{1,8}$", RegexOptions.IgnoreCase))
            {
                MessageBox.Show("Номер введён верно");
                product x = new product(textBox1.Text, textBox2.Text, Convert.ToString(trackBar1.Value), domainUpDown1.Text, comboBox1.Text, dateTimePicker1.Value, textBox3.Text);
                buff.Add(x);
            }
            else
            {
                MessageBox.Show("ERROR"); 
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label5.Text = " Вес - " + trackBar1.Value.ToString() + " Кг.";
        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        manufacture x1;
        private void button4_Click(object sender, EventArgs e)
        {
            if (!Validate1())
            {
                MessageBox.Show("Не вся информацию о товаре!",
                   "Ошибка",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Warning);
                return;
            }
            x1 = new manufacture(buff, textBox4.Text, country.Text, textBox6.Text, phone_number.Text);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void country_TextChanged(object sender, EventArgs e)
        {

        }

        private void phone_number_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
     
        private void serialization_Click(object sender, EventArgs e)
        {
          
                XmlSerializer formatter2 = new XmlSerializer(typeof(manufacture));
                using (FileStream fs = new FileStream("Product.xml", FileMode.OpenOrCreate))
                {
                    manufacture manufacture1 = (manufacture)formatter2.Deserialize(fs);
                    buff = manufacture1.products;
                    show_product(0);
                    textBox4.Text = manufacture1.name;
                    textBox6.Text = manufacture1.address;
                    country.Text = manufacture1.country;
                    phone_number.Text = manufacture1.phone_number;
                }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(manufacture));

           
            using (FileStream fs = new FileStream("Product.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, x1);

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void domainUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Information_Click(object sender, EventArgs e)
        {
            MessageBox.Show("    Версия: 1.1; \n  Осоприлко Никита Эдуардович", "О программе",
                MessageBoxButtons.OK,
                       MessageBoxIcon.Information);
        }

        private void Find_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(buff);
            form2.Show();
        }
        
       
        private void toolStripStatusLabel1_Click_1(object sender, EventArgs e)
        {
         
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void Countlabel_Click(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
    public class UserNameAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                string number = value.ToString();
                if (!number.StartsWith("VIM"))
                    return true;
                else
                    this.ErrorMessage = " должно начинаться с VIN";
            }
            return false;
        }
    }
}
