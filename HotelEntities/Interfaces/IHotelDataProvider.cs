namespace HotelEntities.Interfaces
{
    public interface IHotelDataProvider
    {
        GameCellCollection RetrieveGameCellCollection();

        HotelCollection RetrieveHotelCollection();
    }
}
