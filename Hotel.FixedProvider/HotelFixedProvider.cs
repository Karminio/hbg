using HotelEntities.Interfaces;
using HotelEntities;

namespace Hotel.FixedProvider
{
    public class HotelFixedProvider : IHotelDataProvider
    {
        HotelCollection _hotelList;
        GameCellCollection _cellsList;

        public HotelFixedProvider() {
            InitHotelList();
            InitGameCellList();        
        }

        private void InitHotelList()
        {
            _hotelList = new HotelCollection();

            // TODO: create an XML to serialize hotel data
            // President
            HotelObj hoPresident = new HotelObj("President", 3500, 250);
            hoPresident.AddCategory(new Category(5000, 200));
            hoPresident.AddCategory(new Category(3000, 400));
            hoPresident.AddCategory(new Category(2250, 600));
            hoPresident.AddCategory(new Category(1750, 800));
            hoPresident.AddCategory(new Category(5000, 1100));
            _hotelList.Add(hoPresident);

            // Royal
            HotelObj hoRoyal = new HotelObj("Royal", 2500, 200);
            hoRoyal.AddCategory(new Category(3600, 150));
            hoRoyal.AddCategory(new Category(2600, 300));
            hoRoyal.AddCategory(new Category(1800, 300));
            hoRoyal.AddCategory(new Category(1800, 450));
            hoRoyal.AddCategory(new Category(3000, 600));
            _hotelList.Add(hoRoyal);

            // Waikiki
            HotelObj hoWaikiki = new HotelObj("Waikiki", 250, 200);
            hoWaikiki.AddCategory(new Category(3500, 200));
            hoWaikiki.AddCategory(new Category(2500, 350));
            hoWaikiki.AddCategory(new Category(2500, 500));
            hoWaikiki.AddCategory(new Category(1750, 500));
            hoWaikiki.AddCategory(new Category(1750, 650));
            hoWaikiki.AddCategory(new Category(2500, 1000));
            _hotelList.Add(hoWaikiki);

            // Safari
            HotelObj hoSafari = new HotelObj("Safari", 2000, 150);
            hoSafari.AddCategory(new Category(2600, 100));
            hoSafari.AddCategory(new Category(1200, 100));
            hoSafari.AddCategory(new Category(1200, 250));
            hoSafari.AddCategory(new Category(2000, 500));
            _hotelList.Add(hoSafari);

            // Boomerang
            HotelObj hoBoomerang = new HotelObj("Boomerang", 500, 100);
            hoBoomerang.AddCategory(new Category(1800, 400));
            hoBoomerang.AddCategory(new Category(250, 600));
            _hotelList.Add(hoBoomerang);

            // Taj Mahal
            HotelObj hoTajMahal = new HotelObj("Taj Mahal", 1500, 100);
            hoTajMahal.AddCategory(new Category(2400, 100));
            hoTajMahal.AddCategory(new Category(1000, 100));
            hoTajMahal.AddCategory(new Category(500, 200));
            hoTajMahal.AddCategory(new Category(1000, 300));
            _hotelList.Add(hoTajMahal);

            // Fujiyama
            HotelObj hoFujiyama = new HotelObj("Fujiyama", 1000, 100);
            hoFujiyama.AddCategory(new Category(2200, 100));
            hoFujiyama.AddCategory(new Category(1400, 100));
            hoFujiyama.AddCategory(new Category(1400, 200));
            hoFujiyama.AddCategory(new Category(500, 400));
            _hotelList.Add(hoFujiyama);

            // Etoile
            HotelObj hoEtoile = new HotelObj("L' Etoile", 3000, 250);
            hoEtoile.AddCategory(new Category(3300, 150));
            hoEtoile.AddCategory(new Category(2200, 300));
            hoEtoile.AddCategory(new Category(1800, 300));
            hoEtoile.AddCategory(new Category(1800, 300));
            hoEtoile.AddCategory(new Category(1800, 450));
            hoEtoile.AddCategory(new Category(4000, 750));
            _hotelList.Add(hoEtoile);

        }

