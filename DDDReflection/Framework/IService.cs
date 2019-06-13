using System;
using System.Collections.Generic;
using System.Text;

namespace Framework
{
    public interface IService
    {
        object Handle(object parameters);
    }
}