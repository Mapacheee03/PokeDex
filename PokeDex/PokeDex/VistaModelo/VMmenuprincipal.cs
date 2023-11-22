using PokeDex.Modelo;
using PokeDex.Vistas;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PokeDex.VistaModelo
{
    class VMmenuprincipal : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        public List<Mmenuprincipal> listapaginas { get; set; }
        #endregion
        #region CONSTRUCTOR
        public VMmenuprincipal(INavigation navigation)
        {
            Navigation = navigation;
            MostrarPaginas();
        }
        #endregion
        #region OBJETOS
        public string Texto
        {
            get { return _Texto; }
            set { SetValue(ref _Texto, value); }
        }
        #endregion
        #region PROCESOS
        public async Task Volver()
        {
            await Navigation.PopAsync();
        }
        public void MostrarPaginas()
        {
            listapaginas = new List<Mmenuprincipal>
            {
                new Mmenuprincipal
                {
                    Pagina = "Entry, datepicker, picker, label, navegavion",
                    Icono = "https://assets.pokemon.com/assets/cms2/img/pokedex/full/001.png"
                },
                new Mmenuprincipal
                {
                    Pagina = "CollectionView sin enlace a Base de  datos",
                    Icono = "https://assets.pokemon.com/assets/cms2/img/pokedex/full/007.png"
                },
                new Mmenuprincipal
                {
                    Pagina = "Crud pokemon",
                    Icono = "https://images.wikidexcdn.net/mwuploads/wikidex/5/56/latest/20200307023245/Charmander.png"
                }
            };
        }
        public async Task Navegar(Mmenuprincipal parametros)
        {
            string pagina;
            pagina = parametros.Pagina;
            if (pagina.Contains("Entry, datepicker"))
            {
                await Navigation.PushAsync(new Page1());
            }
            if (pagina.Contains("CollectionView sin enlace"))
            {
                await Navigation.PushAsync(new Page2());
            }
            if (pagina.Contains("Crud pokemon"))
            {
                await Navigation.PushAsync(new Crudpokemon());
            }
        }
        #endregion
        #region COMANDOS
        //public ICommand VolverCommand => new Command(async () => await Volver());
        //public ICommand ProcesoSimpCommand => new Command(ProcesoSimple);
        public ICommand Navegarcommand => new Command<Mmenuprincipal>(async (p) => await Navegar(p));
        #endregion
    }
}
