using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.PortableExecutable;

namespace ConsoleApp1.Handlers
{
    public class ADO_ProductoVendido
    {
       public List<ProductoVendido> TraerProductoVendido(int idUsuario)
       {
            var listaProductoVendido = new List<ProductoVendido>();
            string connectionString = "Server = DESKTOP-CD3K2IK\\JHOSMAN; Database = SistemaGestion; Trusted_Connection = True;";

            using (SqlConnection conect = new SqlConnection(connectionString))
            {
                using (SqlCommand comando = new SqlCommand(" select * from ProductoVendido pv inner join Producto p on pv.IdProducto = p.Id where p.IdUsuario = @idusuario;", conect))
                {
                    var parametro = new SqlParameter();
                    parametro.ParameterName = "idusuario";
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
                                var productovendido = new ProductoVendido();
                                productovendido.Id = Convert.ToInt32(dr["Id"]);
                                productovendido.Stock = Convert.ToInt32(dr["Stock"]);
                                productovendido.IdProducto = Convert.ToInt32(dr["IdProducto"]);
                                productovendido.IdVenta = Convert.ToInt32(dr["IdVenta"]);

                                listaProductoVendido.Add(productovendido);
                            }
                            Console.WriteLine("-----ProductosVendidoporUsuario----");
                            foreach (var productovendido in listaProductoVendido)
                            {
                               
                                Console.WriteLine("Id = " + productovendido.Id);                             
                                Console.WriteLine("Stock = " + productovendido.Stock);
                                Console.WriteLine("IdProducto = " + productovendido.IdProducto);
                                Console.WriteLine("IdVenta = " + productovendido.IdVenta);
                                Console.WriteLine("\n");
                            }
                        }
                        conect.Close();
                    }

                }
            }
            return listaProductoVendido;
       }
    }
}
