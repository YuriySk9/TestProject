using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Foxtrot.Helpers
{
    public class SearchHelper : BaseHelper
    {
        public SearchHelper(IWebDriver driver) : base(driver)
        {
        }

        protected IWebElement SearchField => driver.FindElement(By.Name("query"));
        protected By SearchButton => By.XPath("//div[@class='search__btn']");

        public ProductListHelper Search(string name)
        {
            Type(SearchField, name);
            IWebElement searchButtonWebElement = driver.FindElement(SearchButton);
            searchButtonWebElement.Click();
            wait.Until(ExpectedConditions.StalenessOf(searchButtonWebElement));
            WaitForPageLoad();
            return new ProductListHelper(driver);
        }
    }
}
