using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using PokeDex.Modelo;
using PokeDex.Vistas;
using PokeDex.Datos;


namespace PokeDex.VistaModelo.VMpokemon
{
    public class VMregistropokemon : BaseViewModel
    {
        #region VARIABLES
        string _Txtcolorfondo;
        string _Txtcolorpoder;
        string _Txtnombre;
        string _Txtnro;
        string _Txtpoder;
        string _Txticono;

        #endregion

        #region CONSTRUCTOR
        public VMregistropokemon(INavigation navigation)
        {
            Navigation = navigation;
        }

        #endregion



        #region OBJETOS

        public String Txtcolorfondo
        {
            get { return _Txtcolorfondo; }
            set { SetValue(ref _Txtcolorfondo, value); }
        }
        public String Txtcolorpoder
        {
            get { return _Txtcolorpoder; }
            set { SetValue(ref _Txtcolorpoder, value); }
        }
        public String Txtnombre
        {
            get { return _Txtnombre; }
            set { SetValue(ref _Txtnombre, value); }
        }
        public String Txtnro
        {
            get { return _Txtnro; }
            set { SetValue(ref _Txtnro, value); }
        }
        public String Txtpoder
        {
            get { return _Txtpoder; }
            set { SetValue(ref _Txtpoder, value); }
        }
        public String Txticono
        {
            get { return _Txticono; }
            set { SetValue(ref _Txticono, value); }
        }

        #endregion

        #region PROCESOS

        public async Task Insertar()
        {
            var funcion = new Dpokemon();
            var parametros = new Mpokemon();
            parametros.Colorfondo = Txtcolorfondo;
            parametros.ColorPoder = Txtcolorpoder;
            parametros.Icono = Txticono;
            parametros.Nombre = Txtnombre;
            parametros.NroOrden = Txtnro;
            parametros.Poder = Txtpoder;


            await funcion.Insertarpokemon(parametros);
            await volver();
        }
        public async Task volver()
        {
            await Navigation.PopAsync();

        }
        public void ProcesoSimple()
        {

        }
        #endregion

        #region COMANDOS
        public ICommand InsertarCommand => new Command(async () => await Insertar());
        public ICommand volvercommand => new Command(async () => await volver());
        public ICommand ProcesoSimcommand => new Command(ProcesoSimple);
        #endregion
    }
}