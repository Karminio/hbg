namespace HotelEntities
{
    public enum CellActionTypeEnum { ParkLot, Start, CanBuild, CanBuy, CanBuyEntrance, FreeEntrance, FreeBuilding, NoAction }
    public enum CellEntranceTypeEnum { None, Left, Right, BothSides }
    public enum ContructionPermissionEnum { Granted = 1, Denied = 2, ForFree = 3, DoubleCharged = 4 }

    public static class GameConst
    {
        public const int LASTCELL = 31;
        public const int MONEYCELL = 7; // Banca
        public const decimal MONEYPRIZE = 2000;
        public const int ENTRANCECELL = 2; // Municipio
    }
}
