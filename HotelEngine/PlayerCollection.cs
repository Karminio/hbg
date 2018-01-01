using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace HotelEngine
{
    public class PlayerCollection : Collection<Player>
    {
        private int nextID;

        public PlayerCollection()
        {
            nextID = 0;
        }

        /// <summary>
        /// Join a new player to the game
        /// Remark: up to 4 players allowed
        /// </summary>
        /// <param name="newPlayer"></param>
        /// <returns>True if player can join the game, false otherwise</returns>
        public new bool Add(Player newPlayer)
        {
            if (nextID <= 3 && !Exists(newPlayer.Name))
            {
                newPlayer.Id = nextID;
                base.Add(newPlayer);
                nextID++;
                return true;
            }

            return false;
        }

        public Player GetPlayerByID(int playerID)
        {
            foreach (Player item in this)
            {
                if (item.Id == playerID)
                {
                    return item;
                }
            }

            return null;
        }

        public bool Exists(string playerName)
        {
            foreach (Player item in this)
            {
                if (item.Name == playerName)
                {
                    return true;
                }
            }

            return false;
        }

    }
}
