using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRGA_GUIAS
{
    internal class TransaccionLor
    {
        //esta clase es para mostrarr en la grilla
        public long Transaccionid { get; set; }
        public string? Matriculacamion { get; set; }   //el simbolo ese de ? es para que acepte nulos....
        public long Cargaid { get; set; }
        public List<Producto> Productos { get; set; }=new List<Producto>(); 
        public double Totalkilos { get; set; }
               
    }
    }
