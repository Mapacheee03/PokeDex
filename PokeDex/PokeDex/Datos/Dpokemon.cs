using System;
using System.Collections.Generic;
using System.Text;
using PokeDex.Modelo;
using PokeDex.Conexion;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using Firebase.Database;



namespace PokeDex.Datos
{
    public class Dpokemon
    {
        public async Task Insertarpokemon(Mpokemon parametros)
        {
            await Cconexion.firebase
                .Child("Pokemon")
                .PostAsync(new Mpokemon()
                {

                    Colorfondo = parametros.Colorfondo,
                    ColorPoder = parametros.ColorPoder,
                    Icono = parametros.Icono,
                    Nombre = parametros.Nombre,
                    NroOrden = parametros.NroOrden,
                    Poder = parametros.Poder

                }
                );
        }
        public async Task<ObservableCollection<Mpokemon>> MostrarPokemones()
        {
            /* return (await Cconexion.firebase
                 .Child("Pokemon")
                 .OnceAsync<Mpokemon>())
                 .Select(item => new Mpokemon
                 {
                     Idpokemon=item.Key,
                     Nombre=item.Object.Nombre,
                     Colorfondo=item.Object.Colorfondo,
                     Colorpoder = item.Object.Colorpoder,
                     Icono = item.Object.Icono,
                     NroOrdenar = item.Object.NroOrdenar,
                     Poder = item.Object.Poder
                 }).ToList();*/
            var data = await Task.Run(() => Cconexion.firebase
                .Child("Pokemon")
                .AsObservable<Mpokemon>()
                .AsObservableCollection()
                );
            return data;


        }
    }
}
