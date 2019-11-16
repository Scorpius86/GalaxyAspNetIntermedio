using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.MVC.Filter.Exceptions
{
    public class DomainException:Exception
    {
        public DomainException(string message)
       : base(message)
        {
        }
    }
}
