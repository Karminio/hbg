using HotelEntities;
using HotelEntities.Interfaces;
using Newtonsoft.Json;
using System.Configuration;
using System.IO;

namespace Hotel.JSONProvider
{
    public class HotelJSONDataProvider : IHotelDataProvider
    {
        public GameCellCollection RetrieveGameCellCollection()
        {
            string filePath = ConfigurationManager.AppSettings.Get("CellCollectionPath");
            string JSON = File.ReadAllText(filePath);
            GameCellCollection gcc = JsonConvert.DeserializeObject<GameCellCollection>(JSON);

            return gcc;
        }

        public HotelCollection RetrieveHotelCollection()
        {
            string filePath = ConfigurationManager.AppSettings.Get("HotelCollectionPath");
            string JSON = File.ReadAllText(filePath);
            HotelCollection hc = JsonConvert.DeserializeObject<HotelCollection>(JSON);

            return hc;
        }
    }
}
