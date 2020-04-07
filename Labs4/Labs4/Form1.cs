using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labs4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // Подсчёт кол-во символов
        private void Lenght_Click(object sender, EventArgs e)
        {
            int count = textBox1.TextLength;
            textBox1.Text = Convert.ToString(count);
        }
        //
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
        }
        // Изменение строки
        string stroka;
        private void Remove_Click(object sender, EventArgs e)
        {   
            stroka = textBox1.Text;
            
        }
        string stroka_3;
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
         
        }
        string str1;
        private void Result_remove_Click(object sender, EventArgs e)
        
        {
           
            try
            {
                if (stroka.Contains(textBox3.Text))
                {
                    textBox3.Text=  stroka.Replace(textBox3.Text, textBox2.Text);
                   
                }
            }
            catch
            {
                textBox3.Text = "Нет такой подстроки в этой строке";
            }
            

            

        }
     // Вывод по индексу
        string stroka_4;
        private void Get_by_index_Click(object sender, EventArgs e)
        {
           stroka_4 = textBox1.Text;
             
        }        
        private void Result_index_Click(object sender, EventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(textBox2.Text);
                int i;

                for (i = 1; i < stroka_4.Length + 1; i++)
                {
                    if (i == index)
                    {
                        textBox3.Text = Convert.ToString(stroka_4[i - 1]);
                        break;
                    }
                }
            }
            catch
            {
                textBox3.Text = "Нет такой подстроки";
            }
        }
        // Удаление
        string stroka_5;
        private void Deleted_Click(object sender, EventArgs e)
        {
            stroka_5 = textBox1.Text;
            
        }
    

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (stroka_5.Contains(textBox2.Text))
                {
                    textBox3.Text =  stroka_5.Replace(textBox2.Text, "");
                }
            }
            catch
            {
                textBox3.Text = "Нет такой подстроки в этой строке";
            }
        }
        // Очистка 
        private void Clearr_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void sentence_Click(object sender, EventArgs e)
        {
            
            int count = 0;
            int i;
            try
            {
                for (i = 1; i < textBox1.Text.Length + 1; i++)
                {
                    if (textBox1.Text[i] == '.' || textBox1.Text[i] == '?' || textBox1.Text[i] == '!' || textBox1.Text == "\0")
                    {
                        count++;

                    }
                }
            }
            catch (IndexOutOfRangeException)
            {
                textBox3.Text = "Предел";
            }
            textBox3.Text = Convert.ToString(count) + " предложения(-ий)";
        }

        private void vowel_Click(object sender, EventArgs e)
        {
            char[] a = textBox1.Text.ToCharArray();
            int count = 0;            
            char[] letter = { 'a', 'A', 'ё', 'Ё', 'Я', 'я', 'Е', 'е', 'у', 'У', 'ы', 'Ы', 'о', 'О', 'Э', 'э', 'и', 'И', 'ю', 'Ю' };
            try
            {
                for (int i = 0; i < a.Length; i++)
                {
                    for (int j = 0; j < letter.Length; j++)
                    {
                        if (a[i] == letter[j])
                        {
                            count++;
                            break;
                        }
                    }
                }
            }
            catch 
            {
                textBox3.Text = "исключение";
            }
            textBox3.Text = Convert.ToString(count) + " гласных(-ая)";
        }

        private void consonants_Click(object sender, EventArgs e)
        {
            char[] a = textBox1.Text.ToCharArray();
                int count = 0;
            int i;
            char[] letter = { 'a', 'A', 'ё', 'Ё', 'Я', 'я', 'Е', 'е', 'у', 'У', 'ы', 'Ы', 'о', 'О', 'Э', 'э', 'и', 'И', 'ю', 'Ю' }; 
            try
            {
                for (i = 0; i < a.Length ; i++)
                {
                    for (int j = 0; j < letter.Length; j++)
                    {
                        if (a[i] != letter[j])
                        {

                            count++;
                            break;
                        }
                    }
                   
                }
            }
            catch 
            {
                textBox3.Text = "исключение";
            }
            textBox3.Text = Convert.ToString(count) + " cогласных(-ая)";
            
        }

        private void words_Click(object sender, EventArgs e)
        {
            int count = 0;
       
            try
            {
              string[] word =   textBox1.Text.Split(new char[] { ' ' });

                foreach (string s in word)
                {
                    count++;
                }
            }
            catch 
            {
                textBox3.Text = "Предел";
            }
            textBox3.Text = Convert.ToString(count) + " слов(-а)";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button150_Click(object sender, EventArgs e)
        {

        }
    }
}
