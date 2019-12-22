using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System.Linq;

namespace Foxtrot.Helpers
{
    public class SortingHelper : BaseHelper
    {
        public SortingHelper(IWebDriver driver) : base(driver)
        {
        }

        protected IWebElement SortingDropDown => driver.FindElement(By.XPath("//img[@class='sort-elected__icon']"));
        protected By SortingDropDownIsOpen => By.XPath("//ul[@class='sort-dropdown visible']");
        protected By ExponeaAlert => By.XPath("//span[@class='exponea-close-cross']");
        protected string SelectedSorting => driver.FindElement(By.XPath("//p[@class='sort-elected__text']")).Text;
        protected IWebElement SortDropDownItem(string sortingBy)
        {
            return driver.FindElement(By.XPath($"//span[@class='dropdown-text' and text()='{sortingBy}']"));
        }

        public void SortBy(string sortingBy)
        {
            if (SelectedSorting != sortingBy)
            {
                if (driver.FindElements(ExponeaAlert).Any())
                {
                    driver.FindElement(ExponeaAlert).Click();
                }
                SortingDropDown.Click();
                wait.Until(ExpectedConditions.ElementIsVisible(SortingDropDownIsOpen));
                SortDropDownItem(sortingBy).Click();
                wait.Until(ExpectedConditions.ElementToBeClickable(SortingDropDown));
                WaitForPageLoad();
            }
        }
    }
}
