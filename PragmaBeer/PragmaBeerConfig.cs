using System;
using System.Collections.Generic;
using System.Text;

namespace PragmaBeer
{
    
    public class PragmaBeerConfig
    {
        public PragmaBeerConfig()
        {
            ContainerTypes = new List<ContainerTypeConfig>();
        }

        public List<ContainerTypeConfig> ContainerTypes { get; set; }  
    }

    public class ContainerTypeConfig
    {
        public ContainerTypeConfig(int id, double tempMin,
            double tempMax, string description, string thermometerGuid)
        {
            Id = id;
            TempMin = tempMin;
            TempMax = tempMax;
            Description = description;
            ThermometerGuid = thermometerGuid;
        }

        public int Id { get; }
        public double TempMin { get; }
        public double TempMax { get; }
        public string Description { get; }
        public string ThermometerGuid { get; }
    }
}
