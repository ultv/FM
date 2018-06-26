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
            this.richTextBoxCatalogTrack = new System.Windows.Forms.RichTextBox();
            this.richTextBoxTrackDuration = new System.Windows.Forms.RichTextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.buttonDownload = new System.Windows.Forms.Button();
            this.comboBoxCategorySound = new System.Windows.Forms.ComboBox();
            this.buttonCreatePlaylist = new System.Windows.Forms.Button();
            this.panelPlayList = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(609, 41);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(150, 23);
            this.buttonSearch.TabIndex = 0;
            this.buttonSearch.Text = "Искать";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // richTextBoxCatalogTrack
            // 
            this.richTextBoxCatalogTrack.Location = new System.Drawing.Point(53, 41);
            this.richTextBoxCatalogTrack.Name = "richTextBoxCatalogTrack";
            this.richTextBoxCatalogTrack.Size = new System.Drawing.Size(405, 120);
            this.richTextBoxCatalogTrack.TabIndex = 1;
            this.richTextBoxCatalogTrack.Text = "";
            this.richTextBoxCatalogTrack.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBox1_LinkClicked);
            // 
            // richTextBoxTrackDuration
            // 
            this.richTextBoxTrackDuration.Location = new System.Drawing.Point(487, 41);
            this.richTextBoxTrackDuration.Name = "richTextBoxTrackDuration";
            this.richTextBoxTrackDuration.Size = new System.Drawing.Size(94, 120);
            this.richTextBoxTrackDuration.TabIndex = 2;
            this.richTextBoxTrackDuration.Text = "";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(61, 178);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(55, 13);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "linkLabel1";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // buttonDownload
            // 
            this.buttonDownload.Location = new System.Drawing.Point(157, 173);
            this.buttonDownload.Name = "buttonDownload";
            this.buttonDownload.Size = new System.Drawing.Size(75, 23);
            this.buttonDownload.TabIndex = 4;
            this.buttonDownload.Text = "Сохранить";
            this.buttonDownload.UseVisualStyleBackColor = true;
            this.buttonDownload.Click += new System.EventHandler(this.buttonDownload_Click);
            // 
            // comboBoxCategorySound
            // 
            this.comboBoxCategorySound.FormattingEnabled = true;
            this.comboBoxCategorySound.Location = new System.Drawing.Point(53, 222);
            this.comboBoxCategorySound.Name = "comboBoxCategorySound";
            this.comboBoxCategorySound.Size = new System.Drawing.Size(206, 21);
            this.comboBoxCategorySound.TabIndex = 5;
            // 
            // buttonCreatePlaylist
            // 
            this.buttonCreatePlaylist.Location = new System.Drawing.Point(295, 220);
            this.buttonCreatePlaylist.Name = "buttonCreatePlaylist";
            this.buttonCreatePlaylist.Size = new System.Drawing.Size(129, 23);
            this.buttonCreatePlaylist.TabIndex = 6;
            this.buttonCreatePlaylist.Text = "Создать Плейлист";
            this.buttonCreatePlaylist.UseVisualStyleBackColor = true;
            this.buttonCreatePlaylist.Click += new System.EventHandler(this.buttonCreatePlaylist_Click);
            // 
            // panelPlayList
            // 
            this.panelPlayList.AutoScroll = true;
            this.panelPlayList.Location = new System.Drawing.Point(12, 277);
            this.panelPlayList.Name = "panelPlayList";
            this.panelPlayList.Size = new System.Drawing.Size(776, 147);
            this.panelPlayList.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelPlayList);
            this.Controls.Add(this.buttonCreatePlaylist);
            this.Controls.Add(this.comboBoxCategorySound);
            this.Controls.Add(this.buttonDownload);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.richTextBoxTrackDuration);
            this.Controls.Add(this.richTextBoxCatalogTrack);
            this.Controls.Add(this.buttonSearch);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.RichTextBox richTextBoxCatalogTrack;
        private System.Windows.Forms.RichTextBox richTextBoxTrackDuration;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button buttonDownload;
        private System.Windows.Forms.ComboBox comboBoxCategorySound;
        private System.Windows.Forms.Button buttonCreatePlaylist;
        private System.Windows.Forms.Panel panelPlayList;
    }
}

