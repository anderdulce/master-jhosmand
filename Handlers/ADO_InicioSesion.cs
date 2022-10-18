using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Handlers
{
    public class ADO_InicioSesion
    {
        public Usuario validarUsuario(string nombreUsuario, string password)
        {
            var usuario = new Usuario();
            SqlConnectionStringBuilder conecctionbuilder = new SqlConnectionStringBuilder();
            conecctionbuilder.DataSource = "DESKTOP-CD3K2IK\\JHOSMAN";
            conecctionbuilder.InitialCatalog = "SistemaGestion";
            conecctionbuilder.IntegratedSecurity = true;

            var cs = conecctionbuilder.ConnectionString;
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "select * from Usuario where NombreUsuario = @user and Contraseña = @pass;";
                cmd.Parameters.Add(new SqlParameter("@user", nombreUsuario));
                cmd.Parameters.Add(new SqlParameter("@pass", password));
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    usuario.Id = Convert.ToInt32(reader.GetValue(0));
                    usuario.Nombre = reader.GetValue(1).ToString();
                    usuario.Apellido = reader.GetValue(2).ToString();
                    usuario.NombreUsuario = reader.GetValue(3).ToString();
                    usuario.Contraseña = reader.GetValue(4).ToString();
                    usuario.Mail = reader.GetValue(5).ToString();
                }
                Console.WriteLine("------Inicio de Sesion-----");
                if (usuario.NombreUsuario == nombreUsuario && usuario.Contraseña == password)
                {
                    Console.WriteLine(" El NombreUsuario o contraseña es correcto");
                    Console.WriteLine("NombreUsuario = " + usuario.NombreUsuario);
                    Console.WriteLine("Contraseña = " + usuario.Contraseña);
                    Console.WriteLine("Id = " + usuario.Id);
                    Console.WriteLine("Nombre = " + usuario.Nombre);
                    Console.WriteLine("Apellido = " + usuario.Apellido);
                    Console.WriteLine("Mail = " + usuario.Mail);
                    Console.WriteLine("\n");
                }
                else
                {
                    Usuario vacio = new Usuario();
                    Console.WriteLine(" El NombreUsuario o contraseña es incorrecta");
                    Console.WriteLine("NombreUsuario = " + vacio.NombreUsuario);
                    Console.WriteLine("Id = " + vacio.Id);
                    Console.WriteLine("Nombre = " + vacio.Nombre);
                    Console.WriteLine("Apellido = " + vacio.Apellido);
                    Console.WriteLine("Contraseña = " + vacio.Contraseña);
                    Console.WriteLine("Mail = " + vacio.Mail);
                    Console.WriteLine("\n");
                }

                reader.Close();
                connection.Close();
            }
            return usuario;
        }
    }
}
