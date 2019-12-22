using Foxtrot.TestData;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Foxtrot.Tests.Filers
{
    [TestFixture]
    public class FilterTests : BaseTest
    {
        [Test]
        public void FilterTrademarkAndPrice()
        {
            string trademark = FiltersData.filtersModel.trademark;
            string minPrice = FiltersData.filtersModel.minPrice;
            string maxPrice = FiltersData.filtersModel.maxPrice;

            app.productCatalogHelper.GoToCategory(GoodsCatalogData.laptops);
            app.productListHelper.IsDisplayed()
                                 .filterHelper.SetMinPrice(minPrice)
                                              .SetMaxPrice(maxPrice)
                                              .SelectTrademark(trademark)
                                              .ClickShowButton();
            app.productListHelper.IsDisplayed();
            List<string> foundProductNameList = app.productListHelper.GetProductNameList().ConvertAll(d => d.ToLower());
            List<int> foundProductPriceList = app.productListHelper.GetPriceList();

            Console.WriteLine($"expected trademark: {trademark}");
            for (int i = 0; i < foundProductNameList.Count; i++)
            {
                Console.WriteLine($"actual result: {foundProductNameList[i]}");
            }
            Console.WriteLine($"\nexpected min price: {minPrice}\nexpected max price: {maxPrice}");
            for (int i = 0; i < foundProductPriceList.Count; i++)
            {
                Console.WriteLine($"actual result: {foundProductPriceList[i]}");
            }
            Assert.Multiple(() =>
            {
                Assert.True(foundProductNameList.All(x => x.Contains(trademark)));
                Assert.True(foundProductPriceList.All(x => (x >= int.Parse(minPrice) && x <= int.Parse(maxPrice))));
            });
        }
    }
}
