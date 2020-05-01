using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blomsterbutik
{
    public class BlomstViewModel
    {
        public ObservableCollection<OrdreBlomst> OC_Blomster
        {
            get
            {
                return new ObservableCollection<OrdreBlomst>()
                {
                    new OrdreBlomst() { Navn = "Tulipan", Antal = 5, Farve = "Rød"},
                    new OrdreBlomst() { Navn = "Tulipan", Antal = 3, Farve = "Grøn"}
                };
            }
        }

    }
}
