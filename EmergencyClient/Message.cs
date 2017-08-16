using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyClient
{
    public class Message
    {
        public string messageId;
        public string message;
        public string date;
        public string longitude;
        public string latitude;

        public Message(string newMessageId, string newMessage, string newDate)
        {
            messageId = newMessageId;
            message = newMessage;
            date = newDate;
        }

        public Message()
        {

        }
    }
}
