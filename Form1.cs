﻿using System;


using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Runtime.InteropServices;
using FM.pages;


namespace FM
{
    public partial class Form1 : Form
    {
        static IWebDriver browser;

        /// <summary>
        /// ЯндексМузыка.
        /// </summary>
        IWebDriver audioConverter;

        IWebDriver ruSaveFromNet;
        PageHomeSaveFromNet pageHomeSaveFromNet;

        readonly static string urlYandexSound = "https://music.yandex.ru/genres";
        List<IWebElement> catalogCategoryYS;
        List<IWebElement> catalogTrackNameYS;
        By LinkRun = By.LinkText("Бег");
        By LinkAllTrack = By.LinkText("Все треки");        
        By LinkTrackName = By.CssSelector(".d-track__name a");
        By TxtTrackDuration = By.CssSelector(".d-track__info span");

        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindow(string _ClassName, string _WindowName);
        const int WM_KEYDOWN = 256;
        const int WM_KEYUP = 257;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int PostMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);


        /// <summary>
        /// Музофон.
        /// </summary>
        readonly static string urlMuzofon = "https://muzofond.org/";
        List<IWebElement> catalogCategoryMF;
        List<IWebElement> catalogTrackName;
        List<IWebElement> catalogIconPlay;
        List<IWebElement> catalogIconDownload;
        By LinkSportMusic = By.LinkText("Спортивная музыка");
        //By LinkSportMusic = By.CssSelector(".module-collections a");
        By LinkCatalogSportMusic = By.CssSelector(".module-layout a");

        string url = urlYandexSound;


        By LinkMeditationMusic = By.LinkText("Музыка Для Медитации");        
        By IconDownload = By.CssSelector("div.actions > ul > li.download > a");
        By TxtArtist = By.CssSelector("div.desc > h3 > span.artist");
        By TxtName = By.CssSelector("div.desc > h3 > span.track");
        By TxtDuration = By.CssSelector("div.duration");
        By IconPlay = By.CssSelector("div.actions > ul > li.play");
        //By BtnShowAll = By.CssSelector("body > div.container > div.content > div.module-popular > ul");
        By elTrackInfo = By.CssSelector("div.span.desktop > div > ul > li");

        




        public Form1()
        {
            InitializeComponent();
      //      SearchTrack();
        }

        /// <summary>
        /// К УДАЛЕНИЮ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            comboBoxCategorySound.Text = "";
            comboBoxCategorySound.Items.Clear();

            OpenBrowser(url);

            if(radioButtonYandexSound.Checked)
            {
                SelectYandexSound();
            }
            else
            {
                SelectMuzoFon();
            }
                                    
