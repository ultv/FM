using System;


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

namespace FM
{
    public partial class Form1 : Form
    {
        static IWebDriver browser;

        /// <summary>
        /// ЯндексМузыка.
        /// </summary>
        //readonly string url = "https://music.yandex.ru/genres";                
        By LinkRun = By.LinkText("Бег");
        By LinkAllTrack = By.LinkText("Все треки");        
        By LinkTrackName = By.CssSelector(".d-track__name a");
        By TxtTrackDuration = By.CssSelector(".d-track__info span");

        /// <summary>
        /// Музофон.
        /// </summary>
        readonly string url = "https://muzofond.org/";
        List<IWebElement> catalogCategory;
        List<IWebElement> catalogTrackName;
        List<IWebElement> catalogIconPlay;
        List<IWebElement> catalogIconDownload;
        By LinkSportMusic = By.LinkText("Спортивная музыка");
        //By LinkSportMusic = By.CssSelector(".module-collections a");
        By LinkCatalogSportMusic = By.CssSelector(".module-layout a");


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
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            OpenBrowser(url);

            //SelectYandexSound();
            SelectMuzoFon();
            
            
            //this.Activate();
            //browser.Manage().Window.Minimize();
        }

        /// <summary>
        /// Работа с сайтом ЯндексМузыка.
        /// </summary>
        private void SelectYandexSound()
        {
            ((IJavaScriptExecutor)browser).ExecuteScript("arguments[0].scrollIntoView();", browser.FindElement(LinkRun));
            browser.FindElement(LinkRun).Click();

            ((IJavaScriptExecutor)browser).ExecuteScript("arguments[0].scrollIntoView();", browser.FindElement(LinkAllTrack));
            browser.FindElement(LinkAllTrack).Click();

            //WebDriverWait browserWait = new WebDriverWait(browser, TimeSpan.FromSeconds(15));
            //IWebElement LinkTrackNameWait = browserWait.Until(ExpectedConditions.ElementIsVisible(LinkTrackName));

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
        }

        /// <summary>
        /// Работа с сайтом МузоФон.
        /// </summary>
        private void SelectMuzoFon()
        {
            /*
            ((IJavaScriptExecutor)browser).ExecuteScript("arguments[0].scrollIntoView();", browser.FindElement(LinkSportMusic));

            browser.FindElement(LinkMeditationMusic).Click();

            richTextBoxCatalogTrack.AppendText(browser.FindElement(IconDownload).GetAttribute("href"));
            linkLabel1.Text = browser.FindElement(TxtArtist).Text;
            */


            /*
            List<IWebElement> catalogTrack = browser.FindElements(LinkSportMusic).ToList();

            if (catalogTrack.Count > 0)
            {
                foreach (IWebElement element in catalogTrack)
                {
                    richTextBoxCatalogTrack.AppendText(element.Text + "\n");             
                    richTextBoxCatalogTrack.AppendText("\n");
                }
            }
            */

            browser.FindElement(LinkSportMusic).Click();
           
            catalogCategory = browser.FindElements(LinkCatalogSportMusic).ToList();

            //comboBoxCategorySound.DataSource = catalogCategory; 

            foreach(IWebElement element in catalogCategory)
            {
                comboBoxCategorySound.Items.Add(element.Text);
            }

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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (browser != null)
            {
                browser.Quit();
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

        private void buttonCreatePlaylist_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < catalogCategory.Count; i++)
            {
                if (catalogCategory[i].Text == comboBoxCategorySound.Text)
                {
                    browser.Navigate().GoToUrl(catalogCategory[i].GetAttribute("href"));                    
                    break;
                }
            }


            catalogIconPlay = browser.FindElements(IconPlay).ToList();
            catalogIconDownload = browser.FindElements(IconDownload).ToList();
            List<IWebElement> catalogTrackArtist = browser.FindElements(TxtArtist).ToList();
            catalogTrackName = browser.FindElements(TxtName).ToList();
            List<IWebElement> catalogTrackDuration = browser.FindElements(TxtDuration).ToList();


            int distanceTop = 40;

            for(int i = 0; i < catalogTrackArtist.Count; i++)
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


            }           

        }

        



    }
}
