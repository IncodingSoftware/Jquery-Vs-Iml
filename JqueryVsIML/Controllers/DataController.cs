namespace JqueryVsIML.Controllers
{
    #region << Using >>

    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Incoding.Maybe;
    using Incoding.MvcContrib;

    #endregion

    public class DataController : Controller
    {
        #region Http action

        [HttpGet]
        public ActionResult Fetch(CriterieQuery query)
        {
            return IncodingResult.Success(DataHelper.Query(query));
        }

        #endregion
    }

    public class Car
    {
        #region Properties

        public string Brand { get; set; }

        public string Model { get; set; }

        public string Fuel { get; set; }

        #endregion

        #region Enums

        public enum FuelOfType
        {
            A95,

            A92,

            A76
        }

        #endregion
    }

    public static class DataHelper
    {
        #region Factory constructors

        public static List<Car> Query(CriterieQuery query)
        {
            var res = new List<Car>
                          {
                                  new Car { Fuel = Car.FuelOfType.A76.ToString(), Brand = "Audi", Model = "A4" },
                                  new Car { Fuel = Car.FuelOfType.A92.ToString(), Brand = "Audi", Model = "A6" },
                                  new Car { Fuel = Car.FuelOfType.A95.ToString(), Brand = "Audi", Model = "A8" },
                                  new Car { Fuel = Car.FuelOfType.A76.ToString(), Brand = "Fiat", Model = "Poolo" },
                                  new Car { Fuel = Car.FuelOfType.A76.ToString(), Brand = "Fiat", Model = "Poto" },
                                  new Car { Fuel = Car.FuelOfType.A76.ToString(), Brand = "Fiat", Model = "Pito" },
                                  new Car { Fuel = Car.FuelOfType.A95.ToString(), Brand = "Ferrari", Model = "F30" },
                                  new Car { Fuel = Car.FuelOfType.A95.ToString(), Brand = "Ferrari", Model = "F50" },
                                  new Car { Fuel = Car.FuelOfType.A95.ToString(), Brand = "Ferrari", Model = "F90" }
                          };

            return res.Where(r => !query.Fuel.HasValue || r.Fuel == query.Fuel.ToString())
                      .Where(r => !query.Brand.Recovery(new string[0]).Any() || query.Brand.Contains(r.Brand))
                      .Where(r => string.IsNullOrWhiteSpace(query.Model) || r.Model.Contains(query.Model))
                      .ToList();
        }

        #endregion
    }

    public class CriterieQuery
    {
        #region Properties

        public Car.FuelOfType? Fuel { get; set; }

        public string[] Brand { get; set; }

        public string Model { get; set; }

        #endregion
    }
}