            this.Activate();
            browser.Manage().Window.Minimize();
        }

        /// <summary>
        /// Вывод треков.
        /// </summary>
        public void SearchTrack()
        {
            comboBoxCategorySound.Text = "";
            comboBoxCategorySound.Items.Clear();

            OpenBrowser(url);

            if (radioButtonYandexSound.Checked)
            {
                SelectYandexSound();
            }
            else
            {
                SelectMuzoFon();
            }

            this.Activate();
            browser.Manage().Window.Minimize();
        }

        /// <summary>
        /// Работа с сайтом ЯндексМузыка.
        /// </summary>
        private void SelectYandexSound()
        {
            //((IJavaScriptExecutor)browser).ExecuteScript("arguments[0].scrollIntoView();", browser.FindElement(LinkRun));
            //browser.FindElement(LinkRun).Click();

            //((IJavaScriptExecutor)browser).ExecuteScript("arguments[0].scrollIntoView();", browser.FindElement(LinkAllTrack));
            //browser.FindElement(LinkAllTrack).Click();

            ////WebDriverWait browserWait = new WebDriverWait(browser, TimeSpan.FromSeconds(15));
            ////IWebElement LinkTrackNameWait = browserWait.Until(ExpectedConditions.ElementIsVisible(LinkTrackName));

            /*
            List<IWebElement> catalogTrack = browser.FindElements(LinkTrackName).ToList();
            List<IWebElement> catalogTrackDuration = browser.FindElements(TxtTrackDuration).ToList();

            if (catalogTrack.Count > 0)
            {
                foreach (IWebElement element in catalogTrack)
                {
                    richTextBoxCatalogTrack.AppendText(element.Text + "\n");
                    richTextBoxCatalogTrack.AppendText(element.GetAttribute("href") + "\n");
                    richTextBoxCatalogTrack.AppendText("\n");
                }
            }

            if (catalogTrackDuration.Count > 0)
            {
                foreach (IWebElement element in catalogTrackDuration)
                {
                    richTextBoxTrackDuration.AppendText(element.Text + "\n");
                    richTextBoxTrackDuration.AppendText("\n");
                }
            }
            */

            

            catalogCategoryYS = browser.FindElements(By.CssSelector(".page-main__metatags-line a")).ToList();            

            foreach (IWebElement element in catalogCategoryYS)
            {
                comboBoxCategorySound.Items.Add(element.Text);
            }

            comboBoxCategorySound.Text = catalogCategoryYS[0].Text;
            comboBoxCategorySound.Enabled = true;
            buttonSearch.Enabled = false;
            buttonCreatePlaylist.Enabled = true;


        }

        /// <summary>
        /// Работа с сайтом МузоФон.
        /// </summary>
        private void SelectMuzoFon()
        {            

            browser.FindElement(LinkSportMusic).Click();
           
            catalogCategoryMF = browser.FindElements(LinkCatalogSportMusic).ToList();

            //comboBoxCategorySound.DataSource = catalogCategory; 

            foreach(IWebElement element in catalogCategoryMF)
            {
                comboBoxCategorySound.Items.Add(element.Text);
            }

            comboBoxCategorySound.Text = catalogCategoryMF[0].Text;
            comboBoxCategorySound.Enabled = true;
            buttonSearch.Enabled = false;
            buttonCreatePlaylist.Enabled = true;

        }

        /// <summary>
        /// Открытие браузера.
        /// </summary>
        /// <param name="url">Адрес открываемой страницы</param>
        public void OpenBrowser(string url)
        {
            if (browser == null)
            {
                browser = new OpenQA.Selenium.Chrome.ChromeDriver();
                browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            }

            browser.Manage().Window.Maximize();
            browser.Navigate().GoToUrl(url);
        }

        /// <summary>
        /// Действия по закрытию формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (browser != null)
            {
                browser.Quit();
            }
            if (pageHomeSaveFromNet != null)
            {
                pageHomeSaveFromNet.browser.Quit();
            }
            if (audioConverter != null)
            {
                audioConverter.Quit();
            }
        }

        private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void buttonDownload_Click(object sender, EventArgs e)
        {
            ///////// browser.FindElement(IconDownload).Click();

            Button button = (Button)sender;

            int num = Int32.Parse(button.Name);
            browser.Navigate().GoToUrl(catalogIconDownload[num].GetAttribute("href"));

        }


        private void buttonDownload_ClickYS(object sender, EventArgs e)
        {
           
            Button button = (Button)sender;

            int num = Int32.Parse(button.Name);
            //browser.Navigate().GoToUrl(catalogIconDownload[num].GetAttribute("href"));
            string loadUrl = catalogTrackNameYS[num].GetAttribute("href");

            
            ruSaveFromNet = new OpenQA.Selenium.Chrome.ChromeDriver();
            ruSaveFromNet.Navigate().GoToUrl("http://ru.savefrom.net");
            ruSaveFromNet.Manage().Window.Maximize();

            pageHomeSaveFromNet = PageHomeSaveFromNet.Create(ruSaveFromNet);
            pageHomeSaveFromNet.InputSearch.SendKeys(loadUrl + OpenQA.Selenium.Keys.Enter);           
            pageHomeSaveFromNet.LinkDownloadNoInst.Click();            
            pageHomeSaveFromNet.IconSelectFormat.Click();

            if(button.Text == "MP4")
            {
                pageHomeSaveFromNet.ListFileFormat[0].Click();
            }
            else if (button.Text == "3GP")
            {
                pageHomeSaveFromNet.ListFileFormat[3].Click();
            }
            else if (button.Text == "MP3")
            {
                
                pageHomeSaveFromNet.ButtonDowmload.Click();
            

                //другой файл
                audioConverter = new OpenQA.Selenium.Chrome.ChromeDriver();
                audioConverter.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
                audioConverter.Manage().Window.Maximize();

                audioConverter.Navigate().GoToUrl("https://online-audio-converter.com/ru/");

                audioConverter.FindElement(By.CssSelector(".uploader_state_default a")).Click();


                System.Threading.Thread.Sleep(5000);
                IntPtr hWnd = FindWindow(null, "Открыть");
                if (hWnd == IntPtr.Zero)
                {
                    MessageBox.Show("Not found main", "Error");
                    return;
                }

                System.Threading.Thread.Sleep(3000);
                IntPtr t1 = (IntPtr)System.Windows.Forms.Keys.Escape;
                IntPtr nul = IntPtr.Zero;
                PostMessage(hWnd, WM_KEYUP, t1, nul);
                PostMessage(hWnd, WM_KEYDOWN, t1, nul);

            }
            
        }        

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            browser.FindElement(IconPlay).Click();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabelName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel link = (LinkLabel)sender;
            
            //скачивание browser.Navigate().GoToUrl(catalogIconPlay[1].GetAttribute("data-url"));
            
            for (int i = 0; i < catalogTrackName.Count; i++)
            {
                if (catalogTrackName[i].Text == link.Text)
                {        
                    browser.FindElement(By.CssSelector($"li:nth-child({i + 1}) > div.actions > ul > li.play")).Click();                    
                    break;
                }
            }            

        }

        private void linkLabelName_LinkClickedYS(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel link = (LinkLabel)sender;

            //скачивание browser.Navigate().GoToUrl(catalogIconPlay[1].GetAttribute("data-url"));

            for (int i = 0; i < catalogTrackNameYS.Count; i++)
            {
                if (catalogTrackNameYS[i].Text == link.Text)
                {
                   browser.FindElement(By.CssSelector("")).Click();
                                                         
                    break;
                }
            }

        }

        /// <summary>
        /// К УДАЛЕНИЮ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreatePlaylist_Click(object sender, EventArgs e)
        {
            if (radioButtonYandexSound.Checked)
            {
                CreatePlaylistYandexSound();
                buttonCreatePlaylist.Enabled = false;
            }
            else
            {
                CreatePlaylistMuzoFon();
                 buttonCreatePlaylist.Enabled = false;
            }

        }

        /// <summary>
        /// Вывод треков по изменению критериев поиска.
        /// </summary>
        public void ShowTracks()
        {
            if (radioButtonYandexSound.Checked)
            {
                CreatePlaylistYandexSound();
                buttonCreatePlaylist.Enabled = false;
            }
            else
            {
                CreatePlaylistMuzoFon();
                buttonCreatePlaylist.Enabled = false;
            }
        }

        /// <summary>
        /// Проверка доступных форматов для скачивания с savefromnet.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFindFormat_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            int num = Int32.Parse(button.Name);            
            string loadUrl = catalogTrackNameYS[num].GetAttribute("href");

            ruSaveFromNet = new OpenQA.Selenium.Chrome.ChromeDriver();
            ruSaveFromNet.Navigate().GoToUrl("http://ru.savefrom.net");
            ruSaveFromNet.Manage().Window.Maximize();

            pageHomeSaveFromNet = PageHomeSaveFromNet.Create(ruSaveFromNet);
            pageHomeSaveFromNet.InputSearch.SendKeys(loadUrl + OpenQA.Selenium.Keys.Enter);
            pageHomeSaveFromNet.LinkDownloadNoInst.Click();
            pageHomeSaveFromNet.IconSelectFormat.Click();

            List<IWebElement> listFileFormat =  pageHomeSaveFromNet.ListFileFormat;

            
            //var comboBox = panelPlayList.Controls.Find("comboBoxFindFormat", false);

            
            foreach (IWebElement element in listFileFormat)
            {
                ComboBox cmb = panelPlayList.Controls["comboBoxFindFormat_" + Int32.Parse(button.Name)] as ComboBox;
                cmb.Enabled = true;                
                cmb.Items.Add(element.Text);
            }
            

            

        }

        private void CreatePlaylistYandexSound()
        {
            for (int i = 0; i < catalogCategoryYS.Count; i++)
            {
                if (catalogCategoryYS[i].Text == comboBoxCategorySound.Text)
                {
                    browser.Navigate().GoToUrl(catalogCategoryYS[i].GetAttribute("href"));
                    break;
                }
            }

            List<IWebElement>  catalogIconPlayYS = browser.FindElements(By.CssSelector(".d-track__cover img")).ToList();            
            List<IWebElement> catalogTrackArtistYS = browser.FindElements(By.CssSelector(".d-track__artists a")).ToList();
            catalogTrackNameYS = browser.FindElements(By.CssSelector(".d-track__name a")).ToList();
            //List<IWebElement> catalogTrackDurationYS = browser.FindElements().ToList();


            int distanceTop = 40;
            int distanceElement = 20;
            int leftLabelNum = 20;
            int leftButtonPlay = 40;
            int leftLabelArtist = 150;            
            int leftLabelTrack = 250;
            int leftButtonAddedForPlayList = 400;
            int leftButtonFindFormat = 520;
            int leftComboBoxFormats = 640;
            int leftButtonDownload = 760;




            for (int i = 0; i < catalogTrackNameYS.Count; i++)
            {                

                Label labelNum = new Label();
                labelNum.Width = leftLabelNum;
                labelNum.Left = 10;
                labelNum.Top = 10 + i * distanceTop;
                labelNum.Text = (i + 1).ToString() + ".";
                panelPlayList.Controls.Add(labelNum);

                Button buttonPlay = new Button();
                buttonPlay.Name = i.ToString();
                buttonPlay.Width = 80;
                buttonPlay.Left = leftButtonPlay;
                buttonPlay.Top = 10 + i * distanceTop;
                buttonPlay.Text = "Слушать";
                //buttonPlay.Click += ;
                panelPlayList.Controls.Add(buttonPlay);

                Label labelArtist = new Label();
                labelArtist.Left = leftLabelArtist;
                labelArtist.Top = 10 + i * distanceTop;
                labelArtist.Text = catalogTrackArtistYS[i].Text;
                panelPlayList.Controls.Add(labelArtist);
                
                Label labelTrack = new Label();
                labelTrack.Left = leftLabelTrack;
                labelTrack.Top = 10 + i * distanceTop;
                labelTrack.Text = catalogTrackNameYS[i].Text;               
                panelPlayList.Controls.Add(labelTrack);

                

                /*
                Button buttonDownloadMP4 = new Button();
                buttonDownloadMP4.Name = i.ToString();
                buttonDownloadMP4.Width = 40;
                buttonDownloadMP4.Left = 300;
                buttonDownloadMP4.Top = 10 + i * distanceTop;
                buttonDownloadMP4.Text = "MP4";
                buttonDownloadMP4.Click += buttonDownload_ClickYS;
                panelPlayList.Controls.Add(buttonDownloadMP4);

                Button buttonDownload3GP = new Button();
                buttonDownload3GP.Name = i.ToString();
                buttonDownload3GP.Width = 40;
                buttonDownload3GP.Left = 350;
                buttonDownload3GP.Top = 10 + i * distanceTop;
                buttonDownload3GP.Text = "3GP";
                buttonDownload3GP.Click += buttonDownload_ClickYS;
                panelPlayList.Controls.Add(buttonDownload3GP);

                Button buttonDownloadMP3 = new Button();
                buttonDownloadMP3.Name = i.ToString();
                buttonDownloadMP3.Width = 40;
                buttonDownloadMP3.Left = 400;
                buttonDownloadMP3.Top = 10 + i * distanceTop;
                buttonDownloadMP3.Text = "MP3";
                buttonDownloadMP3.Click += buttonDownload_ClickYS;
                panelPlayList.Controls.Add(buttonDownloadMP3);
                */


                Button buttonAddedForPlayList = new Button();
                buttonAddedForPlayList.Width = 100;
                buttonAddedForPlayList.Left = leftButtonAddedForPlayList;
                buttonAddedForPlayList.Top = 10 + i * distanceTop;
                buttonAddedForPlayList.Text = "в Плейлист";
                panelPlayList.Controls.Add(buttonAddedForPlayList);
                buttonAddedForPlayList.Enabled = false;

                Button buttonFindFormat = new Button();
                buttonFindFormat.Name = i.ToString();
                buttonFindFormat.Width = 100;
                buttonFindFormat.Left = leftButtonFindFormat;
                buttonFindFormat.Top = 10 + i * distanceTop;
                buttonFindFormat.Text = "Запросить";
                panelPlayList.Controls.Add(buttonFindFormat);
                buttonFindFormat.Click += buttonFindFormat_Click;
                buttonFindFormat.Enabled = true;

                ComboBox comboBox = new ComboBox();
                comboBox.Name = "comboBoxFindFormat_" + i.ToString();
                comboBox.Width = 100;
                comboBox.Left = leftComboBoxFormats;
                comboBox.Top = 10 + i * distanceTop;
                panelPlayList.Controls.Add(comboBox);
                comboBox.Enabled = false;

                Button buttonDownload = new Button();
                buttonDownload.Name = i.ToString();
                buttonDownload.Width = 100;
                buttonDownload.Left = leftButtonDownload;
                buttonDownload.Top = 10 + i * distanceTop;
                buttonDownload.Text = "Скачать";
                panelPlayList.Controls.Add(buttonDownload);
                buttonDownload.Click += buttonDownload_Click;
                buttonDownload.Enabled = false;

            }            

        }

        private void CreatePlaylistMuzoFon()
        {
            for (int i = 0; i < catalogCategoryMF.Count; i++)
            {
                if (catalogCategoryMF[i].Text == comboBoxCategorySound.Text)
                {
                    browser.Navigate().GoToUrl(catalogCategoryMF[i].GetAttribute("href"));
                    break;
                }
            }


            catalogIconPlay = browser.FindElements(IconPlay).ToList();
            catalogIconDownload = browser.FindElements(IconDownload).ToList();
            List<IWebElement> catalogTrackArtist = browser.FindElements(TxtArtist).ToList();
            catalogTrackName = browser.FindElements(TxtName).ToList();
            List<IWebElement> catalogTrackDuration = browser.FindElements(TxtDuration).ToList();


            int distanceTop = 40;

            for (int i = 0; i < catalogTrackArtist.Count; i++)
            {

                Label labelNum = new Label();
                labelNum.Width = 20;
                labelNum.Left = 10;
                labelNum.Top = 10 + i * distanceTop;
                labelNum.Text = (i + 1).ToString() + ".";
                panelPlayList.Controls.Add(labelNum);

                Label labelArtist = new Label();
                labelArtist.Left = 30;
                labelArtist.Top = 10 + i * distanceTop;
                labelArtist.Text = catalogTrackArtist[i].Text;
                panelPlayList.Controls.Add(labelArtist);

                LinkLabel labelName = new LinkLabel();
                labelName.Left = 200;
                labelName.Top = 10 + i * distanceTop;
                labelName.Text = catalogTrackName[i].Text;
                labelName.LinkClicked += linkLabelName_LinkClicked;
                panelPlayList.Controls.Add(labelName);

                Button buttonDownload = new Button();
                buttonDownload.Name = i.ToString();
                buttonDownload.Left = 400;
                buttonDownload.Top = 10 + i * distanceTop;
                buttonDownload.Text = "Скачать";
                buttonDownload.Click += buttonDownload_Click;
                panelPlayList.Controls.Add(buttonDownload);

                Button buttonAddedForPlayList = new Button();
                buttonAddedForPlayList.Width = 200;
                buttonAddedForPlayList.Left = 500;
                buttonAddedForPlayList.Top = 10 + i * distanceTop;
                buttonAddedForPlayList.Text = "Добавить в Плейлист";
                panelPlayList.Controls.Add(buttonAddedForPlayList);
                buttonAddedForPlayList.Enabled = false;


            }
        }

        private void radioButtonMuzoFon_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;

            ElementInit();

            if (radioButton.Checked)
            {
                url = urlMuzofon;
            }
            else
            {
                url = urlYandexSound;
            }

            SearchTrack();
        }

        private void radioButtonYandexSound_CheckedChanged(object sender, EventArgs e)
        {
            ElementInit();

            RadioButton radioButton = (RadioButton)sender;

            if (radioButton.Checked)
            {
                url = urlYandexSound;
            }
            else
            {
                url = urlMuzofon;
            }

            SearchTrack();
        }

        private void ElementInit()
        {
            panelPlayList.Controls.Clear();
            comboBoxCategorySound.Items.Clear();
            comboBoxCategorySound.Text = "";
            comboBoxCategorySound.Enabled = false;
            buttonCreatePlaylist.Enabled = false;
            buttonSearch.Enabled = true;
        }

        private void comboBoxCategorySound_SelectedIndexChanged(object sender, EventArgs e)
        {
            ////!!!! перейти на url по comboBox.Text;
            panelPlayList.Controls.Clear();
            //buttonCreatePlaylist.Enabled = true;
            SearchTrack();
        }
    }
}
