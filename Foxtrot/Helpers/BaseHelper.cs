using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Foxtrot.Helpers
{
    public class BaseHelper
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;
        private int TimeForWait = 10;

        public BaseHelper(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(TimeForWait));
        }

        public void WaitForPageLoad()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until((wdriver) => (wdriver as IJavaScriptExecutor).ExecuteScript("return document.readyState")
                                                                    .Equals("complete"));
            wait.Until(wdriver => Int32.Parse((wdriver as IJavaScriptExecutor)
                .ExecuteScript("if (window.jQuery) {return jQuery.active;  } else { return -1;}")
                .ToString()) <= 0);
        }

        protected void Type(IWebElement locator, string name)
        {
            locator.Click();
            locator.Clear();
            locator.SendKeys(name);
        }
    }
}