using BlomstViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

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

        private string jsonBlomster;
        public string JsonBlomster
        {
            get { return jsonBlomster; }
            set { jsonBlomster = value; }
        }

        StorageFolder localfolder = null;

        private readonly string filnavn = "blomster1.json";

        public OrdreBlomst SelectedOrdreBlomst { get; set; }

        public RelayCommand AddNyBlomst { get; set; }
        public RelayCommand SletSelectedBlomst { get; set; }
        public RelayCommand GemData { get; set; }
        public RelayCommand HentData { get; set; }

        public BlomstViewModel()
        {
            OC_Blomster = new ObservableCollection<OrdreBlomst>();

            OC_Blomster.Add(new OrdreBlomst("Tulipan", 4, "Rød"));
            OC_Blomster.Add(new OrdreBlomst("Tulipan", 3, "Hvid"));
            OC_Blomster.Add(new OrdreBlomst("Tulipan", 2, "Gul"));

            AddNyBlomst = new RelayCommand(AddBlomst);
            SletSelectedBlomst = new RelayCommand(SletBlomst, canDeleteBlomsterListe);
            SelectedOrdreBlomst = new OrdreBlomst();

            localfolder = ApplicationData.Current.LocalFolder;

            GemData = new RelayCommand(GemDataTilDiskAsync);
            HentData = new RelayCommand(HentDataFraDiskAsync);
            DanData();
        }

        public void AddBlomst()
        {
            OrdreBlomst oBlomst = new OrdreBlomst(NavnBlomst, AntalBlomst, FarveBlomst);

            OC_Blomster.Add(oBlomst);
            SletSelectedBlomst.RaiseCanExecuteChanged();
        }

        private void SletBlomst()
        {
            OC_Blomster.Remove(SelectedOrdreBlomst);
            SletSelectedBlomst.RaiseCanExecuteChanged();
        }

        private bool canDeleteBlomsterListe()
        {
            return OC_Blomster.Count > 0;
        }

        /// <summary>
        /// Giver mig Jsonformat for OC_blomster objektet
        /// </summary>
        /// <returns></returns>
        private string GetJson()
        {
            string json = JsonConvert.SerializeObject(OC_Blomster);
            return json;
        }

        /// <summary>
        /// Gemmer json data fra liste i localfolder
        /// </summary>
        private async void GemDataTilDiskAsync()
        {
            this.jsonBlomster = GetJson();
            StorageFile file = await localfolder.CreateFileAsync(filnavn, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(file, this.jsonBlomster);
            SletSelectedBlomst.RaiseCanExecuteChanged();
        }

        public void IndsætJson(string jsonText)
        {
            List<OrdreBlomst> nyListe = JsonConvert.DeserializeObject<List<OrdreBlomst>>(jsonText);
            foreach (var blomst in nyListe)
            {
                this.OC_Blomster.Add(blomst);
            }
            SletSelectedBlomst.RaiseCanExecuteChanged();
        }

        private async void HentDataFraDiskAsync()
        {
            StorageFile file = await localfolder.GetFileAsync(filnavn);
            string jsonText = await FileIO.ReadTextAsync(file);
            this.OC_Blomster.Clear();
            IndsætJson(jsonText);
        }

        private void DanData()
        {
            //for (int i = 0; i < 10; i++)
            //{
            //    var blomst = new OrdreBlomst("tulipan", i, "blå");
            //    OC_Blomster.Add(blomst);
            //}
        }
    }
}
