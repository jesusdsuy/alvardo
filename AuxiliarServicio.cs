using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRGA_GUIAS
{
    internal class AuxiliarServicio
    {
        public static wsSRGATransaccionesSoapPortClient obtenerClienteWS()
        {
            var cliente = new ServiceReference1.wsSRGATransaccionesSoapPortClient();

            //le agrego el inspector para que modifique todos los mensajes
            cliente.Endpoint.EndpointBehaviors.Add(new SimpleEndpointBehavior());

            return cliente;
        }


    }
}
