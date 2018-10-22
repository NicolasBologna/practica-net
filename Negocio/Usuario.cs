using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bologna.Negocio
{
    public class Usuario
    {
        public static List<Entidades.Usuario> RecuperarTodos()
        {
            Datos.Usuario usuarioAdapter = new Datos.Usuario();
            return usuarioAdapter.RecuperarTodos();
        }

        public static void Agregar(Entidades.Usuario usuario)
        {
            Datos.Usuario usuarioAdapter = new Datos.Usuario();
            usuarioAdapter.Agregar(usuario);
        }

        public static bool Validar(string usr, string clave)
        {
            Datos.Usuario usuarioAdapter = new Datos.Usuario();
            return usuarioAdapter.Ingresar(usr,clave);
        }
        public static Entidades.Usuario Recuperar(string usr)
        {
            Datos.Usuario usuarioAdapter = new Datos.Usuario();
            return usuarioAdapter.Recuperar(usr);
        }
        public static void Eliminar(int usr)
        {
            Datos.Usuario usuarioAdapter = new Datos.Usuario();
            usuarioAdapter.Eliminar(usr);
        }

    }
}
