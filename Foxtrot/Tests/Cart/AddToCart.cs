using Foxtrot.TestData;
using NUnit.Framework;
using System.Collections.Generic;

namespace Foxtrot.Tests.Cart
{
    [TestFixture]
    public class AddToCart : BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            if (app.cartHelper.WhetherAnyGoodsInCart())
            {
                app.cartHelper.GoToPage()
                              .DeleteAllGoods()
                              .CloseCatrButtonClick();
            }
        }

        [TearDown]
        public void TearDown()
        {
            if (app.cartHelper.WhetherAnyGoodsInCart())
            {
                app.cartHelper.DeleteAllGoods()
                              .CloseCatrButtonClick();
            }
        }

        [Test]
        public void AddGoodsToCart()
        {
            List<string> productList = SearchData.goodsForAddinToCart.productList;

            List<string> addedProductList = app.cartHelper.AddProductListToCart(productList);
            List<string> productNameListCartPage = app.cartHelper.GoToPage()
                                                                 .GetProductNameList();
            CollectionAssert.AreEquivalent(addedProductList, productNameListCartPage);
        }
    }
}
