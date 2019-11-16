using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.MVC.Filter.Exceptions
{
    public class YouHaveExceededTheMountException:DomainException
    {
        public YouHaveExceededTheMountException():base("Ha exedido el monto")
        {

        }
    }
}
