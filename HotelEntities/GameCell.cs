using System;
using System.Collections;
using System.Text;

namespace HotelEntities
{
    public class GameCell
    {
        public GameCell()
        { }

        public GameCell(int position, CellActionTypeEnum cat, string leftHO, string rightHO)
        {
            _position = position;
            CellActionType = cat;
            Entrance = CellEntranceTypeEnum.None;
            _hotels[0] = leftHO;
            _hotels[1] = rightHO;
        }

        public CellActionTypeEnum CellActionType { get; set; }

        public CellEntranceTypeEnum Entrance { get; set; }

        /// <summary>
        /// Rispettivamente proprietà SX e DX con cui la cella confina
        /// </summary>
        //HotelObj[] _hotels = new HotelObj[2] { null, null };
        string[] _hotels = new string[2] { "", "" };


        //public HotelObj[] Hotels
        //{
        //    get { return _hotels; }
        //    set { _hotels = value; }
        //}

        //public HotelObj LeftHotel
        //{
        //    get { return _hotels[0]; }
        //    set { _hotels[0] = value; }
        //}
        //public HotelObj RightHotel
        //{
        //    get { return _hotels[1]; }
        //    set { _hotels[1] = value; }
        //}

        public string LeftHotel
        {
            get { return _hotels[0]; }
            set { _hotels[0] = value; }
        }
        public string RightHotel
        {
            get { return _hotels[1]; }
            set { _hotels[1] = value; }
        }

        //public bool AddEntrance(CellEntranceTypeEnum side, Player currentPlayer, bool freeEntrance)
        //{
        //    // Se esiste già l'entrata esco subito
        //    if (_entrance == CellEntranceTypeEnum.BothSides || _entrance == side)
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
        //            _entrance = side;
        //            return true;
        //        }
        //        else
        //            return false;
        //    }
        //    else
        //        return false;
        //}

        private int _position;

        public int Position
        {
            get { return _position; }
            set { _position = value; }
        }
    }
}
