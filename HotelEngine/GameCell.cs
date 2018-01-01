using System;
using System.Collections;
using System.Text;

namespace HotelEngine
{
    public class GameCell
    {
        public GameCell()
        { }

        public GameCell(int position, CellActionTypeEnum cat, string leftHO, string rightHO)
        {
            m_position = position;
            CellActionType = cat;
            Entrance = CellEntranceTypeEnum.None;
            m_hotels[0] = leftHO;
            m_hotels[1] = rightHO;
        }

        public CellActionTypeEnum CellActionType { get; set; }

        public CellEntranceTypeEnum Entrance { get; set; }

        /// <summary>
        /// Rispettivamente proprietà SX e DX con cui la cella confina
        /// </summary>
        //HotelObj[] m_hotels = new HotelObj[2] { null, null };
        string[] m_hotels = new string[2] { "", "" };


        //public HotelObj[] Hotels
        //{
        //    get { return m_hotels; }
        //    set { m_hotels = value; }
        //}

        //public HotelObj LeftHotel
        //{
        //    get { return m_hotels[0]; }
        //    set { m_hotels[0] = value; }
        //}
        //public HotelObj RightHotel
        //{
        //    get { return m_hotels[1]; }
        //    set { m_hotels[1] = value; }
        //}

        public string LeftHotel
        {
            get { return m_hotels[0]; }
            set { m_hotels[0] = value; }
        }
        public string RightHotel
        {
            get { return m_hotels[1]; }
            set { m_hotels[1] = value; }
        }

        //public bool AddEntrance(CellEntranceTypeEnum side, Player currentPlayer, bool freeEntrance)
        //{
        //    // Se esiste già l'entrata esco subito
        //    if (m_entrance == CellEntranceTypeEnum.BothSides || m_entrance == side)
        //        return false;

        //    HotelObj tempHotel = null;

        //    if (side == CellEntranceTypeEnum.Left)
        //        tempHotel = LeftHotel;
        //    else if (side == CellEntranceTypeEnum.Right)
        //        tempHotel = RightHotel;
        //    else
        //        return false;

        //    if (tempHotel.CanHaveEntrance() && tempHotel.Owner == currentPlayer)
        //    {
        //        if (freeEntrance || tempHotel.Owner.Money >= tempHotel.EntranceCost)
        //        {
        //            tempHotel.Owner.Money -= tempHotel.EntranceCost;
        //            m_entrance = side;
        //            return true;
        //        }
        //        else
        //            return false;
        //    }
        //    else
        //        return false;
        //}

        private int m_position;

        public int Position
        {
            get { return m_position; }
            set { m_position = value; }
        }
    }
}
