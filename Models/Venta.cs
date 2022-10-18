using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public class Venta
    {
        public int Id { get; set; }
        public string Comentarios { get; set; }
        public int IdUsuario { get; set; }


        public Venta()
        {
            Id = 0;
            Comentarios = String.Empty;
            IdUsuario = 0;
        }
    }
}
