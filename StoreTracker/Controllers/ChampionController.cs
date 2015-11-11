using System.Web.Mvc;
using RiotServices;
using StoreTracker.Models;

namespace StoreTracker.Controllers
{
    public class ChampionController : Controller
    {
        // GET: Champion
        [Authorize]
        public ActionResult Index()
        {
            var championViewModel = new ChampionViewModel();
            return View(championViewModel);
        }
    }
}