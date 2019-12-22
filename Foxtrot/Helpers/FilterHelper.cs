using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Foxtrot.Helpers
{
    public class FilterHelper : BaseHelper
    {
        public FilterHelper(IWebDriver driver) : base(driver)
        {
        }

        protected IWebElement MinPriceField => driver.FindElement(By.XPath("//input[@class='amount-1']"));
        protected IWebElement MaxPriceField => driver.FindElement(By.XPath("//input[@class='amount-2']"));
        protected By OkButton => By.XPath("//button[@class='submit']");
        protected By ShowButton => By.XPath("//p[@class='filter-apply__text']");

        protected IWebElement TrademarkCheckbox(string trademark)
        {
            return driver.FindElement(By.XPath($"//span[contains(@class,'brand') and text()='{trademark.ToUpper()}']"));
        }

        public FilterHelper SelectTrademark(string brand)
        {
            if (!TrademarkCheckbox(brand).GetAttribute("class").Contains("checked"))
            {
                TrademarkCheckbox(brand).Click();
            }
            return this;
        }

        public FilterHelper SetMinPrice(string price)
        {
            Type(MinPriceField, price);
            return this;
        }

        public FilterHelper SetMaxPrice(string price)
        {
            Type(MaxPriceField, price);
            return this;
        }

        public ProductListHelper ClickOkButton()
        {
            IWebElement ok = driver.FindElement(OkButton);
            ok.Click();
            wait.Until(ExpectedConditions.StalenessOf(ok));
            return new ProductListHelper(driver);
        }

        public ProductListHelper ClickShowButton()
        {
            IWebElement show = driver.FindElement(ShowButton);
            show.Click();
            wait.Until(ExpectedConditions.StalenessOf(show));
            return new ProductListHelper(driver);
        }
    }
}
