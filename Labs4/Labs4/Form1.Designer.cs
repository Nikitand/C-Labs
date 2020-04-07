namespace Labs4
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Remove = new System.Windows.Forms.Button();
            this.Deleted = new System.Windows.Forms.Button();
            this.Get_by_index = new System.Windows.Forms.Button();
            this.Lenght = new System.Windows.Forms.Button();
            this.vowel = new System.Windows.Forms.Button();
            this.consonants = new System.Windows.Forms.Button();
            this.Result_remove = new System.Windows.Forms.Button();
            this.Result_index = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Clearr = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.sentence = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.words = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button150 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(49, 25);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(398, 52);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Remove
            // 
            this.Remove.Location = new System.Drawing.Point(49, 138);
            this.Remove.Name = "Remove";
            this.Remove.Size = new System.Drawing.Size(82, 49);
            this.Remove.TabIndex = 1;
            this.Remove.Text = "Замена";
            this.Remove.UseVisualStyleBackColor = true;
            this.Remove.Click += new System.EventHandler(this.Remove_Click);
            // 
            // Deleted
            // 
            this.Deleted.Location = new System.Drawing.Point(49, 213);
            this.Deleted.Name = "Deleted";
            this.Deleted.Size = new System.Drawing.Size(82, 50);
            this.Deleted.TabIndex = 2;
            this.Deleted.Text = "Удаление";
            this.Deleted.UseVisualStyleBackColor = true;
            this.Deleted.Click += new System.EventHandler(this.Deleted_Click);
            // 
            // Get_by_index
            // 
            this.Get_by_index.Location = new System.Drawing.Point(49, 283);
            this.Get_by_index.Name = "Get_by_index";
            this.Get_by_index.Size = new System.Drawing.Size(90, 54);
            this.Get_by_index.TabIndex = 3;
            this.Get_by_index.Text = "Получение по индексу";
            this.Get_by_index.UseVisualStyleBackColor = true;
            this.Get_by_index.Click += new System.EventHandler(this.Get_by_index_Click);
            // 
            // Lenght
            // 
            this.Lenght.Location = new System.Drawing.Point(85, 365);
            this.Lenght.Name = "Lenght";
            this.Lenght.Size = new System.Drawing.Size(322, 57);
            this.Lenght.TabIndex = 4;
            this.Lenght.Text = "Длина строки";
            this.Lenght.UseVisualStyleBackColor = true;
            this.Lenght.Click += new System.EventHandler(this.Lenght_Click);
            // 
            // vowel
            // 
            this.vowel.Location = new System.Drawing.Point(528, 154);
            this.vowel.Name = "vowel";
            this.vowel.Size = new System.Drawing.Size(160, 68);
            this.vowel.TabIndex = 5;
            this.vowel.Text = "Гласные ";
            this.vowel.UseVisualStyleBackColor = true;
            this.vowel.Click += new System.EventHandler(this.vowel_Click);
            // 
            // consonants
            // 
            this.consonants.Location = new System.Drawing.Point(352, 239);
            this.consonants.Name = "consonants";
            this.consonants.Size = new System.Drawing.Size(149, 60);
            this.consonants.TabIndex = 6;
            this.consonants.Text = "Согласные";
            this.consonants.UseVisualStyleBackColor = true;
            this.consonants.Click += new System.EventHandler(this.consonants_Click);
            // 
            // Result_remove
            // 
            this.Result_remove.Location = new System.Drawing.Point(164, 138);
            this.Result_remove.Name = "Result_remove";
            this.Result_remove.Size = new System.Drawing.Size(91, 49);
            this.Result_remove.TabIndex = 7;
            this.Result_remove.Text = "Вывод";
            this.Result_remove.UseVisualStyleBackColor = true;
            this.Result_remove.Click += new System.EventHandler(this.Result_remove_Click);
            // 
            // Result_index
            // 
            this.Result_index.Location = new System.Drawing.Point(164, 283);
            this.Result_index.Name = "Result_index";
            this.Result_index.Size = new System.Drawing.Size(91, 54);
            this.Result_index.TabIndex = 8;
            this.Result_index.Text = "Вывод";
            this.Result_index.UseVisualStyleBackColor = true;
            this.Result_index.Click += new System.EventHandler(this.Result_index_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(71, 100);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(147, 22);
            this.textBox2.TabIndex = 9;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // Clearr
            // 
            this.Clearr.Location = new System.Drawing.Point(541, 365);
            this.Clearr.Name = "Clearr";
            this.Clearr.Size = new System.Drawing.Size(159, 57);
            this.Clearr.TabIndex = 10;
            this.Clearr.Text = "Очистить";
            this.Clearr.UseVisualStyleBackColor = true;
            this.Clearr.Click += new System.EventHandler(this.Clearr_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(164, 213);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 49);
            this.button1.TabIndex = 11;
            this.button1.Text = "Вывод";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // sentence
            // 
            this.sentence.Location = new System.Drawing.Point(352, 154);
            this.sentence.Name = "sentence";
            this.sentence.Size = new System.Drawing.Size(149, 68);
            this.sentence.TabIndex = 12;
            this.sentence.Text = "Кол-во предложений";
            this.sentence.UseVisualStyleBackColor = true;
            this.sentence.Click += new System.EventHandler(this.sentence_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Введите замену";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(179, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "Ввод";
            // 
            // words
            // 
            this.words.Location = new System.Drawing.Point(528, 239);
            this.words.Name = "words";
            this.words.Size = new System.Drawing.Size(160, 60);
            this.words.TabIndex = 15;
            this.words.Text = "Кол-во слов";
            this.words.UseVisualStyleBackColor = true;
            this.words.Click += new System.EventHandler(this.words_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(516, 38);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(228, 22);
            this.textBox3.TabIndex = 16;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(608, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "Вывод";
            // 
            // button150
            // 
            this.button150.Location = new System.Drawing.Point(624, 100);
            this.button150.Name = "button150";
            this.button150.Size = new System.Drawing.Size(75, 23);
            this.button150.TabIndex = 18;
            this.button150.Text = "Кнопка";
            this.button150.UseVisualStyleBackColor = true;
            this.button150.Click += new System.EventHandler(this.button150_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button150);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.words);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sentence);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Clearr);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.Result_index);
            this.Controls.Add(this.Result_remove);
            this.Controls.Add(this.consonants);
            this.Controls.Add(this.vowel);
            this.Controls.Add(this.Lenght);
            this.Controls.Add(this.Get_by_index);
            this.Controls.Add(this.Deleted);
            this.Controls.Add(this.Remove);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Строковый калькулятор";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Remove;
        private System.Windows.Forms.Button Deleted;
        private System.Windows.Forms.Button Get_by_index;
        private System.Windows.Forms.Button Lenght;
        private System.Windows.Forms.Button vowel;
        private System.Windows.Forms.Button consonants;
        private System.Windows.Forms.Button Result_remove;
        private System.Windows.Forms.Button Result_index;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button Clearr;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button sentence;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button words;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button150;
    }
}

