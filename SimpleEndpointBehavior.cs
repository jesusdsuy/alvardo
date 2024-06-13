using System;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace SRGA_GUIAS
{
    public class SimpleEndpointBehavior : IEndpointBehavior
    {
        public SimpleEndpointBehavior()
        {
        }

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
            //no es necesario
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.ClientMessageInspectors.Add(new SimpleMessageInspector());
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            //no es necesario
        }

        public void Validate(ServiceEndpoint endpoint)
        {
            //no es necesario
        }
    }
}

