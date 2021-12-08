using CAPExample.UI.Events;
using DotNetCore.CAP.Messages;
using DotNetCore.CAP.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CAPExample.UI
{
    public class CAPSerializer :ISerializer
    {
        public string Serialize(Message message)
        {
            throw new NotImplementedException();
        }

        Task<TransportMessage> ISerializer.SerializeAsync(Message message)
        {
            throw new NotImplementedException();
        }

        public Message Deserialize(string json)
        {
            Message message = JsonSerializer.Deserialize<Message>(json);

            switch (message.Headers["cap-msg-type"])
            {
                case "PersonCreated":
                    message.Value = message.Value as PersonCreated;
                    return message; 
                default:
                    return null;    
            }

           
        }

        Task<Message> ISerializer.DeserializeAsync(TransportMessage transportMessage, Type valueType)
        {
            throw new NotImplementedException();
        }

        public object Deserialize(object value, Type valueType)
        {
            throw new NotImplementedException();
        }

        public bool IsJsonType(object jsonObject)
        {
            throw new NotImplementedException();
        }
    }
}
