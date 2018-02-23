using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace HotelEntities
{
    public class HotelObj
    {
        public HotelObj()
        { }

        public HotelObj(string name, decimal cost, decimal entranceCost)
        {
            _Name = name;
            _Cost = cost;
            _EntranceCost = entranceCost;

            _CurrentCategory = 0;
            _Owner = null;
            _Rate = new List<Category>();
        }

        #region Properties
        public int Id { get; set; }
        
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private decimal _Cost;
        public decimal Cost
        {
            get { return _Cost; }
            set { _Cost = value; }
        }

        private decimal _EntranceCost;
        public decimal EntranceCost
        {
            get { return _EntranceCost; }
            set { _EntranceCost = value; }
        }

        private int _CurrentCategory;
        public int CurrentCategory
        {
            get { return _CurrentCategory; }
            set { _CurrentCategory = value; }
        }

        /// <summary>
        /// Proprietario della Struttura
        /// </summary>
        private Player _Owner;
        public Player Owner
        {
            get { return _Owner; }
            set { _Owner = value; }
        }

        /// <summary>
        /// List of possible categories
        /// </summary>
        private List<Category> _Rate;
        [XmlArray("Rates")]
        [XmlArrayItem("Rate", typeof(Category))]
        public List<Category> Rate
        {
            get { return _Rate; }
            set { _Rate = value; }
        }
        #endregion

        public int MaxCategory
        {
            get { return (int)(_Rate.Count - 1); }
        }

        /// <summary>
        /// Collezione di oggetti Category
        /// </summary>

        public Category GetRate(int idx)
        {
            return (Category) _Rate[idx];
        }

        public Category GetCurrentRate()
        {
            return (Category)_Rate[_CurrentCategory];
        }

        /// <summary>
        /// Utilizzata per inizializzare la tabella listini/categorie degli hotel
        /// </summary>
        /// <param name="c">Oggetto di tipo Categoria</param>
        public void AddCategory(Category c) { _Rate.Add(c); }

        /// <summary>
        /// Utilizzata per impostare il costo della proprietà al 50% dopo il primo acquisto
        /// </summary>
        public void SetExpropriationCost() {_Cost /= 2;}

        public bool CanHaveEntrance()
        {
            return CurrentCategory > 0;
        }

        public bool UpgradeCategory(Player currentPlayer, int requestedCategory, decimal cost)
        {
            if (_Owner == currentPlayer && currentPlayer.Money >= cost)
            {
                currentPlayer.Money -= cost;
                _CurrentCategory = requestedCategory;
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
            _BuildingCost = buildingCost;
            _PricePerNight = pricePerNight;
        }

        public int Id { get; set; }

        private decimal _BuildingCost;
        public decimal BuildingCost
        {
            get { return _BuildingCost; }
            set { _BuildingCost = value; }
        }

        private decimal _PricePerNight;
        public decimal PricePerNight
        {
            get { return _PricePerNight; }
            set { _PricePerNight = value; }
        }
    }
}
