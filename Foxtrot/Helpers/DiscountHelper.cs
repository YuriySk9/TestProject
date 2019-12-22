using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Foxtrot.Helpers
{
    public class DiscountHelper : BaseHelper
    {
        public DiscountHelper(IWebDriver driver) : base(driver)
        {
        }

        protected IWebElement DiscountLink => driver.FindElement(By.XPath("//li[@class='navigation__item'][2]"));
        protected By CategoriesList => By.XPath("//div[@class='bl1 bl-wrppr-fct']");

        protected IWebElement Category(string name)
        {
            return driver.FindElement(By.XPath($"//div[@class='my-wrapper']//div[@class='bl1-two']/a[contains(text(),'{name}')]"));
        }

        public DiscountHelper GoToPage()
        {
            DiscountLink.Click();
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(CategoriesList));
            return this;
        }

        public DiscountHelper GoToCategory(string name)
        {
            var productListHelper = new ProductListHelper(driver);
            Category(name).Click();
            WaitForPageLoad();
            return this;
        }
    }
}
