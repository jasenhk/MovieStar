using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStar.Data.DAL.Services
{
    public interface IMessenger
    {
        bool Send(Message message);
    }

    public class EmailMessenger : IMessenger
    {
        public bool Send(Message message)
        {
            throw new NotImplementedException();
        }
    }

    public class SmsMessenger : IMessenger
    {
        public bool Send(Message message)
        {
            throw new NotImplementedException();
        }
    }

    public class RyanOzawaMessenger : IMessenger
    {
        public bool Send(Message message)
        {
            throw new NotImplementedException();
        }
    }

}
