using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;

namespace PokeDex.Conexion
{
    class Cconexion
    {
        public static FirebaseClient firebase = new FirebaseClient("https://mvvmogv-default-rtdb.firebaseio.com/");
    }
}
