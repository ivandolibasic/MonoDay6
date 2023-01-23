using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTracker.Model.Common
{
    public interface ICarModel
    {
        Guid Id { get; set; }
        string Manufacturer { get; set; }
        string Model { get; set; }
        int YearOfProduction { get; set; }
    }
}