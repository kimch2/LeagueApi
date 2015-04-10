using System;
using System.Linq;
using System.Web.Mvc;
using LeagueApi.Helper;
using LeagueApi.Models;

namespace LeagueApi.Controllers
{
    public class HomeController : Controller
    {
        private MatchesViewModel CurrentMatchModel
        {
            get { return (MatchesViewModel) Session["MatchesVM"]; }
            set { Session["MatchesVM"] = value; }
        }

        private static DateTime BucketDateTime
        {
            get
            {
                var now = DateTime.UtcNow;
                return now.AddHours(-1).AddMinutes(-now.Minute).AddSeconds(-now.Second);
            }
        }

        private static int BucketTime
        {
            get
            {
                return Convert.ToInt32(Math.Floor((BucketDateTime - new DateTime(1970, 1, 1)).TotalSeconds));
            }
        }
        
        [HttpGet]
        public ActionResult Index()
        {
            var model = new MatchesViewModel();
            model.ChampionData = ChampionsService.CallService();
            model.BucketDateTime = BucketDateTime;
            model.Matches = ApiChallengeService.CallService(BucketTime);
            model.CurrentMatchData = MatchService.CallService(model.Matches.First());
            model.CurrentMatchId = model.Matches.First();

            CurrentMatchModel = model;
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(int currentMatchId)
        {
            var currentModel = CurrentMatchModel;
            currentModel.CurrentMatchData = MatchService.CallService(currentMatchId);
            CurrentMatchModel = currentModel;
            return View(currentModel);
        }
    }
}