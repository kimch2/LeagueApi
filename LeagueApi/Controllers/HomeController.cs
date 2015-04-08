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

        [HttpGet]
        public ActionResult Index()
        {
            var model = new MatchesViewModel();
            model.ChampionData = ChampionsService.CallService();
            model.Matches = ApiChallengeService.CallService();
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