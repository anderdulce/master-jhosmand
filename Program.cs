using ConsoleApp1;
using ConsoleApp1.Models;
using System.Data.SqlClient;

using ConsoleApp1.Handlers;


//Traer Usuario:  
ADO_Usuario dato = new ADO_Usuario();
dato.traerUsuario("tcasazza");


//Traer Producto
ADO_Producto pro = new ADO_Producto();
pro.TraerProducto(1);


//Traer Producto Vendido
ADO_ProductoVendido provendido = new ADO_ProductoVendido();
provendido.TraerProductoVendido(1);


//Traer Ventas

ADO_Venta ven= new ADO_Venta();
ven.TraerVenta(1) ;

// Inicio de sesion (coincide)
ADO_InicioSesion userDatos = new ADO_InicioSesion();
userDatos.validarUsuario("eperez", "SoyErnestoPerez");

// Inicio de sesion (no coincide)
ADO_InicioSesion noDatos = new ADO_InicioSesion();
noDatos.validarUsuario("eperez", "ffff");







/*
class Program
{

    static void Main(string[] args)
    {
        var listarUsuario = new List<Usuario>();
        var listarProducto = new List<Producto>();
        var listarVenta = new List<Venta>();
        var listaSesion = new List<Usuario>();


        //Traer Usuario

        Console.WriteLine("Ingrese el nombreusuario que desea ver ");
        string name = Console.ReadLine();

        SqlConnectionStringBuilder conecctionbuilder = new ();
        conecctionbuilder.DataSource = "DESKTOP-CD3K2IK\\JHOSMAN";
        conecctionbuilder.InitialCatalog = "SistemaGestion";
        conecctionbuilder.IntegratedSecurity = true;

        var cs = conecctionbuilder.ConnectionString;

        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "select * from Usuario where NombreUsuario = @user;";
            cmd.Parameters.Add(new SqlParameter("@user", name));
            var reader =  cmd.ExecuteReader();

            while (reader.Read())
            {
                Usuario user = new Usuario();
                user.Id = Convert.ToInt32(reader.GetValue(0));
                user.Nombre = reader.GetValue(1).ToString();
                user.Apellido = reader.GetValue(2).ToString();
                user.NombreUsuario = reader.GetValue(3).ToString();
                user.Contraseña = reader.GetValue(4).ToString();
                user.Mail = reader.GetValue(5).ToString();

                listarUsuario.Add(user);
            }

            Console.WriteLine("-----Usuario-----");
            foreach (var user in listarUsuario)
            {
                    Console.WriteLine("NombreUsuario = " + user.NombreUsuario);
                    Console.WriteLine("Id = " + user.Id);
                    Console.WriteLine("Nombre = " + user.Nombre);
                    Console.WriteLine("Apellido = " + user.Apellido);
                    Console.WriteLine("Contraseña = " + user.Contraseña);
                    Console.WriteLine("Mail = " + user.Mail);
                    Console.WriteLine("-------------------");
                
            }
            reader.Close();


            //Traer Producto

            Console.WriteLine("Ingrese el id de usuario para ver los productos cargados por el usuario ");
            string idusu = Console.ReadLine();

            SqlCommand cmd2 = connection.CreateCommand();
            cmd.CommandText = "select * from Producto where IdUsuario = @IdUsuario;";
            cmd.Parameters.Add(new SqlParameter("@IdUsuario", idusu));
            var reader2 = cmd.ExecuteReader();
            while (reader2.Read())
            {
                var producto = new Producto();

                producto.Id = Convert.ToInt32(reader2.GetValue(0));
                producto.Descripciones = reader2.GetValue(1).ToString();
                producto.Costo = Convert.ToDouble(reader2.GetValue(2));
                producto.PrecioVenta = Convert.ToDouble(reader2.GetValue(3));
                producto.Stock = Convert.ToInt32(reader2.GetValue(4));
                producto.IdUsuario = Convert.ToInt32(reader2.GetValue(5));

                listarProducto.Add(producto);
            }
            Console.WriteLine("-----ProductosporUsuario----");
            foreach (var producto in listarProducto)
            {
                Console.WriteLine("Id = " + producto.Id);
                Console.WriteLine("Descripciones = " + producto.Descripciones);
                Console.WriteLine("Costo = " + producto.Costo);
                Console.WriteLine("PrecioVenta = " + producto.PrecioVenta);
                Console.WriteLine("Stock = " + producto.Stock);
                Console.WriteLine("IdUsuario = " + producto.IdUsuario);

                Console.WriteLine("-------------------");
            }
            reader2.Close();



            //Traer Venta


            Console.WriteLine("Ingrese el IdUsuario para ver las ventas realizadas por el usuario");
            string usuventa = Console.ReadLine();

            SqlCommand cmd4 = connection.CreateCommand();
            cmd4.CommandText = "select * from Venta where IdUsuario = @IdUsuario;";
            cmd4.Parameters.Add(new SqlParameter("@IdUsuario", usuventa));
            var reader4 = cmd4.ExecuteReader();
            while (reader4.Read())
            {
                var venta = new Venta();

                venta.Id = Convert.ToInt32(reader4.GetValue(0)); 
                venta.Comentarios = reader4.GetValue(1).ToString();
                venta.IdUsuario = Convert.ToInt32(reader4.GetValue(2));

                listarVenta.Add(venta);
            }
            Console.WriteLine("-----VentasporUsuario----");
            foreach (var venta in listarVenta)
            {
                Console.WriteLine("Id = " + venta.Id);
                Console.WriteLine("Comentarios = " + venta.Comentarios);
                Console.WriteLine("IdUsuario = " + venta.IdUsuario);

                Console.WriteLine("-------------------");
            }
            reader4.Close();


            //Inicio de Sesion
            Console.WriteLine("Ingrese Nombre de usuario");
            string nombreusu = Console.ReadLine();
            Console.WriteLine("Ingrese Contraseña");
            string usucont = Console.ReadLine();

            SqlCommand cmd5 = connection.CreateCommand();
            cmd5.CommandText = "select * from Usuario where NombreUsuario = @user and Contraseña = @pass;";
            cmd5.Parameters.Add(new SqlParameter("@user", nombreusu));
            cmd5.Parameters.Add(new SqlParameter("@pass", usucont));
            var reader5 = cmd5.ExecuteReader();

            while (reader5.Read())
            {
                Usuario sesion = new Usuario();
                sesion.Id = Convert.ToInt32(reader5.GetValue(0));
                sesion.Nombre = reader5.GetValue(1).ToString();
                sesion.Apellido = reader5.GetValue(2).ToString();
                sesion.NombreUsuario = reader5.GetValue(3).ToString();
                sesion.Contraseña = reader5.GetValue(4).ToString();
                sesion.Mail = reader5.GetValue(5).ToString();

                listaSesion.Add(sesion);
            }

            Console.WriteLine("-----Sesion-----");
            foreach (var sesion in listaSesion)
            {
                if (sesion.NombreUsuario == nombreusu && sesion.Contraseña ==usucont)
                {
                    Console.WriteLine("NombreUsuario = " + sesion.NombreUsuario);
                    Console.WriteLine("Id = " + sesion.Id);
                    Console.WriteLine("Nombre = " + sesion.Nombre);
                    Console.WriteLine("Apellido = " + sesion.Apellido);
                    Console.WriteLine("Contraseña = " + sesion.Contraseña);
                    Console.WriteLine("Mail = " + sesion.Mail);
                    Console.WriteLine("-------------------");
                }
                else
                {
                    Usuario vacio = new Usuario();
                    Console.WriteLine(" El NombreUsuario es incorrecto");
                    Console.WriteLine("NombreUsuario = " + vacio.NombreUsuario);
                    Console.WriteLine("Id = " + vacio.Id);
                    Console.WriteLine("Nombre = " + vacio.Nombre);
                    Console.WriteLine("Apellido = " + vacio.Apellido);
                    Console.WriteLine("Contraseña = " + vacio.Contraseña);
                    Console.WriteLine("Mail = " + vacio.Mail);
                }
            }
            reader.Close();

            connection.Close();
        }
    }
}
*/
