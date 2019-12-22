using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;
using System.Collections.Generic;
using System.Linq;

namespace Foxtrot.Helpers
{
    public class ProductListHelper : BaseHelper
    {
        public FilterHelper filterHelper;

        public ProductListHelper(IWebDriver driver) : base(driver)
        {
            filterHelper = new FilterHelper(driver);
        }

        protected By DisplayNone => By.XPath("//div[@class='product-listing-loader' and @style='display: none;']");
        protected By ProductPrice => By.XPath("//div[@class='price__relevant']//span[@class='numb']");
        protected By ProductNames => By.XPath("//p[@class='info']");
        protected IWebElement FirstItem => driver.FindElement(By.XPath("//div[@class='listing-item product-item simple'][1]"));
        protected IList<IWebElement> AllItems => driver.FindElements(By.XPath("//div[@class='listing-item product-item simple']"));

        protected By ItemNumber(int item)
        {
            return By.XPath($"//div[@class='listing-item product-item simple'][{item}]//img[@src='/content/img/general/icons/starfill.svg']");
        }

        public ProductItemHelper FirstElement()
        {
            return new ProductItemHelper(driver, FirstItem);
        }

        public List<int> GetRatingList()
        {
            List<int> listRating = new List<int>();
            for (int i = 1; i <= AllItems.Count; i++)
            {
                new Actions(driver).MoveToElement(driver.FindElement(ItemNumber(i))).Perform();
                int rating = driver.FindElements(ItemNumber(i)).Count;
                listRating.Add(rating);
            }
            return listRating;
        }

        public ProductListHelper IsDisplayed()
        {
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(ProductNames));
            wait.Until(ExpectedConditions.ElementExists(DisplayNone));
            return this;
        }

        public int GetProductsCount()
        {
            int productsCount = driver.FindElements(ProductNames).Count();
            return productsCount;
        }

        public int GetPricesCount()
        {
            int discountPricesCount = driver.FindElements(ProductPrice).Count();
            return discountPricesCount;
        }

        public List<string> GetProductNameList()
        {
            List<string> productNameList = driver.FindElements(ProductNames).Select(d => d.Text).ToList();
            return productNameList;
        }

        public List<int> GetPriceList()
        {
            List<string> productPriceList = driver.FindElements(ProductPrice).Select(d => d.Text).ToList();
            List<string> actualPriceListWithuotSpaces = productPriceList.Select(d => d.Replace(" ", "")).ToList();
            List<int> listPrice = actualPriceListWithuotSpaces.Select(d => int.Parse(d)).ToList();
            return listPrice;
        }
    }
}
