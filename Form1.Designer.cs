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
            this.buttonSearch = new System.Windows.Forms.Button();
            this.comboBoxCategorySound = new System.Windows.Forms.ComboBox();
            this.buttonCreatePlaylist = new System.Windows.Forms.Button();
            this.panelPlayList = new System.Windows.Forms.Panel();
            this.radioButtonYandexSound = new System.Windows.Forms.RadioButton();
            this.radioButtonMuzoFon = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(244, 23);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(150, 23);
            this.buttonSearch.TabIndex = 0;
            this.buttonSearch.Text = "Искать";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // comboBoxCategorySound
            // 
            this.comboBoxCategorySound.FormattingEnabled = true;
            this.comboBoxCategorySound.Location = new System.Drawing.Point(419, 25);
            this.comboBoxCategorySound.Name = "comboBoxCategorySound";
            this.comboBoxCategorySound.Size = new System.Drawing.Size(184, 21);
            this.comboBoxCategorySound.TabIndex = 5;
            // 
            // buttonCreatePlaylist
            // 
            this.buttonCreatePlaylist.Location = new System.Drawing.Point(627, 23);
            this.buttonCreatePlaylist.Name = "buttonCreatePlaylist";
            this.buttonCreatePlaylist.Size = new System.Drawing.Size(150, 23);
            this.buttonCreatePlaylist.TabIndex = 6;
            this.buttonCreatePlaylist.Text = "Создать Плейлист";
            this.buttonCreatePlaylist.UseVisualStyleBackColor = true;
            this.buttonCreatePlaylist.Click += new System.EventHandler(this.buttonCreatePlaylist_Click);
            // 
            // panelPlayList
            // 
            this.panelPlayList.AutoScroll = true;
            this.panelPlayList.Location = new System.Drawing.Point(12, 70);
            this.panelPlayList.Name = "panelPlayList";
            this.panelPlayList.Size = new System.Drawing.Size(776, 356);
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
            this.radioButtonMuzoFon.Location = new System.Drawing.Point(158, 26);
            this.radioButtonMuzoFon.Name = "radioButtonMuzoFon";
            this.radioButtonMuzoFon.Size = new System.Drawing.Size(69, 17);
            this.radioButtonMuzoFon.TabIndex = 9;
            this.radioButtonMuzoFon.TabStop = true;
            this.radioButtonMuzoFon.Text = "MuzoFon";
            this.radioButtonMuzoFon.UseVisualStyleBackColor = true;
            this.radioButtonMuzoFon.CheckedChanged += new System.EventHandler(this.radioButtonMuzoFon_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.radioButtonMuzoFon);
            this.Controls.Add(this.radioButtonYandexSound);
            this.Controls.Add(this.panelPlayList);
            this.Controls.Add(this.buttonCreatePlaylist);
            this.Controls.Add(this.comboBoxCategorySound);
            this.Controls.Add(this.buttonSearch);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.ComboBox comboBoxCategorySound;
        private System.Windows.Forms.Button buttonCreatePlaylist;
        private System.Windows.Forms.Panel panelPlayList;
        private System.Windows.Forms.RadioButton radioButtonYandexSound;
        private System.Windows.Forms.RadioButton radioButtonMuzoFon;
    }
}

