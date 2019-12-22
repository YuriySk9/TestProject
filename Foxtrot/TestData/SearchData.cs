using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

namespace Foxtrot.TestData
{
    public static class SearchData
    {
        public static IEnumerable LaptopData
        {
            get
            {
                yield return new TestCaseData(new SearchFieldModel()
                {
                    product = "asus"
                }).SetName("Search_LaptopCompany");

                yield return new TestCaseData(new SearchFieldModel()
                {
                    product = "asus vivobook"
                }).SetName("Search_LaptopCompanyAndLine");

                yield return new TestCaseData(new SearchFieldModel()
                {
                    product = "ноутбук"
                }).SetName("Search_LaptopCategory");
            }
        }

        public static SearchFieldModel goodsForAddinToCart = new SearchFieldModel()
        {
            productList = new List<string>()
            {
                "смартфон samsung galaxy a50",
                "фотоаппарат canon eos 80d"
            }
        };

        public static SearchFieldModel goodsForAddinToComparison = new SearchFieldModel()
        {
            productList = new List<string>()
            {
                "lenovo Ideapad s145",
                "asus vivobook f540ma"
            }
        };
    }
}
