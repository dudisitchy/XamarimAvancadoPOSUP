using Carros.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Carros.ViewModels
{
    public class CarroViewModel : BaseViewModel
    {        
        private Carro _carro = new Carro();
        public Carro Carro
        {
            get
            {
                return _carro;
            }
            set
            {
                _carro = value; OnPropertyChanged();
            }
        }

        public CarroViewModel() : base("")
        {
        }

        public override async Task Initialize(object parameters)
        {
            Carro = parameters as Carro;
            Title = Carro.Tipo;
            await base.Initialize(null);
        }
    }
}
