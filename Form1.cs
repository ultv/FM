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

namespace FM
{
    public partial class Form1 : Form
    {
        static IWebDriver browser;
        readonly string url = "https://music.yandex.ru/genres";
        //By LinkGenres = By.LinkText("Жанры");

        By LinkRun = By.LinkText("Бег");
        By LinkAllTrack = By.LinkText("Все треки");

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            OpenBrowser(url);            

            ((IJavaScriptExecutor)browser).ExecuteScript("arguments[0].scrollIntoView();", browser.FindElement(LinkRun));
            browser.FindElement(LinkRun).Click();

            ((IJavaScriptExecutor)browser).ExecuteScript("arguments[0].scrollIntoView();", browser.FindElement(LinkAllTrack));
            browser.FindElement(LinkAllTrack).Click();

            List<IWebElement> catalog = browser.FindElements(By.CssSelector(".d-track__name a")).ToList();

            foreach(IWebElement element in catalog)
            {
                richTextBox1.AppendText(element.Text + "\n");
                richTextBox1.AppendText(element.GetAttribute("href") + "\n");
                richTextBox1.AppendText("\n");
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
    }
}
