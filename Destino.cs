using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRGA_GUIAS
{
    internal class Destino
    {
        public int Compradorid { get; set; }    
        public string? Nombredestino { get; set; }    
        public int Tipodestino { get; set; }    
        public int Nrohabilitacion      { get; set; }
        public int Depositoid { get; set; } 
        public long Rutreceptor { get; set; }

        public override string ToString()
        {
            return Nombredestino;
        }

    }
}
