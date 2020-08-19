using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TheBestCarShop___Admin.Class_files.Basics
{
    public class ProductStatistic : INotifyPropertyChanged
    {
        /// <summary>
        /// This class is used to represent basic info about product sales
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        private DateTime firstBought;
        public DateTime FirstBought
        {
            get
            {
                return firstBought;
            }
            set
            {
                if (firstBought != value)
                {
                    firstBought = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FirstBought"));
                }
            }
        }

        private DateTime lastBought;
        public DateTime LastBought
        {
            get
            {
                return lastBought;
            }
            set
            {
                if (lastBought != value)
                {
                    lastBought = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LastBought"));
                }
            }
        }

        private int amountSold;
        public int AmountSold
        {
            get
            {
                return amountSold;
            }
            set
            {
                if (amountSold != value)
                {
                    amountSold = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AmountSold"));
                }
            }
        }
    }
}
