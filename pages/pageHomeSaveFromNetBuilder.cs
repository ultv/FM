using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FM.pages
{
    public class PageHomeSaveFromNetBuilder
    {
        private PageHomeSaveFromNet pageHome;

        public PageHomeSaveFromNetBuilder(PageHomeSaveFromNet page)
        {
            this.pageHome = page;
        }
        
        public static implicit operator PageHomeSaveFromNet(PageHomeSaveFromNetBuilder builder)
        {
            return builder.pageHome;
        }

        public PageHomeSaveFromNetBuilder InitButtonsFormat(string url)
        {

            
                return this;
        }
    }
}
