using System;
using System.Collections.Generic;
using System.Text;

namespace Renting.Master.Core.Messages
{
    public class GenericMessage<T> where T: class
    {
        public int MessageType { set; get; }
        public T MessageBody { get; set; }
    }
}
