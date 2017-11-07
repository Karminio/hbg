using System;
using System.Collections.Generic;
using System.Text;
using HotelEngine;
using System.Collections.ObjectModel;
using System.Collections;

namespace HotelEngine
{
    public class OwnershipCollection : Collection<Ownership>
    {
        public OwnershipCollection()
        {
        }

        public HotelCollection GetAllOwnedHotels()
        {
            HotelCollection resultItem = new HotelCollection();
            foreach (Ownership os in this)
            {
                resultItem.Add(os.Hotel);
            }

            return resultItem;
        }

        public int GetHotelOwnerID(HotelObj hotel)
        {
            foreach (Ownership os in this)
            {
                if (os.Hotel.Equals(hotel))
                    return os.OwnerID;
            }
            
            return -1;
        }

        public HotelCollection GetOwnedHotelsByPlayerID(int playerID)
        {
            HotelCollection resultItem = new HotelCollection();
            foreach (Ownership os in this)
            {
                if (os.OwnerID == playerID)
                    resultItem.Add(os.Hotel);
            }

            return resultItem;
        }

        /// <summary>
        /// Adds a new ownership
        /// </summary>
        /// <returns>Returns false if ownership already exists, true otherwise</returns>
        public bool AddOwnership(HotelObj hotel, int playerID)
        {
            if (!OwnershipExists(hotel))
            {
                Add(new Ownership() { Hotel = hotel, OwnerID = playerID });
                return true;
            }
            return false;
        }

        /// <summary>
        /// Removes an ownership
        /// </summary>
        /// <returns>Returns false if ownership doesn't exists, true otherwise</returns>
        public bool RemoveOwnership(HotelObj hotel)
        {
            foreach (Ownership os in this)
            {
                if (os.Hotel.Equals(hotel))
                {
                    Remove(os);
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Transfers the ownership of a property from a player to another
        /// </summary>
        /// <returns>Returns false if something goes wrong</returns>
        public bool TransferOwnership(HotelObj hotel, int oldOwnerID, int newOwnerID)
        {
            if (RemoveOwnership(hotel))
            {
                if (AddOwnership(hotel, newOwnerID))
                    return true;
                else
                    AddOwnership(hotel, oldOwnerID); // roll back!
            }

            return false;
        }

        public bool OwnershipExists(HotelObj hotel)
        {
            foreach (Ownership os in this)
            {
                if (os.Hotel.Equals(hotel))
                    return true;
            }

            return false;
        }
    }

    /// <summary>
    /// Class used for ownerships serialization
    /// Remarks: while player full information is stored in the provided member list (so ID is enough here)
    /// Hotel information is mantained entirely because hotel data don't change untill hotel is bought
    /// </summary>
    public class Ownership
    {
        /// <summary>
        /// Player ID value of the owner
        /// </summary>
        private int m_ownerID;
        public int OwnerID
        {
            get { return m_ownerID; }
            set { m_ownerID = value; }
        }

        private HotelObj m_hotel;
        public HotelObj Hotel
        {
            get { return m_hotel; }
            set { m_hotel = value; }
        }
    }

}
