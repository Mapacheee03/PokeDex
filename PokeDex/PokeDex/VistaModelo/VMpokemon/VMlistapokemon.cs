using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using PokeDex.Modelo;
using PokeDex.Vistas;
using PokeDex.Vistas.Pokemon;
using PokeDex.Datos;
using System.Collections.ObjectModel;


namespace PokeDex.VistaModelo.VMpokemon
{
    public class VMlistapokemon : BaseViewModel
    {
        #region VARIABLES
        String _Texto;
        ObservableCollection<Mpokemon> _Listapokemon;
        #endregion

        #region CONSTRUCTOR
        public VMlistapokemon(INavigation navigation)
        {
            Navigation = navigation;
            Mostrarpokemon();
        }

        #endregion



        #region OBJETOS

        public ObservableCollection<Mpokemon> Listapokemon
        {
            get { return _Listapokemon; }
            set
            {
                SetValue(ref _Listapokemon, value);
                OnpropertyChanged();

            }

        }
        #endregion

        #region PROCESOS
        public async Task Mostrarpokemon()
        {
            var function = new Dpokemon();
            Listapokemon = await function.MostrarPokemones();
        }
        public async Task iraregistro()
        {
            await Navigation.PushAsync(new Registrarpokemon());
        }
        public void ProcesoSimple()
        {

        }
        #endregion

        #region COMANDOS

        public ICommand iraregistrocommand => new Command(async () => await iraregistro());
        public ICommand ProcesoSimcommand => new Command(ProcesoSimple);
        #endregion
    }
}
