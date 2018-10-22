using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Bologna.Datos
{
    public class Usuario : Base
    {
        public List<Entidades.Usuario> RecuperarTodos()
        {
            List<Entidades.Usuario> lista = new List<Entidades.Usuario>();
            SqlCon.Open();
            SqlCommand cmdUsuario = new SqlCommand("Select * from Usuarios", SqlCon);
            SqlDataReader drUsuario = cmdUsuario.ExecuteReader();
            while (drUsuario.Read())
            {
                Entidades.Usuario usr = new Entidades.Usuario();

                usr.Clave = (string)drUsuario["clave"];
                usr.Email = (string)drUsuario["email"];
                usr.Id = (int)drUsuario["id_usuario"];
                usr.NombreUsuario = (string)drUsuario["nombre_usuario"];
                usr.TipoUsuario = (int)drUsuario["tipo_usuario"];
                usr.UltimoIngreso = (DateTime)drUsuario["ultimo_ingreso"];

                lista.Add(usr);
            }
            SqlCon.Close();
            return lista;
        }

        public void Agregar(Entidades.Usuario usuarioNuevo)
        {
            SqlCon.Open();
            SqlCommand cmdInsert = new SqlCommand("INSERT INTO Usuarios(clave,email,tipo_usuario,ultimo_ingreso,nombre_usuario) " +
                "VALUES(@clave,@email,@tipoUsuario,@ultimoIngreso,@nombreUsuario)", SqlCon);
            cmdInsert.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuarioNuevo.Clave;
            cmdInsert.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuarioNuevo.Email;
            cmdInsert.Parameters.Add("@tipoUsuario", SqlDbType.Int).Value = usuarioNuevo.TipoUsuario;
            cmdInsert.Parameters.Add("@ultimoIngreso", SqlDbType.VarChar, 50).Value = DateTime.Today;
            cmdInsert.Parameters.Add("@nombreUsuario", SqlDbType.VarChar, 50).Value = usuarioNuevo.NombreUsuario;
            cmdInsert.ExecuteNonQuery();
            SqlCon.Close();
        }

        public bool Ingresar(string usr, string pass)
        {
            SqlCon.Open();
            SqlCommand cmdUsuario = new SqlCommand("Select * from Usuarios WHERE @usr=nombre_usuario AND @pass=clave", SqlCon);
            cmdUsuario.Parameters.Add("@pass", SqlDbType.VarChar, 50).Value = pass;
            cmdUsuario.Parameters.Add("@usr", SqlDbType.VarChar, 50).Value =usr;
            SqlDataReader drUsuario = cmdUsuario.ExecuteReader();
            return drUsuario.Read();
        }

        public Entidades.Usuario Recuperar(string nombre)
        {
            Entidades.Usuario usr = new Entidades.Usuario();
            SqlCon.Open();
            SqlCommand cmdUsuario = new SqlCommand("Select * From Usuarios WHERE @nombre_usuario = nombre_usuario", SqlCon);
            cmdUsuario.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = nombre;
            SqlDataReader drUsuario = cmdUsuario.ExecuteReader();
            drUsuario.Read();
            
            usr.Clave = (string)drUsuario["clave"];
            usr.Email = (string)drUsuario["Email"];
            usr.NombreUsuario = (string)drUsuario["Nombre_Usuario"];
            usr.TipoUsuario = (int)drUsuario["Tipo_Usuario"];
            usr.UltimoIngreso = (DateTime)drUsuario["Ultimo_Ingreso"];
            drUsuario.Close();
            SqlCon.Close();
            return usr;
        }

        public void Eliminar(int id)
        {
            SqlCon.Open();
            SqlCommand cmdDelete = new SqlCommand("Delete Usuarios Where @id = id_usuario", SqlCon);
            cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cmdDelete.ExecuteNonQuery();
            SqlCon.Close();
        }
    }
}
