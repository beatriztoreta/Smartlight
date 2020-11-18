using System;
using Xamarin.Forms;
using SmartLight.Models;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SmartLight.ViewModels
{
    public class GraphicsViewModel : BaseViewModel
    {
        public Command BarrasCommand { get; }

        public Command PizzaCommand { get; }

        public Command FinanCommand { get; }

        public GraphicsViewModel()
        {
            BarrasCommand = new Command(async () => await ExecuteLoadBarrasCommand());
            PizzaCommand = new Command(async () => await ExecuteLoadPizzaCommand());
            FinanCommand = new Command(async () => await ExecuteLoadFinanCommand());
        }
        
        public Graphics_Data Barras { get; set; }

        public float Pizza { get; set; }

        public double fin = 0;

        public async Task ExecuteLoadBarrasCommand()
        {
            IsBusy = true;
            
            try
            {
                int min = 0;
                int max = 0;
                
                Barras = new Graphics_Data();
                
                var items = await Data_Graphics_Store.GetItemAsync("proto");
                
                foreach (var item in (items as Graph_aux).aux)
                {
                    min += item.min;
                    max += item.max;
                }

                Barras.max = max;
                Barras.min = min;

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

        public async Task ExecuteLoadPizzaCommand()
        {
            IsBusy = true;

            try
            {
                Pizza = 0;
                int min = 0;
                int max = 0;
                int aux_min = 0;
                int aux_max = 0;
                int hours = 0;

                var items = await Data_Graphics_Eficien_Store.GetItemAsync("proto");

                foreach (var item in items.gra_sec)
                {
                    min = 0;
                    max = 0;

                    foreach (var i in item.gra_data)
                    {
                        min += i.min;
                        max += i.max;
                    }
                    aux_min += min * item.min_intensity;
                    aux_max += max * item.max_intensity;
                    hours += min + max;
                }

                Pizza = (aux_min + aux_max) / hours;


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

        public async Task ExecuteLoadFinanCommand()
        {
            IsBusy = true;

            int potencia = 0;

            fin = 0;

            try
            {
                var items = await Data_Graphics_Finan_Store.GetItemAsync("proto");

                foreach (var item in items.power)
                {
                    foreach (var i in item.values)
                    {
                        potencia += i;
                    }
                }

                fin = potencia;
                fin /= 3600;
                fin *= items.kwh_cost;


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

        public void OnAppearing()
        {
            IsBusy = true;
        }

    }
}
