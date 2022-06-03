using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamsterAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HamsterController:ControllerBase
    {
        private static readonly string[] Types = new[]
        {
            "обычный хомяк", "джунгарский хомяк", "дикий лесной хомяк", "ангорский хомяк", "резиновый хомяк с пищалкой"
        };

        private static readonly string[] Rations = new[]
        {
            "салат", "редис", "сало"
        };

        private readonly ILogger<HamsterController> _logger;

        public HamsterController(ILogger<HamsterController> logger)
        {
            _logger = logger;
        }

        public List<Hamster> AddHamster(List<Hamster> HamsterList)
        {
            var rng = new Random();
            Hamster hamster = new Hamster(Types[rng.Next(Types.Length)], rng.Next(20, 70), rng.Next(1, 3), Rations[rng.Next(Rations.Length)]);
            HamsterList.Add(hamster);
            return HamsterList;
        }

        public IEnumerable<Hamster> OutHamster(List<Hamster> HamsterList)
        {
            var rng = new Random();
            
                return Enumerable.Range(0, HamsterList.Count).Select(index => new Hamster
                {
                    Type = HamsterList[index].Type,
                    WeightGrams = HamsterList[index].WeightGrams,
                    AgeYears = HamsterList[index].AgeYears,
                    Ration = HamsterList[index].Ration
                })
                .ToArray();
            
        }


        [HttpGet]
        public IEnumerable<Hamster> Get()
        {
            List<Hamster> HamsterList = new List<Hamster>();

            foreach (var index in Enumerable.Range(5, 10))
                AddHamster(HamsterList);


            return OutHamster(HamsterList);
            
        }
        
    }
}
