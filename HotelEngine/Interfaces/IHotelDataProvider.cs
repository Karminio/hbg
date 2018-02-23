using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelEntities;

namespace HotelEngine.Interfaces
{
    public interface IHotelDataProvider
    {
        GameCellCollection RetrieveGameCellCollection();
    }
}
