using Foxtrot.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Foxtrot.Tests.DriverFactory
{
    public class ApplicationManaget
    {
        public IWebDriver driver;
        public CartHelper cartHelper;
        public ComparingHelper comparingHelper;
        public DiscountHelper discountHelper;
        public FilterHelper filterHelper;
        public ProductCatalogHelper productCatalogHelper;
        public ProductListHelper productListHelper;
        public SearchHelper searchHelper;
        public SortingHelper sortingHelper;

        public void InitDriver(BrowserTypes browser)
        {
            if (browser.Equals(BrowserTypes.Chrome))
            {
                driver = new ChromeDriver();
            }
            else if (browser.Equals(BrowserTypes.Firefox))
            {
                driver = new FirefoxDriver();
            }
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.foxtrot.com.ua/");
        }

        public void InitHelpers()
        {
            cartHelper = new CartHelper(driver);
            comparingHelper = new ComparingHelper(driver);
            discountHelper = new DiscountHelper(driver);
            filterHelper = new FilterHelper(driver);
            productCatalogHelper = new ProductCatalogHelper(driver);
            productListHelper = new ProductListHelper(driver);
            searchHelper = new SearchHelper(driver);
            sortingHelper = new SortingHelper(driver);
        }

        public void QuitDriver()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }
    }
}