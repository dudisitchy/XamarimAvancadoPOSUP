using Carros.Models;
using Carros.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Carros.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public ObservableCollection<Carro> ListCarros { get; set; } = new ObservableCollection<Carro>();
        
        public MainViewModel() : base("Carros")
        {
            RefreshCommand = new Command(async () => await LoadData(), () => !IsBusy);
            ItemClickCommand = new Command<Carro>(async (item) => await ItemClickCommandExecuteAsync(item));
        }

        public override async Task Initialize(object parameters = null) => await LoadData();

        async Task ItemClickCommandExecuteAsync(Carro carro)
        {
            if (IsBusy)
                return;

            Exception error = null;

            try
            {
                IsBusy = true;
                var carroPage = new CarroPage();
                await carroPage.ViewModel.Initialize(carro);

                await Navigation.PushAsync(carroPage);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex);
                error = ex;
            }
            finally
            {
                IsBusy = false;
            }

            if (error != null)
                await ShowAlertAsync("Error!", error.Message, "OK");
        }

        async Task LoadData()
        {
            if (IsBusy)
                return;

            Exception error = null;

            try
            {
                IsBusy = true;

                var carros = await Api.GetAllCarrosAsync();

                ListCarros.Clear();
                foreach (var carro in carros)
                    ListCarros.Add(carro);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex);
                error = ex;
            }
            finally
            {
                IsBusy = false;
            }

            if (error != null)
                await ShowAlertAsync("Error!", error.Message, "OK");
        }

    }
}
