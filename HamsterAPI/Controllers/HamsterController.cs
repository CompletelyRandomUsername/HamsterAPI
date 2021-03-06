using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Resources;

namespace HamsterAPI.Controllers
{
    [ApiController]
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





        [HttpGet]
        [Route("[controller]/Out")]
        public IEnumerable<OutHamster> OutHamster()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                List<Hamster> hamsters = db.hamsters.ToList();
                List<OutHamster> outHamsters = new List<OutHamster>();
                OutHamster outHamster;

                foreach (var hamster in hamsters)
                {
                    outHamster = new OutHamster(hamster.type, hamster.weight_grams, DateTime.Now.Year - hamster.year_of_birth, hamster.ration);
                    outHamsters.Add(outHamster);
                }

                return Enumerable.Range(0, outHamsters.Count).Select(index => new OutHamster
                {
                    type = outHamsters[index].type,
                    weight_grams = outHamsters[index].weight_grams,
                    age_years = outHamsters[index].age_years,
                    ration = outHamsters[index].ration
                })
                .ToList();
            }
        }

        [HttpGet]
        [Route("[controller]/Add")]
        public string AddHamster()
        {
            Random rng = new Random();
            using (ApplicationContext db = new ApplicationContext())
            {
                Hamster hamster = new Hamster(Types[rng.Next(Types.Length)], rng.Next(20, 70), rng.Next(2019, 2022), Rations[rng.Next(Rations.Length)]);
                db.hamsters.Add(hamster);
                db.SaveChanges();
            }

            return "Хомяк добавлен";
        }











    }
}
