using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelEngine
{
    public class EntrancePosition
    {
        public int Id { get; set; }

        public int Position { get; set; }

        public CellEntranceTypeEnum Side { get; set; }
    }
}
