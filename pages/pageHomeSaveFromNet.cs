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
    /// Домашняя страница сайта "ru.savefrom.net"
    /// </summary>
    public class PageHomeSaveFromNet
    {
        public readonly IWebDriver browser;

        public static PageHomeSaveFromNetBuilder Create(IWebDriver browser)
        {
            return new PageHomeSaveFromNetBuilder(new PageHomeSaveFromNet(browser));
        }

        public PageHomeSaveFromNet(IWebDriver browser)
        {
            this.browser = browser;
            PageFactory.InitElements(browser, this);
        }

        /// <summary>
        /// Поле ввода ссылки для поиска.
        /// </summary>
        [FindsBy(How = How.Id, Using = "sf_url")]
        public IWebElement InputSearch { get; set; }

        /// <summary>
        /// Ссылка "Скачать без установки".
        /// </summary>
        [FindsBy(How = How.LinkText, Using = "Скачать без установки")]
        public IWebElement LinkDownloadNoInst { get; set; }

        /// <summary>
        /// Кнопка "Скачать".
        /// </summary>
        [FindsBy(How = How.ClassName, Using =("def-btn-box"))]
        public IWebElement ButtonDowmload { get; set; }

        /// <summary>
        /// Иконка для выбора формата скачиваемого файла.
        /// </summary>
        [FindsBy(How = How.ClassName, Using =("def-btn-name"))]
        public IWebElement IconSelectFormat
        {
            get
            {
                WebDriverWait ruSaveFromNetWait = new WebDriverWait(browser, TimeSpan.FromSeconds(15));
                IWebElement iconSelectFormat = ruSaveFromNetWait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("def-btn-name")));

                return iconSelectFormat;
            }
        }

        //[FindsBy(How = How.ClassName, Using = ("def-btn-name"))]
        //public By IconSelectFormatBy { get { return By.ClassName("def-btn-name"); } }

        /// <summary>
        /// Список доступных форматов для скачивания.
        /// </summary>
        public List<IWebElement> ListFileFormat
        {
            get
            {
                WebDriverWait ruSaveFromNetWait = new WebDriverWait(browser, TimeSpan.FromSeconds(15));
                IWebElement listFileFormat = ruSaveFromNetWait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".link-group a")));

                return browser.FindElements(By.CssSelector(".link-group a")).ToList();                
            }            
        }


    }
}
