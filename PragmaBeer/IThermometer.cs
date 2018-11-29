using System;
using System.Collections.Generic;
using System.Text;

namespace PragmaBeer
{
    public interface IThermometer
    {
        string Guid { get;  }
        double Temperature();
    }
}
