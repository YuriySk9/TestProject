using Foxtrot.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Linq;

namespace Foxtrot.Helpers
{
    public class ProductCatalogHelper : BaseHelper
    {
        public ProductCatalogHelper(IWebDriver driver) : base(driver)
        {
        }

        protected string ParentProductCatalog { get; private set; }
        protected By ProductCatalogDropDown => By.XPath("//span[@class='catalog__name']");

        protected By FirstCategoryLevel(string parent, string submenuCategory)
        {
            return By.XPath($"{parent}//a[text()='{submenuCategory}']/following::img[@class='link-arrow'][1]");
        }

        protected By SecondCategoryLevel(string category)
        {
            return By.XPath($"//div[@class='category-menu-wrapper visible']//ul[@class='category-item__list']//a[text()='{category}']");
        }

        public ProductCatalogHelper GoToCategory(GoodsCatalogModel goodsCatalogModel)
        {
            var actions = new Actions(driver);
            string parentProductCatalogFromMainPage = "//ul[@class='catalog-submenu']";
            WaitForPageLoad();
            if (driver.FindElements(By.XPath(parentProductCatalogFromMainPage)).Any())
            {
                ParentProductCatalog = parentProductCatalogFromMainPage;
            }
            else
            {
                ParentProductCatalog = "//ul[@class='catalog-submenu categories']";
                actions.MoveToElement(driver.FindElement(ProductCatalogDropDown)).Perform();
            }
            actions.MoveToElement(driver.FindElement(FirstCategoryLevel(ParentProductCatalog, goodsCatalogModel.firstLevel))).Perform();
            actions.MoveToElement(driver.FindElement(SecondCategoryLevel(goodsCatalogModel.secondLevel))).Click().Perform();
            WaitForPageLoad();
            return this;
        }
    }
}
