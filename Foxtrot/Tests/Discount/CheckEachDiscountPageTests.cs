using NUnit.Framework;
using System.Collections.Generic;

namespace Foxtrot.Tests.Discount
{
    [TestFixture]
    public class CheckEachDiscountPageTests : BaseTest
    {
        static List<string> categoriesList = new List<string>()
        {
            "Смартфоны и аксессуары",
            "Телевизоры",
            "Компьютерная техника",
            "Мелкая техника",
            "Крупная техника",
            "Товары для дома"
        };

        [Test, TestCaseSource("categoriesList")]
        public void CheckPageToDiscountTest(string categoryName)
        {
            app.discountHelper.GoToPage();
            app.discountHelper.GoToCategory(categoryName);
            int productsCount = app.productListHelper.GetProductsCount();
            int discountPricesConut = app.productListHelper.GetPricesCount();

            Assert.AreEqual(productsCount, discountPricesConut);
        }
    }
}