using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.MVC.Filter.Exceptions
{
    public class NoCreditException:DomainException
    {
        public NoCreditException():base("Ud. No tiene saldo en su cuenta")
        {

        }
    }
}
