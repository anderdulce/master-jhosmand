using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Collections.Specialized.BitVector32;

namespace ConsoleApp1.Handlers
{
    public class ADO_Usuario
    {
        public Usuario traerUsuario(string nombreUsuario)
        {
            var name = new Usuario();
            SqlConnectionStringBuilder conecctionbuilder = new SqlConnectionStringBuilder();
            conecctionbuilder.DataSource = "DESKTOP-CD3K2IK\\JHOSMAN";
            conecctionbuilder.InitialCatalog = "SistemaGestion";
            conecctionbuilder.IntegratedSecurity = true;
            var cs = conecctionbuilder.ConnectionString;
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "select * from Usuario where NombreUsuario = @user;";
                cmd.Parameters.Add(new SqlParameter("@user", nombreUsuario));
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    name.Id = Convert.ToInt32(reader.GetValue(0));
                    name.Nombre = reader.GetValue(1).ToString();
                    name.Apellido = reader.GetValue(2).ToString();
                    name.NombreUsuario = reader.GetValue(3).ToString();
                    name.Contraseña = reader.GetValue(4).ToString();
                    name.Mail = reader.GetValue(5).ToString();
                }
                Console.WriteLine("------TraerUsuario-----");
                if (name.NombreUsuario == nombreUsuario)
                {

                    Console.WriteLine("NombreUsuario = " + name.NombreUsuario);
                    Console.WriteLine("Id = " + name.Id);
                    Console.WriteLine("Nombre = " + name.Nombre);
                    Console.WriteLine("Apellido = " + name.Apellido);
                    Console.WriteLine("Contraseña = " + name.Contraseña);
                    Console.WriteLine("Mail = " + name.Mail);
                    Console.WriteLine("\n");
                }
                else
                {
                    Console.WriteLine(" El NombreUsuario es incorrecto");
                }
                reader.Close();
                connection.Close();
            }
            return name;
        }
    }
}
       