using CarTracker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTracker.Common
{
    public class Sorting
    {
        public string OrderName { get; set; }
        public string OrderDirection { get; set; }

        public Sorting(string orderName, string orderDirection)
        {
            OrderName = orderName;
            OrderDirection = orderDirection;
        }



        //public IEnumerable<CarModel> ApplySort(IEnumerable<CarModel> cars)
        //{
        //    if (string.IsNullOrEmpty(OrderName))
        //    {
        //        return cars;
        //    }

        //    if (OrderDirection == "ASC")
        //    {
        //        switch (OrderName)
        //        {
        //            case "Manufacturer":
        //                return cars.OrderBy(c => c.Manufacturer);
        //            case "Model":
        //                return cars.OrderBy(c => c.Model);
        //            case "YearOfProduction":
        //                return cars.OrderBy(c => c.YearOfProduction);
        //            default:
        //                return cars;
        //        }
        //    }
        //    else
        //    {
        //        switch (OrderName)
        //        {
        //            case "Manufacturer":
        //                return cars.OrderByDescending(c => c.Manufacturer);
        //            case "Model":
        //                return cars.OrderByDescending(c => c.Model);
        //            case "YearOfProduction":
        //                return cars.OrderByDescending(c => c.YearOfProduction);
        //            default:
        //                return cars;
        //        }
        //    }
        //}
    }
}