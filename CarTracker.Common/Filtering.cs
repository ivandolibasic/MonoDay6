using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTracker.Common
{
    public class Filtering
    {
        public Guid? Id { get; set; }
        public DateTime? DateMax { get; set; }
        public DateTime? DateMin { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int YearOfProduction { get; set; }

        public Filtering(DateTime? dateMax, DateTime? dateMin, string manufacturer, string model, int yearOfProduction)
        {
            DateMax = dateMax;
            DateMin = dateMin;
            Manufacturer = manufacturer;
            Model = model;
            YearOfProduction = yearOfProduction;
        }
    }
}