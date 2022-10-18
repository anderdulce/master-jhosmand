using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Handlers
{
    public class ADO_Producto
    {
        public List<Producto> TraerProducto(int idUsuario)
        {
           
            var listaProducto = new List<Producto>();
            string connectionString = "Server = DESKTOP-CD3K2IK\\JHOSMAN; Database = SistemaGestion; Trusted_Connection = True;";

            using (SqlConnection conect = new SqlConnection(connectionString))
            {
                using (SqlCommand comando = new SqlCommand("select * from Producto where IdUsuario = @idUsuario;", conect))
                { 
                    var parametro = new SqlParameter();
                    parametro.ParameterName = "idUsuario";
                    parametro.SqlDbType = SqlDbType.BigInt;
                    parametro.Value = idUsuario;

                    comando.Parameters.Add(parametro);

                    conect.Open();
                    using (SqlDataReader dr = comando.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var producto = new Producto();
                                producto.Id = Convert.ToInt32(dr["Id"]);
                                producto.Descripciones = dr["Descripciones"].ToString();
                                producto.Costo = Convert.ToInt64(dr["Costo"]);
                                producto.PrecioVenta = Convert.ToInt64(dr["PrecioVenta"]);
                                producto.Stock = Convert.ToInt32(dr["Stock"]);
                                producto.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);

                                listaProducto.Add(producto);
                            }
                            Console.WriteLine("-----ProductosporUsuario----");
                            foreach (var producto in listaProducto)
                            {
                                Console.WriteLine("Id = " + producto.Id);
                                Console.WriteLine("Descripciones = " + producto.Descripciones);
                                Console.WriteLine("Costo = " + producto.Costo);
                                Console.WriteLine("PrecioVenta = " + producto.PrecioVenta);
                                Console.WriteLine("Stock = " + producto.Stock);
                                Console.WriteLine("IdUsuario = " + producto.IdUsuario);

                                Console.WriteLine("\n");
                            }
                        }
                    }
                    conect.Close();

                }
            }
            return listaProducto;
        }
    }
    
}
