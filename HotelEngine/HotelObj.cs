using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace HotelEngine
{
    public class HotelObj
    {
        public HotelObj()
        { }

        public HotelObj(string name, decimal cost, decimal entranceCost)
        {
            m_Name = name;
            m_Cost = cost;
            m_EntranceCost = entranceCost;

            m_CurrentCategory = 0;
            m_Owner = null;
            m_Rate = new List<Category>();
        }

        #region Properties
        public int Id { get; set; }
        
        private string m_Name;
        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        private decimal m_Cost;
        public decimal Cost
        {
            get { return m_Cost; }
            set { m_Cost = value; }
        }

        private decimal m_EntranceCost;
        public decimal EntranceCost
        {
            get { return m_EntranceCost; }
            set { m_EntranceCost = value; }
        }

        private int m_CurrentCategory;
        public int CurrentCategory
        {
            get { return m_CurrentCategory; }
            set { m_CurrentCategory = value; }
        }

        /// <summary>
        /// Proprietario della Struttura
        /// </summary>
        private Player m_Owner;
        public Player Owner
        {
            get { return m_Owner; }
            set { m_Owner = value; }
        }

        /// <summary>
        /// List of possible categories
        /// </summary>
        private List<Category> m_Rate;
        [XmlArray("Rates")]
        [XmlArrayItem("Rate", typeof(Category))]
        public List<Category> Rate
        {
            get { return m_Rate; }
            set { m_Rate = value; }
        }
        #endregion

        public int MaxCategory
        {
            get { return (int)(m_Rate.Count - 1); }
        }

        /// <summary>
        /// Collezione di oggetti Category
        /// </summary>

        public Category GetRate(int idx)
        {
            return (Category) m_Rate[idx];
        }

        public Category GetCurrentRate()
        {
            return (Category)m_Rate[m_CurrentCategory];
        }

        /// <summary>
        /// Utilizzata per inizializzare la tabella listini/categorie degli hotel
        /// </summary>
        /// <param name="c">Oggetto di tipo Categoria</param>
        public void AddCategory(Category c) { m_Rate.Add(c); }

        /// <summary>
        /// Utilizzata per impostare il costo della proprietà al 50% dopo il primo acquisto
        /// </summary>
        public void SetExpropriationCost() {m_Cost /= 2;}

        public bool CanHaveEntrance()
        {
            return CurrentCategory > 0;
        }

        public bool UpgradeCategory(Player currentPlayer, int requestedCategory, decimal cost)
        {
            if (m_Owner == currentPlayer && currentPlayer.Money >= cost)
            {
                currentPlayer.Money -= cost;
                m_CurrentCategory = requestedCategory;
                return true;
            }
            else
            {
                return true;
            }
        }
    }

    /// <summary>
    /// Oggetto che contiene il costo dell'edificio e la relativa tariffa per notte
    /// </summary>
    public class Category
    {
        public Category()
        { }

        public Category(decimal buildingCost, decimal pricePerNight)
        {
            m_BuildingCost = buildingCost;
            m_PricePerNight = pricePerNight;
        }

        public int Id { get; set; }

        private decimal m_BuildingCost;
        public decimal BuildingCost
        {
            get { return m_BuildingCost; }
            set { m_BuildingCost = value; }
        }

        private decimal m_PricePerNight;
        public decimal PricePerNight
        {
            get { return m_PricePerNight; }
            set { m_PricePerNight = value; }
        }
    }
}
