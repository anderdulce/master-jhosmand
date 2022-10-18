using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Handlers
{
    public class ADO_Venta
    {
        public List<Venta> TraerVenta(int idUsuario)
        {
            var listaVenta = new List<Venta>();
            string connectionString = "Server = DESKTOP-CD3K2IK\\JHOSMAN; Database = SistemaGestion; Trusted_Connection = True;";

            using (SqlConnection conect = new SqlConnection(connectionString))
            {
                using (SqlCommand comando = new SqlCommand("select * from Venta where IdUsuario = @user;", conect))
                {
                    var parametro = new SqlParameter();
                    parametro.ParameterName = "user";
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
                                var venta = new Venta();
                                venta.Id = Convert.ToInt32(dr["Id"]);
                                venta.Comentarios = dr["Comentarios"].ToString();
                                venta.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);

                                listaVenta.Add(venta);
                            }
                            Console.WriteLine("-----VentaporUsuario----");
                            foreach (var venta in listaVenta)
                            {
                                Console.WriteLine("Id = " + venta.Id);
                                Console.WriteLine("Descripciones =  " + venta.Comentarios);
                                Console.WriteLine("IdUsuario = " + venta.IdUsuario);

                                Console.WriteLine("\n");
                            }
                        }
                    }
                    conect.Close();

                }
            }
            return listaVenta;
        }
        
    }
}
