using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeagueApi.Helper;
using LeagueApi.Models;
using RiotServices;

namespace LeagueApi.Controllers
{
    public class FunStatsController : Controller
    {
        private MatchesViewModel CurrentMatchModel
        {
            get { return (MatchesViewModel) ViewData["MatchesVM"]; }
            set { ViewData["MatchesVM"] = value; }
        }

        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                var model = new FunStatViewModel();

                using (var riotDb = new RiotDataContext())
                {
                    model.MatchCount = riotDb.Matches.Count();
                    var funStats = riotDb.FunStats().ToList();
                    model.WinData.Add(funStats.First(x => x.Name == "Kills"));
                    model.WinData.Add(funStats.First(x => x.Name == "Wards"));
                }
                    
                return View(model);
            }
            catch (Exception e)
            {
                return View("Error", new HandleErrorInfo(e, "Home", "Index"));
            }
        }
    }

    
}