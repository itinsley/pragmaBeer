using System.Collections.Generic;
using System;
using System.Text;

namespace PragmaBeer
{
    public class ContainerType
    {
        public ContainerType(int id, double tempMin, double tempMax, string description)
        {
            Id = id;
            TempMin = tempMin;
            TempMax = tempMax;
            Description = description;
        }

        public int Id { get; }
        public double TempMin { get; }
        public double TempMax { get; }
        public string Description { get; }
    }
}
