using System;
using System.Net.Http;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace SRGA_GUIAS
{
    public class SimpleMessageInspector : IClientMessageInspector
    {
        public SimpleMessageInspector()
        {
        }

        public void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        {
            //no hago nada
        }

        public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, IClientChannel channel)
        {
            //aca le agrego los headers que necesito
            HttpRequestMessageProperty httpRequestMessage = new HttpRequestMessageProperty();
            httpRequestMessage.Headers.Add("Authorization", "OAuth 957fde91-2547-4754-afad-01e09b7650d4!670d3d38f121cc60dee3a39759efbb0f16634ce76caf913778a2e1f30794c73003cdf3d63e8f16");
            httpRequestMessage.Headers.Add("GENEXUS-AGENT", "SmartDevice Application");
            request.Properties.Add(HttpRequestMessageProperty.Name, httpRequestMessage);
           
            return null;
        }
                
    }
}

