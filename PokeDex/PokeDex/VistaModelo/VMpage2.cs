using PokeDex.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PokeDex.VistaModelo
{
    class VMpage2 : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        public List<Musuario> listausuarios { get; set; }
        #endregion
        #region CONSTRUCTOR
        public VMpage2(INavigation navigation)
        {
            Navigation = navigation;
            MostrarUsuarios();
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
        public void MostrarUsuarios()
        {
            listausuarios = new List<Musuario>
            {
                new Musuario
                {
                    Nombre = "Orlando",
                    Imagen = "https://thumbs.dreamstime.com/b/juego-de-mapaches-sentado-lindo-creativo-logo-mascota-dibujos-animados-kawaii-dise%C3%B1o-253718662.jpg"
                },
                new Musuario
                {
                    Nombre = "Eloy",
                    Imagen = "https://img.freepik.com/vector-gratis/ejemplo-lindo-icono-vector-historieta-zanahoria-mordedura-conejo-concepto-icono-naturaleza-animal-plano-aislado_138676-7366.jpg?w=2000"
                },
                new Musuario
                {
                    Nombre = "Eduardo",
                    Imagen = "https://img.pikbest.com/origin/09/01/20/82zpIkbEsTmQ8.png!w700wp"
                }
            };
        }
        public async Task Alerta(Musuario parametros)
        {
            await DisplayAlert("Titulo", parametros.Nombre, "Ok");
        }
        #endregion
        #region COMANDOS
        public ICommand VolverCommand => new Command(async () => await Volver());
        //public ICommand ProcesoSimpCommand => new Command(ProcesoSimple);
        public ICommand Alertacommand => new Command<Musuario>(async (p) => await Alerta(p));
        #endregion
    }
}
