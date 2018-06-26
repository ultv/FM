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
        By LinkSportMusic = By.LinkText("Спортивная музыка");
        By LinkMeditationMusic = By.LinkText("Музыка Для Медитации");        
        By IconDownload = By.CssSelector("div.actions > ul > li.download > a");
        By TxtArtist = By.CssSelector("div.desc > h3 > span.artist");
        By IconPlay = By.CssSelector("div.actions > ul > li.play");

        

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
            ((IJavaScriptExecutor)browser).ExecuteScript("arguments[0].scrollIntoView();", browser.FindElement(LinkSportMusic));

            browser.FindElement(LinkMeditationMusic).Click();

            richTextBoxCatalogTrack.AppendText(browser.FindElement(IconDownload).GetAttribute("href"));
            linkLabel1.Text = browser.FindElement(TxtArtist).Text;
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
            browser.FindElement(IconDownload).Click();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            browser.FindElement(IconPlay).Click();
        }
    }
}
