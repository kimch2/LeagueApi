using System.Web.Mvc;
using LeagueApi.Helper;

namespace LeagueApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var test2 = new ChampionService(432);
            var result2 = test2.CallService();

            var test = new MatchService();
            var result = test.CallService(1786759297);

            return View(result);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}