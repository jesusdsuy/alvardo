using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRGA_GUIAS
{
    internal class Camion
    {
        public int Id { get; set; } 
        public string? Matricula { get; set; }    
        public int NroHabilitacion { get; set; }
        public override string ToString()
        {
            return Matricula;
        }

    }
}
