using System.Collections.Generic;
using System;
using System.Text;

namespace PragmaBeer
{
    public class ContainerType
    {
        public ContainerType(int id, decimal tempMin, decimal tempMax, string description)
        {
            Id = id;
            TempMin = tempMin;
            TempMax = tempMax;
            Description = description;
        }

        int Id { get; }
        decimal TempMin { get; }
        decimal TempMax { get; }
        string Description { get; }
    }
}
