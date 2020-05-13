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
    public class PersistencyService
    {
        private static readonly string filnavn = "blomster1.json";

        public static async Task GemDataTilDiskAsyncPS(ObservableCollection<OrdreBlomst> oc_blomst)
        {
            string jsonText = GetJsonPS(oc_blomst);
            StorageFolder localfolder = ApplicationData.Current.LocalFolder;
            StorageFile file = await localfolder.CreateFileAsync(filnavn, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(file, jsonText);
        }

        public static string GetJsonPS(ObservableCollection<OrdreBlomst> oc_blomst)
        {
            string json = JsonConvert.SerializeObject(oc_blomst);
            return json;
        }

        private static List<OrdreBlomst> DeserialiserJson(string jsonText)
        {
            List<OrdreBlomst> nyListe = JsonConvert.DeserializeObject<List<OrdreBlomst>>(jsonText);
            return nyListe;
        }

        public static async Task<List<OrdreBlomst>> HentDataFraDiskAsyncPS()
        {
            StorageFolder localfolder = ApplicationData.Current.LocalFolder;
            StorageFile file = await localfolder.GetFileAsync(filnavn);
            string jsonText = await FileIO.ReadTextAsync(file);
            List<OrdreBlomst> list = new List<OrdreBlomst>();
            list = DeserialiserJson(jsonText);

            return list;
        }


    }
}
