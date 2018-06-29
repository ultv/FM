namespace FM
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
            this.comboBoxCategoryMood = new System.Windows.Forms.ComboBox();
            this.buttonCreatePlaylist = new System.Windows.Forms.Button();
            this.panelPlayList = new System.Windows.Forms.Panel();
            this.radioButtonYandexSound = new System.Windows.Forms.RadioButton();
            this.radioButtonMuzoFon = new System.Windows.Forms.RadioButton();
            this.comboBoxDuration = new System.Windows.Forms.ComboBox();
            this.textBoxArtist = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxCategoryMood
            // 
            this.comboBoxCategoryMood.Enabled = false;
            this.comboBoxCategoryMood.FormattingEnabled = true;
            this.comboBoxCategoryMood.Location = new System.Drawing.Point(214, 107);
            this.comboBoxCategoryMood.Name = "comboBoxCategoryMood";
            this.comboBoxCategoryMood.Size = new System.Drawing.Size(150, 21);
            this.comboBoxCategoryMood.TabIndex = 5;
            this.comboBoxCategoryMood.Text = "Настроение";
            this.comboBoxCategoryMood.SelectedIndexChanged += new System.EventHandler(this.comboBoxCategorySound_SelectedIndexChanged);
            // 
            // buttonCreatePlaylist
            // 
            this.buttonCreatePlaylist.Location = new System.Drawing.Point(733, 20);
            this.buttonCreatePlaylist.Name = "buttonCreatePlaylist";
            this.buttonCreatePlaylist.Size = new System.Drawing.Size(150, 23);
            this.buttonCreatePlaylist.TabIndex = 6;
            this.buttonCreatePlaylist.Text = "Поиск";
            this.buttonCreatePlaylist.UseVisualStyleBackColor = true;
            this.buttonCreatePlaylist.Click += new System.EventHandler(this.buttonCreatePlaylist_Click);
            // 
            // panelPlayList
            // 
            this.panelPlayList.AutoScroll = true;
            this.panelPlayList.Location = new System.Drawing.Point(12, 159);
            this.panelPlayList.Name = "panelPlayList";
            this.panelPlayList.Size = new System.Drawing.Size(895, 301);
            this.panelPlayList.TabIndex = 7;
            // 
            // radioButtonYandexSound
            // 
            this.radioButtonYandexSound.AutoSize = true;
            this.radioButtonYandexSound.Checked = true;
            this.radioButtonYandexSound.Location = new System.Drawing.Point(24, 26);
            this.radioButtonYandexSound.Name = "radioButtonYandexSound";
            this.radioButtonYandexSound.Size = new System.Drawing.Size(103, 17);
            this.radioButtonYandexSound.TabIndex = 8;
            this.radioButtonYandexSound.TabStop = true;
            this.radioButtonYandexSound.Text = "ЯндексМузыка";
            this.radioButtonYandexSound.UseVisualStyleBackColor = true;
            this.radioButtonYandexSound.CheckedChanged += new System.EventHandler(this.radioButtonYandexSound_CheckedChanged);
            // 
            // radioButtonMuzoFon
            // 
            this.radioButtonMuzoFon.AutoSize = true;
            this.radioButtonMuzoFon.Location = new System.Drawing.Point(155, 26);
            this.radioButtonMuzoFon.Name = "radioButtonMuzoFon";
            this.radioButtonMuzoFon.Size = new System.Drawing.Size(69, 17);
            this.radioButtonMuzoFon.TabIndex = 9;
            this.radioButtonMuzoFon.TabStop = true;
            this.radioButtonMuzoFon.Text = "MuzoFon";
            this.radioButtonMuzoFon.UseVisualStyleBackColor = true;
            this.radioButtonMuzoFon.CheckedChanged += new System.EventHandler(this.radioButtonMuzoFon_CheckedChanged);
            // 
            // comboBoxDuration
            // 
            this.comboBoxDuration.Enabled = false;
            this.comboBoxDuration.FormattingEnabled = true;
            this.comboBoxDuration.Location = new System.Drawing.Point(389, 107);
            this.comboBoxDuration.Name = "comboBoxDuration";
            this.comboBoxDuration.Size = new System.Drawing.Size(150, 21);
            this.comboBoxDuration.TabIndex = 10;
            this.comboBoxDuration.Text = "Длительность";
            // 
            // textBoxArtist
            // 
            this.textBoxArtist.Location = new System.Drawing.Point(24, 60);
            this.textBoxArtist.Name = "textBoxArtist";
            this.textBoxArtist.Size = new System.Drawing.Size(340, 20);
            this.textBoxArtist.TabIndex = 11;
            this.textBoxArtist.Text = "Исполнитель";
            // 
            // comboBox1
            // 
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(24, 107);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(164, 21);
            this.comboBox1.TabIndex = 13;
            this.comboBox1.Text = "Жанр";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(389, 59);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(494, 20);
            this.textBox2.TabIndex = 14;
            this.textBox2.Text = "Название";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(289, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 503);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBoxArtist);
            this.Controls.Add(this.comboBoxDuration);
            this.Controls.Add(this.radioButtonMuzoFon);
            this.Controls.Add(this.radioButtonYandexSound);
            this.Controls.Add(this.panelPlayList);
            this.Controls.Add(this.buttonCreatePlaylist);
            this.Controls.Add(this.comboBoxCategoryMood);
            this.Name = "Form1";
            this.Text = "Музыка для спорта";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxCategoryMood;
        private System.Windows.Forms.Button buttonCreatePlaylist;
        private System.Windows.Forms.Panel panelPlayList;
        private System.Windows.Forms.RadioButton radioButtonYandexSound;
        private System.Windows.Forms.RadioButton radioButtonMuzoFon;
        private System.Windows.Forms.ComboBox comboBoxDuration;
        private System.Windows.Forms.TextBox textBoxArtist;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
    }
}

