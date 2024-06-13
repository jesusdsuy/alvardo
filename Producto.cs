using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRGA_GUIAS
{
    internal class Producto
    {
        public int Productoid { get; set; }  /// <summary>es el id del producto dentro de la carga
        public string CodigoLor { get; set; }
        public string Nombrelor { get; set; } 
        public string Codigo { get; set; } 
        public string Nombre { get; set; } 
        public double Peso { get; set; }   

    }
}
