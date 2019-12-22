using Foxtrot.TestData;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Foxtrot.Tests.Sorting
{
    [TestFixture]
    public class SortingTests : BaseTest
    {
        [Test]
        public void SortingFromCheapToExpensive()
        {
            app.productCatalogHelper.GoToCategory(GoodsCatalogData.freezers);
            app.sortingHelper.SortBy(SortData.fromCheapToExpensive);
            List<int> actualPriceList = app.productListHelper.GetPriceList();
            var sortedPriceList = actualPriceList.OrderBy(x => x);
            CollectionAssert.AreEqual(sortedPriceList, actualPriceList);
        }

        [Test]
        public void SortingByRating()
        {
            app.productCatalogHelper.GoToCategory(GoodsCatalogData.freezers);
            app.sortingHelper.SortBy(SortData.byRating);
            List<int> actualRatingList = app.productListHelper.GetRatingList();
            var sortedRatingList = actualRatingList.OrderByDescending(x => x);

            CollectionAssert.AreEqual(sortedRatingList, actualRatingList);
        }
    }
}
