using System.Collections.Generic;
using System.Linq;
using RiotServices;

namespace StoreTracker.Models
{
    public class ChampionViewModel
    {
        public ChampionViewModel()
        {
            var dbContext = new ApplicationDbContext();
            var champions = RiotService.ChampionsService().Champions;
            Champions = FakeData.Get();
        }

        public List<ChampionData> Champions { get; set; }
    }

    public class FakeData
    {
        public static List<ChampionData> Get()
        {
            return new List<ChampionData>
            {
                new ChampionData
                {
                    Id = 266,
                    Owned = false,
                    Skins = null
                },
                new ChampionData
                {
                    Id = 103,
                    Owned = true,
                    Skins = new List<string>{"Test","Test2"}
                }
            };
        }
    }

    public class ChampionData
    {
        public int Id { get; set; }
        public bool Owned { get; set; }
        public List<string> Skins { get; set; }
    }
}