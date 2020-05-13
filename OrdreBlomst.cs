using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Blomsterbutik
{
    public class OrdreBlomst : INotifyPropertyChanged
    {
        private string navn;
        private int antal;
        private string farve;

        public string Navn 
        {
            get { return navn; }
            set { navn = value; OnPropertyChanged(); } 
        }

        public int Antal 
        {
            get { return antal; }
            set { antal = value; OnPropertyChanged(); }
        }

        public string Farve 
        {
            get { return farve; }
            set { farve = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public OrdreBlomst(string navn, int antal, string farve)
        {
            this.Navn = navn;
            this.Antal = antal;
            this.Farve = farve;
        }

        public OrdreBlomst()
        {

        }
    }
}
