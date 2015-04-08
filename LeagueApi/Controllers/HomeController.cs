using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LeagueApi.Helper;
using LeagueApi.Models;

namespace LeagueApi.Controllers
{
    public class HomeController : Controller
    {
        private MatchesViewModel CurrentModel
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

            CurrentModel = model;
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(int currentMatchId)
        {
            var currentModel = CurrentModel;
            currentModel.CurrentMatchData = MatchService.CallService(currentMatchId);
            CurrentModel = currentModel;
            return View(currentModel);
        }

        public ActionResult Champions()
        {
            var model = new ChampionsViewModel
            {
                ChampionData = ChampionsService.CallService(),
                Matches = ApiChallengeService.CallService(BucketTime).Take(9)
            };

            foreach (var match in model.Matches)
                model.MatchData.Add(MatchService.CallService(match));

            return View();
        }
    }
}