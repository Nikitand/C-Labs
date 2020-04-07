using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba5_2
{

    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            worker = new Worker();
            
        }
        public class Worker
        {
            [Required(ErrorMessage = "Фамилия не установлена")]
            public string Surname { get; set; }
            [Required(ErrorMessage = "Имя не установлено")]
            public string Name { get; set; }
            [Required(ErrorMessage = "Отчество не установлено")]
            public string Father_name { get; set; }
            [Required]
            [StringLength(15, MinimumLength = 3, ErrorMessage = "Недопустимая длина ")]
            public  string experience { get; set; }
            public string id { get; set; }
        }

        private bool Validate()
        {
            if (string.IsNullOrEmpty(Surname.Text))
                return false;
            if (string.IsNullOrEmpty(Name.Text))
                return false;
            if (string.IsNullOrEmpty(Father_name.Text))
                return false;
            if (string.IsNullOrEmpty(experience.Text))
                return false;
            return true;
        }
        public Worker worker;
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Surname_TextChanged(object sender, EventArgs e)
        {

        }

        private void Name_TextChanged(object sender, EventArgs e)
        {

        }

        private void Father_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void experience_SelectedIndexChanged(object sender, EventArgs e)
        {
                       
        }
        
        private void input_Click(object sender, EventArgs e)
        {
            Основная_форма form = new Основная_форма();




            worker.Surname = Surname.Text;
                worker.Name = Name.Text;
                worker.Father_name = Father_name.Text;
                worker.experience = experience.Text;
                worker.id = textBox1.Text;
            
            if (Regex.IsMatch(worker.id, @"(^\w{2}[0-9]{7})", RegexOptions.IgnoreCase))
            {
                MessageBox.Show("Успешно");
                form.richTextBox1.Text = $"Фамилия: {worker.Surname} \nИмя: {worker.Name} \nОтчество: { worker.Father_name} \nОпыт работы: {worker.experience} " +
             $"\nНомер паспорта: {worker.id} ";


                var results = new List<ValidationResult>();
                var context = new ValidationContext(worker);
                if (!Validator.TryValidateObject(worker, context, results, false))
                {
                    foreach (var error in results)
                    {
                        MessageBox.Show(error.ErrorMessage, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return;
                }
                form.Show();
            }
            else
            {
                MessageBox.Show("Неверный номер паспорта");
            }
            //         MessageBox.Show("Ошибка!",
            //   "Ошибка",
            //   MessageBoxButtons.OK,
            //   MessageBoxIcon.Warning);
            //return;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
