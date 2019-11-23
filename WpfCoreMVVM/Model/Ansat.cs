using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace WpfCoreMVVM.Model
{
    // Nedarver fra MvvmLights Observable object for at få change notification på
    public class Ansat : ObservableObject
    {
        private int id;
        private string navn;
        private int alder;
        private decimal loen;

        /// <summary>
        /// Get og Set til ID property
        /// Set metoden assigner en ny værdi og sørger for at raise propertyChange hvis nødvendigt 
        /// </summary>
        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                Set<int>(() => this.ID, ref id, value);
            }
        }
        /// <summary>
        /// Get og Set til Navn property
        /// Set metoden assigner en ny værdi og sørger for at raise propertyChange hvis nødvendigt 
        /// </summary>
        public string Navn
        {
            get
            {
                return navn;
            }
            set
            {
                Set<string>(() => this.Navn, ref navn, value);
            }
        }
        /// <summary>
        /// Get og Set til Alder property
        /// Set metoden assigner en ny værdi og sørger for at raise propertyChange hvis nødvendigt 
        /// </summary>
        public int Alder
        {
            get
            {
                return alder;
            }
            set
            {
                Set<int>(() => this.Alder, ref alder, value);
            }
        }
        /// <summary>
        /// Get og Set til Loen property
        /// Set metoden assigner en ny værdi og sørger for at raise propertyChange hvis nødvendigt 
        /// </summary>
        public decimal Loen
        {
            get
            {
                return loen;
            }
            set
            {
                Set<decimal>(() => this.Loen, ref loen, value);
            }
        }

        /// <summary>
        /// Metode til at generere en liste af ansatte (Dummy data)
        /// Læg mærke til det er en observable collection for at kunne benytte change tracking på den
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<Ansat> GetEksempelAnsatte()
        {
            ObservableCollection<Ansat> ansatte = new ObservableCollection<Ansat>();
            for (int i = 0; i < 30; ++i)
            {
                ansatte.Add(new Ansat
                {
                    ID = i + 1,
                    Navn = "Navn " + (i + 1).ToString(),
                    Alder = 20 + i,
                    Loen = 200000 + (i * 10)
                });
            }
            return ansatte;
        }
    }
}
