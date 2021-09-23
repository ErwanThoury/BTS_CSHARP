using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ClassesMetier
{
    public class Place : INotifyPropertyChanged
    {
        private double prix;
        private char etat;
        public int IdPlace { get; set; }
        public char CodeTarif { get; set; }
        public bool Occupee { get; set; }

        public double Prix
        {
            get
            {
                return prix;
            }
            set
            {
                prix = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Prix"));
                }
            }
        }

        public char Etat 
        {
            get
            {
                return etat;
            }
            set
            {
                etat = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Etat"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
