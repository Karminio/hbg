using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace HotelEngine
{
    public class GameCellCollection : Collection<GameCell>
    {
        public GameCell GetCellByPosition(int position)
        {
            foreach (GameCell item in this)
            {
                if (item.Position == position)
                {
                    return item;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets an integer list with number of cells whose have at least an entrance
        /// Each element indicates an entrance in the corrisponding cell number, left side of cells uses an offset of 100.
        /// Examples:
        /// cell 12 right -> 12
        /// cell 14 left -> 114
        /// </summary>
        /// <returns></returns>
        public List<EntrancePosition> GetEntrancesPosition()
        {
            List<EntrancePosition> result = new List<EntrancePosition>();

            foreach (GameCell item in this)
            {
                result.Add(new EntrancePosition() { Position = item.Position, Side = item.Entrance });
            }

            return result;
        }

        public void SetEntrancePosition(List<EntrancePosition> positions)
        {
            foreach (EntrancePosition i in positions)
            {
                this[i.Position].Entrance = i.Side;
            }

        }
    }
}
