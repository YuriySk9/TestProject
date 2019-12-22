using Foxtrot.TestData;
using NUnit.Framework;
using System.Collections.Generic;

namespace Foxtrot.Tests.Compare
{
    [TestFixture]
    public class AddToComparison : BaseTest
    {

        [SetUp]
        public void SetUp()
        {
            if (app.comparingHelper.WhetherAnyGoodsInComparing())
            {
                app.comparingHelper.ClearComparing();
            }
        }

        [TearDown]
        public void TearDown()
        {
            if (app.comparingHelper.WhetherAnyGoodsInComparing())
            {
                app.comparingHelper.ClearComparing();
            }
        }

        [Test]
        public void AddProductsToComparison()
        {   
            List<string> productList = SearchData.goodsForAddinToComparison.productList;

            List<string> addedProductList = app.comparingHelper.AddProductListToComparison(productList);
            app.comparingHelper.GoToPage();
            List<string> productListComparePage = app.comparingHelper.GetProductNameList();

            CollectionAssert.AreEquivalent(addedProductList, productListComparePage);
        }
    }
}