        private void InitGameCellList()
        {
            _cellsList = new GameCellCollection();

            _cellsList.Add(new GameCell(-1, CellActionTypeEnum.ParkLot, null, null));  // Park lot
            _cellsList.Add(new GameCell(0, CellActionTypeEnum.Start, null, null));
            _cellsList.Add(new GameCell(1, CellActionTypeEnum.CanBuild, null, "Fujiyama"));
            _cellsList.Add(new GameCell(2, CellActionTypeEnum.CanBuy, "Boomerang", "Fujiyama"));
            _cellsList.Add(new GameCell(3, CellActionTypeEnum.CanBuild, "Boomerang", "Fujiyama"));
            _cellsList.Add(new GameCell(4, CellActionTypeEnum.CanBuy, "Boomerang", "Fujiyama"));
            _cellsList.Add(new GameCell(5, CellActionTypeEnum.CanBuild, "Boomerang", "Fujiyama"));
            _cellsList.Add(new GameCell(6, CellActionTypeEnum.FreeEntrance, null, "Fujiyama"));  // Bank
            _cellsList.Add(new GameCell(7, CellActionTypeEnum.CanBuild, null, null));  // Bank/River
            _cellsList.Add(new GameCell(8, CellActionTypeEnum.CanBuy, null, "L' Etoile"));  // Bank
            _cellsList.Add(new GameCell(9, CellActionTypeEnum.CanBuy, "President", "L' Etoile"));
            _cellsList.Add(new GameCell(10, CellActionTypeEnum.FreeBuilding, "President", "L' Etoile"));
            _cellsList.Add(new GameCell(11, CellActionTypeEnum.CanBuy, "President", "Royal"));
            _cellsList.Add(new GameCell(12, CellActionTypeEnum.CanBuild, "President", "Royal"));
            _cellsList.Add(new GameCell(13, CellActionTypeEnum.CanBuy, "President", "Royal"));
            _cellsList.Add(new GameCell(14, CellActionTypeEnum.CanBuild, "President", "Royal"));
            _cellsList.Add(new GameCell(15, CellActionTypeEnum.CanBuy, "President", "Royal"));
            _cellsList.Add(new GameCell(16, CellActionTypeEnum.CanBuild, "Waikiki", "Royal"));
            _cellsList.Add(new GameCell(17, CellActionTypeEnum.CanBuy, "Waikiki", "Royal"));
            _cellsList.Add(new GameCell(18, CellActionTypeEnum.FreeEntrance, "Waikiki", "Royal"));
            _cellsList.Add(new GameCell(19, CellActionTypeEnum.CanBuild, "Waikiki", "Royal"));
            _cellsList.Add(new GameCell(20, CellActionTypeEnum.CanBuy, "Waikiki", "Royal"));
            _cellsList.Add(new GameCell(21, CellActionTypeEnum.CanBuy, "Taj Mahal", "L' Etoile"));
            _cellsList.Add(new GameCell(22, CellActionTypeEnum.CanBuild, "Taj Mahal", "L' Etoile"));
            _cellsList.Add(new GameCell(23, CellActionTypeEnum.CanBuy, "Taj Mahal", "L' Etoile"));
            _cellsList.Add(new GameCell(24, CellActionTypeEnum.FreeEntrance, "Taj Mahal", "L' Etoile"));
            _cellsList.Add(new GameCell(25, CellActionTypeEnum.CanBuild, "Taj Mahal", null));  // Town hall
            _cellsList.Add(new GameCell(26, CellActionTypeEnum.CanBuild, "Safari", null));  // Town hall
            _cellsList.Add(new GameCell(27, CellActionTypeEnum.CanBuild, "Safari", null));  // Town hall
            _cellsList.Add(new GameCell(28, CellActionTypeEnum.CanBuy, "Safari", "L' Etoile"));
            _cellsList.Add(new GameCell(29, CellActionTypeEnum.FreeEntrance, "Safari", "L' Etoile"));
            _cellsList.Add(new GameCell(30, CellActionTypeEnum.CanBuild, "Safari", null));  // River*/
        }

        public HotelCollection RetrieveHotelCollection()
        {
            return _hotelList;
        }

        public GameCellCollection RetrieveGameCellCollection()
        {
            return _cellsList;
        }
    }
}
