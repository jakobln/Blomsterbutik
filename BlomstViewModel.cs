using BlomstViewModel;
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
        private string navnBlomst;
        private int antalBlomst;
        private string farveBlomst;

        public ObservableCollection<OrdreBlomst> OC_Blomster { get; set; }

        public string NavnBlomst { get => navnBlomst; set => navnBlomst = value; }
        public int AntalBlomst { get => antalBlomst; set => antalBlomst = value; }
        public string FarveBlomst { get => farveBlomst; set => farveBlomst = value; }

        public OrdreBlomst SelectedOrdreBlomst { get; set; }

        public RelayCommand AddNyBlomst { get; set; }

        public RelayCommand SletSelectedBlomst { get; set; }

        public BlomstViewModel()
        {
            OC_Blomster = new ObservableCollection<OrdreBlomst>();

            OC_Blomster.Add(new OrdreBlomst("Tulipan", 4, "Rød"));
            OC_Blomster.Add(new OrdreBlomst("Tulipan", 3, "Hvid"));
            OC_Blomster.Add(new OrdreBlomst("Tulipan", 2, "Gul"));

            AddNyBlomst = new RelayCommand(AddBlomst);
            SletSelectedBlomst = new RelayCommand(SletBlomst);
            SelectedOrdreBlomst = new OrdreBlomst();
        }

        public void AddBlomst()
        {
            OrdreBlomst oBlomst = new OrdreBlomst(NavnBlomst, AntalBlomst, FarveBlomst);

            OC_Blomster.Add(oBlomst);
        }

        private void SletBlomst()
        {
            OC_Blomster.Remove(SelectedOrdreBlomst);
        }
    }
}
