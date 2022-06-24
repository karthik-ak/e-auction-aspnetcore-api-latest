using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAuction.Bid.WebApi.Exceptions
{
    public class BidExpiredException:ApplicationException
    {
        public BidExpiredException()
        {

        }
        public BidExpiredException(string message):base(message)
        {
            
        }
    }
}
