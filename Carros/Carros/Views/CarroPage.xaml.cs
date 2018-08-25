using Carros.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Carros.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarroPage : ContentPage
    {
        private CarroViewModel _vm;
        public CarroViewModel ViewModel
        {
            get
            {
                if (_vm == null)
                    _vm = new CarroViewModel();

                BindingContext = _vm;

                return (BindingContext as CarroViewModel);
            }
        }

        public CarroPage()
        {
            InitializeComponent();
        }
    }
}