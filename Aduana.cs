using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRGA_GUIAS
{
    internal class Aduana
    {
       public string Aduananombre { get; set; }   
       public int Aduanacodigo { get; set; }
        public override string ToString()
        {
            return Aduananombre;
        }

    }
}
