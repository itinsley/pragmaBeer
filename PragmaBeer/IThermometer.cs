using System;
using System.Collections.Generic;
using System.Text;

namespace PragmaBeer
{
    public interface IThermometer
    {
        int Id { get;  }
        double Temperature();
    }
}
