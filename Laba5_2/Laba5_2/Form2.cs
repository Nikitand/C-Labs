using System;
using System.Activities.Validation;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Xml.Serialization;
using static Laba5_2.Основная_форма;

namespace Laba5_2
{
    public partial class Form2 : Form
    {
      public  List<product> Buff2;
        public Form2(List<product> buff)
        {
            InitializeComponent();
            Buff2 = buff;
        }
       

      
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
      
    
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
        public class serializations
        {
            public List<product> Serialz;
            public string Big;
            public serializations()
            { }
            public serializations(string g)
            {
                Big = g;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length != 0)
            {
                richTextBox1.Clear();
            }
            if (cost.Checked)
            {
                Search_COST();
                return;
            }
            else if (name.Checked)
            {
                Search_NAME();
                return;
            }
            else if (radioButton2.Checked)
            {
                Search_TYPE();
                return;
            }
            else if (Name_1.Checked)
            {
                Sortirovka_NAME();
                return;


            }
            else if (cost_1.Checked)
            {
                Sortirovka_Date();
                return;


            }
            else if (Date_create.Checked)
            {
                Sortirovka_cost();
                return;
            }


        }
        
        void Search_NAME()
        {
            Regex regex = new Regex(Convert.ToString(textBox1.Text), RegexOptions.IgnoreCase);
            for (int i = 0; i < Buff2.Count; i++)
            {
               Match match =  regex.Match(Buff2[i].name);
                if (match.Success)
                {
                    richTextBox1.Text += $" ПО НАЗВАНИЮ\n Название: {Buff2[i].name} \n Номер: {Buff2[i].number} \n  " +
                        $" Тип: {Buff2[i].type} \n Вес: {Buff2[i].weight} \n Кол-во: {Buff2[i].count} \n " +
                        $"Дата: {Buff2[i].date} \n Стоимость: {Buff2[i].cost} \n \n";
                }
            }
            serializations x = new serializations(richTextBox1.Text);
            
            XmlSerializer formatter = new XmlSerializer(typeof(serializations));


            using (FileStream fs = new FileStream("search_name.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, x);

            }
        }
        void Search_COST()
        {
            Regex regex = new Regex(Convert.ToString(textBox1.Text), RegexOptions.IgnoreCase);
            for (int i = 0; i < Buff2.Count; i++)
            {
                Match match = regex.Match(Buff2[i].cost);
                if (match.Success)
                {
                    richTextBox1.Text += $"ПО СТОИМОСТИ\n Название: {Buff2[i].name} \n Номер: {Buff2[i].number} \n  " +
                        $" Тип: {Buff2[i].type} \n Вес: {Buff2[i].weight} \n Кол-во: {Buff2[i].count} \n " +
                        $"Дата: {Buff2[i].date} \n Стоимость: {Buff2[i].cost} \n\n";
                }
            }
            serializations x = new serializations(richTextBox1.Text);

            XmlSerializer formatter = new XmlSerializer(typeof(serializations));


            using (FileStream fs = new FileStream("search_cost.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, x);

            }
        }
        void Search_TYPE()
        {
            Regex regex = new Regex(Convert.ToString(textBox1.Text), RegexOptions.IgnoreCase);
            for (int i = 0; i < Buff2.Count; i++)
            {
                Match match = regex.Match(Buff2[i].type);
                if (match.Success)
                {
                    richTextBox1.Text += $" ПО ТИПУ \n Название: {Buff2[i].name} \n Номер: {Buff2[i].number} \n  " +
                        $" Тип: {Buff2[i].type} \n Вес: {Buff2[i].weight} \n Кол-во: {Buff2[i].count} \n " +
                        $" Дата: {Buff2[i].date} \n Стоимость: {Buff2[i].cost}\n\n ";
                }
            }
            serializations x = new serializations(richTextBox1.Text);

            XmlSerializer formatter = new XmlSerializer(typeof(serializations));


            using (FileStream fs = new FileStream("search_tyoe.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, x);

            }
        }
        void Sortirovka_NAME()
        {
            var sortedUsers = from a in Buff2
                              orderby a.name
                              select a;
            foreach (var s in sortedUsers)
            {
                richTextBox1.Text += $"ПО НАЗВАНИЮ\n Название: {s.name} \n Номер: {s.number} \n  " +
                        $" Тип: {s.type} \n Вес: {s.weight} \n Кол-во: {s.count} \n " +
                        $"Дата: {s.date} \n Стоимость: {s.cost} \n\n";
            }
            serializations x = new serializations(richTextBox1.Text);

            XmlSerializer formatter = new XmlSerializer(typeof(serializations));


            using (FileStream fs = new FileStream("sortirovka_name.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, x);

            }
        }
        void Sortirovka_Date()
        {
            var sortedUsers = from a in Buff2
                              orderby a.date
                              select a;
            foreach (var s in sortedUsers)
            {
                richTextBox1.Text += $"ПО ДАТЕ\n Название: {s.name} \n Номер: {s.number} \n  " +
                        $" Тип: {s.type} \n Вес: {s.weight} \n Кол-во: {s.count} \n " +
                        $"Дата: {s.date} \n Стоимость: {s.cost} \n\n";
            }
            serializations x = new serializations(richTextBox1.Text);

            XmlSerializer formatter = new XmlSerializer(typeof(serializations));


            using (FileStream fs = new FileStream("date.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, x);

            }
        }
        void Sortirovka_cost()
        {
            var sortedUsers = from a in Buff2
                              orderby a.cost
                              select a;
            foreach (var s in sortedUsers)
            {
                richTextBox1.Text += $"ПО СТОИМОСТИ\n Название: {s.name} \n Номер: {s.number} \n  " +
                        $" Тип: {s.type} \n Вес: {s.weight} \n Кол-во: {s.count} \n " +
                        $"Дата: {s.date} \n Стоимость: {s.cost} \n\n";
            }
            serializations x = new serializations(richTextBox1.Text);

            XmlSerializer formatter = new XmlSerializer(typeof(serializations));


            using (FileStream fs = new FileStream("sortirovka_cost.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, x);

            }
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cost_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void name_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Date_create_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
 }
