using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;
using System.Collections.Generic;
using System.Linq;

namespace Foxtrot.Helpers
{
    public class ComparingHelper : BaseHelper
    {
        public ComparingHelper(IWebDriver driver) : base(driver)
        {
        }

        protected IWebElement ComparingGoodsCount => driver.FindElement(By.XPath("//span[@class='right__count compare__count']"));
        protected IWebElement ComparingBlock => driver.FindElement(By.XPath("//img[@class='right__img compare__icon']"));
        protected By CleanButton => By.XPath("//div[@class='compare-category clean']");
        protected IWebElement ComparingLink => wait.Until(ExpectedConditions.ElementToBeClickable(driver.FindElement(By.XPath("//div[@class='compare-category'][1]"))));
        protected IList<IWebElement> ProductName => driver.FindElements(By.XPath("//div[@class='comparisons__item product-item']//a[@class='comparisons__item_titel-text']"));

        public bool WhetherAnyGoodsInComparing()
        {
            if (ComparingGoodsCount.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private ComparingHelper MoveToCompareBlock()
        {
            var actions = new Actions(driver);
            actions.MoveToElement(ComparingBlock).Perform();
            return this;
        }

        public ComparingHelper GoToPage()
        {
            MoveToCompareBlock();
            ComparingLink.Click();
            WaitForPageLoad();
            return this;
        }

        public ComparingHelper ClearComparing()
        {
            var actions = new Actions(driver);
            MoveToCompareBlock();
            actions.MoveToElement(driver.FindElement(CleanButton)).Click().Perform();
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(CleanButton));
            driver.Navigate().Refresh();
            return this;
        }

        public List<string> AddProductListToComparison(List<string> productList)
        {
            var addedProductList = new List<string>();
            var searchHelper = new SearchHelper(driver);
            foreach (string productName in productList)
            {
                var productListHelper = searchHelper.Search(productName);
                var productItemHelper = productListHelper.FirstElement();
                string elementName = productItemHelper.ClickCompareButton();
                addedProductList.Add(elementName);
            }
            return addedProductList;
        }

        public List<string> GetProductNameList()
        {
            List<string> productNameList = ProductName.Select(d => d.Text).ToList();
            return productNameList;
        }
    }
}
