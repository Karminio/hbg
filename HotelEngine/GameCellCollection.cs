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
            GameCell returnItem = null;

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
        public List<int> GetEntrancesPosition()
        {
            List<int> result = new List<int>();

            foreach (GameCell item in this)
            {
                if (item.Entrance == CellEntranceTypeEnum.Right)
                {
                    result.Add(item.Position);
                }
                else if (item.Entrance == CellEntranceTypeEnum.Left)
                {
                    result.Add(item.Position + 100);
                }
                else if (item.Entrance == CellEntranceTypeEnum.BothSides)
                {
                    result.Add(item.Position);
                    result.Add(item.Position + 100);
                }
            }

            return result;
        }

        public void SetEntrancePosition(List<int> positions)
        {
            foreach (int i in positions)
            {
                if (i < 100)
                {
                    if (this[i].Entrance == CellEntranceTypeEnum.None)
                        this[i].Entrance = CellEntranceTypeEnum.Right;
                    else
                        this[i].Entrance = CellEntranceTypeEnum.BothSides;
                }
                else
                {
                    int j = i - 100;
                    if (this[j].Entrance == CellEntranceTypeEnum.None)
                        this[j].Entrance = CellEntranceTypeEnum.Left;
                    else
                        this[j].Entrance = CellEntranceTypeEnum.BothSides;
                }
            }

        }
    }
}
