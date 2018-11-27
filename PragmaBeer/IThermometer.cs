using System;
using System.Collections.Generic;
using System.Text;

namespace PragmaBeer
{
    public interface IThermometer
    {
        int Id { get; set; }
        decimal Temperature { get; set; }
    }
}
