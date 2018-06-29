using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;

namespace FM.pages
{
    /// <summary>
    /// сайт MuzoFon - главная страница.
    /// </summary>
    public class PageHomeMuzoFon
    {
        public PageHomeMuzoFon(IWebDriver browser)
        {
            browser.Navigate().GoToUrl("https://muzofond.org/");
            PageFactory.InitElements(browser, this);
        }

        /// <summary>
        /// Поле для поиска
        /// </summary>
        [FindsBy(How = How.CssSelector, Using = ".inInputSearch input")]
        public IWebElement InputSearch { get; set; }

        /// <summary>
        /// Кнопка поиска.
        /// </summary>
        [FindsBy(How = How.CssSelector, Using = ".module-search button")]
        public IWebElement ButtonSearch { get; set; }



    }
}
