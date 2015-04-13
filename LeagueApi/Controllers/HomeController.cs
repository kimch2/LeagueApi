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
            get { return (MatchesViewModel) Session["MatchesVM"]; }
            set { Session["MatchesVM"] = value; }
        }
        
        [HttpGet]
        public ActionResult Index()
        {
            //try
            //{
                var model = new MatchesViewModel();
                model.ChampionData = ChampionsService.CallService();
                using (var riotDb = new RiotDataContext())
                    model.Matches = riotDb.Matches.Select(x => x.MatchId).ToList();
                model.CurrentMatchData = MatchService.CallService(model.Matches.First());
                model.CurrentMatchId = model.Matches.First();
                CurrentMatchModel = model;
                return View(model);
            //}
            //catch (Exception)
            //{
            //    return View("Error");
            //}
        }

        public List<int> Matches { get; set; }

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