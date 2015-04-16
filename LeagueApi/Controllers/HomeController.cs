using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LeagueApi.Helper;
using LeagueApi.Models;
using RiotServices;

namespace LeagueApi.Controllers
{
    public class HomeController : Controller
    {
        private MatchesViewModel CurrentMatchModel
        {
            get { return (MatchesViewModel)Session["MatchesVM"]; }
            set { Session["MatchesVM"] = value; }
        }
        
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                var model = new MatchesViewModel {ChampionData = ChampionsService.CallService()};

                using (var riotDb = new RiotDataContext())
                    model.Matches = riotDb.Matches.Select(x => x.MatchId).ToList();

                model.CurrentMatchData = MatchService.CallService(model.Matches.First());
                model.CurrentMatchId = model.Matches.First();
                CurrentMatchModel = model;
                return View(model);
            }
            catch (Exception e)
            {
                return View("Error", new HandleErrorInfo(e, "Home", "Index"));
            }
        }

        public List<int> Matches { get; set; }

        [HttpPost]
        public ActionResult Index(int currentMatchId)
        {
            try
            {
                var currentModel = CurrentMatchModel;
                currentModel.CurrentMatchData = MatchService.CallService(currentMatchId);
                CurrentMatchModel = currentModel;
                return View(currentModel);
            }
            catch (Exception e)
            {
                return View("Error", new HandleErrorInfo(e, "Home", "Index"));
            }
        }
    }
}