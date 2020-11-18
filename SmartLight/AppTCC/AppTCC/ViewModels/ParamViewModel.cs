using System;
using Xamarin.Forms;
using SmartLight.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SmartLight.ViewModels
{
    public class ParamViewModel : BaseViewModel
    {        
        public ParamViewModel()
        {
            Sec = new ObservableCollection<List_Sec>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        public ObservableCollection<List_Sec> Sec { get; set; }
        public Command LoadItemsCommand { get; }
        
        public void OnAppearing()
        {
            IsBusy = true;
        }

       public async Task ExecuteLoadItemsCommand()
       {
            IsBusy = true;
            
            try
            {
                Sec.Clear();

                Entity item = await Data_Entities_Store.GetItemAsync("proto");
                                
                foreach (var sec in item.sectors)
                {
                    Sec.Add(new List_Sec
                    {
                        sector_tag = sec.sector_tag,
                        sector = sec.sector,
                    });
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
       }

    }
}
