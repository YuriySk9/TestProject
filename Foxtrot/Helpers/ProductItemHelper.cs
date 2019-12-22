using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Foxtrot.Helpers
{
    public class ProductItemHelper : BaseHelper
    {
        public ProductItemHelper(IWebDriver driver, IWebElement parentItem) : base(driver)
        {
            ParentItem = parentItem;
        }

        protected IWebElement ParentItem { get; private set; }
        protected By NameOfElement => By.XPath("//p[@class='info']");
        protected By BuyButton => By.XPath("//a[@class='buy-button add-to-cart']");
        protected By CompareButton => By.XPath("//div[@class='compare-icon add-to-compare-list']");
        protected By CompareButtonActive => By.XPath("//div[@class='compare-icon add-to-compare-list active']");
        protected By Rating => By.XPath("//img[@src='/content/img/general/icons/starfill.svg']");

        public string ClickBuyButton()
        {
            string productName = ParentItem.FindElement(NameOfElement).Text;
            ParentItem.FindElement(BuyButton).Click();
            WaitForPageLoad();
            return productName;
        }

        public string ClickCompareButton()
        {
            ParentItem.FindElement(CompareButton).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(ParentItem.FindElement(CompareButtonActive)));
            string elementName = ParentItem.FindElement(NameOfElement).Text;
            return elementName;
        }

        public int GetRating()
        {
            var e = ParentItem.FindElements(Rating);
            int  i = e.Count;
            return i;
        }
    }
}