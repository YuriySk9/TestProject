using Foxtrot.TestData;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Foxtrot.Tests.Search
{
    [TestFixture]
    public class SearchProductTests : BaseTest
    {
        [Test, TestCaseSource(typeof(SearchData), nameof(SearchData.LaptopData))]
        public void SerchProductTests(SearchFieldModel searchFieldModel)
        {
            string product = searchFieldModel.product;

            app.searchHelper.Search(product);
            List<string> foundProductNameList = app.productListHelper.GetProductNameList().ConvertAll(d => d.ToLower());

            Console.WriteLine($"expected result: {product}");
            for (int i = 0; i < foundProductNameList.Count; i++)
            {
                Console.WriteLine($"actual result: {foundProductNameList[i]}");
            }
            Assert.True(foundProductNameList.All(x => x.Contains(product)));
        }
    }
}
