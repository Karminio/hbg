using HotelEntities;
using Newtonsoft.Json;
using System.Configuration;
using System.IO;

namespace HotelJSONDataProvider
{
    public class HotelJSONDataProvider
    {
        public GameCellCollection RetrieveGameCellCollection()
        {
            string filePath = ConfigurationManager.AppSettings.Get("PersistenceFilePath");
            string JSON = File.ReadAllText(filePath);
            GameCellCollection gcc = JsonConvert.DeserializeObject(JSON) as GameCellCollection;

            return gcc;
        }
    }
}
