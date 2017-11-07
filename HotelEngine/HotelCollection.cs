using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace HotelEngine
{
    public class HotelCollection : Collection<HotelObj>
    {
        public HotelObj GetHotelByName(string name)
        {
            HotelObj returnItem = null;

            foreach (HotelObj item in this)
            {
                if (item.Name == name)
                {
                    return item;
                }
            }

            return null;
        }

        public void OverWrite(HotelObj newHotelObj)
        {
            HotelObj temp;
            foreach (HotelObj item in this)
            {
                if (item.Name == newHotelObj.Name)
                {
                    //temp = item;
                    Remove(item);
                    Add(newHotelObj);
                    break;
                }
            }

            temp = newHotelObj;
        }

        public HotelCollection GetOwnedProperties(Player p)
        {
            HotelCollection result = new HotelCollection();

            foreach (HotelObj hotel in this)
            {
                if (hotel.Owner != null && hotel.Owner.Equals(p))
                    result.Add(hotel);
            }

            return result;
        }
    }
}
