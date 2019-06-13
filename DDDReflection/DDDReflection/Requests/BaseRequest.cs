using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDDReflection.Requests
{
    public class BaseRequest
    {
        public object Parameters { get; set; }

        public string Route { get; set; }
    }
}