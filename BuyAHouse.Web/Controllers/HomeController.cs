using System.Linq;
using System.Web.Mvc;
using BuyAHouse.Models;

namespace BuyAHouse.Controllers
{
    public class HomeController : Controller
    {
        readonly Data.BuyAHouseDataEntitiesContainer _db = new Data.BuyAHouseDataEntitiesContainer();

        public ActionResult Index()
        {
            // List all properties
            var properties = from p in _db.Properties
                             select new PropertyModel
                                        {
                                            PropertyId = p.PropertyId,
                                            Address = p.Address,
                                        };

            return View(properties);
        }

    }
}
