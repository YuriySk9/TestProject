using Foxtrot.Models;

namespace Foxtrot.TestData
{
    public static class GoodsCatalogData
    {
        public static GoodsCatalogModel laptops = new GoodsCatalogModel()
        {
            firstLevel = "Ноутбуки, ПК",
            secondLevel = "Ноутбуки"
        };

        public static GoodsCatalogModel freezers = new GoodsCatalogModel()
        {
            firstLevel = "Техника для кухни",
            secondLevel = "Морозильные камеры"
        };
    }
}
