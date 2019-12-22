using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System.Collections.Generic;
using System.Linq;

namespace Foxtrot.Helpers
{
    public class CartHelper : BaseHelper
    {
        public CartHelper(IWebDriver driver) : base(driver)
        {
        }

        protected IWebElement CloseCartButton => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='popup-wrapper basket show']//img[@class='basket-close']")));
        protected IWebElement GoodsInCartCount => driver.FindElement(By.XPath("//span[@class='right__count basket__count']"));
        protected IList<IWebElement> ProductName => wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//p[@class='product-name']")));
        protected IWebElement DeleteProductButton => driver.FindElement(By.XPath("//img[@class='basket-item-close-img']"));
        protected IWebElement CartLink => driver.FindElement(By.XPath("//img[@class='right__img basket__icon']"));
        protected IList<IWebElement> CartIsEmptyLabel => driver.FindElements(By.XPath("//div[@class='empty_basket']"));

        public bool WhetherAnyGoodsInCart()
        {
            string countGoods = GoodsInCartCount.Text;
            if (countGoods == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public List<string> GetProductNameList()
        {
            List<string> productNameList = ProductName.Select(d => d.Text).ToList();
            return productNameList;
        }

        public void CloseCatrButtonClick()
        {
            WaitForPageLoad();
            CloseCartButton.Click();
        }

        public CartHelper DeleteAllGoods()
        {
            while (!CartIsEmptyLabel.Any())
            {
                DeleteProductButton.Click();
                WaitForPageLoad();
            }
            return this;
        }

        public CartHelper GoToPage()
        {
            CartLink.Click();
            WaitForPageLoad();
            return this;
        }

        public List<string> AddProductListToCart(List<string> productList)
        {
            var addedProductList = new List<string>();
            var cartHelper = new CartHelper(driver);
            var searchHelper = new SearchHelper(driver);
            foreach (string productName in productList)
            {
                var productListHelper = searchHelper.Search(productName);
                var productItemHelper = productListHelper.IsDisplayed()
                                                         .FirstElement();
                string elementName = productItemHelper.ClickBuyButton();
                addedProductList.Add(elementName);
                cartHelper.CloseCatrButtonClick();
            }
            return addedProductList;
        }
    }
}
