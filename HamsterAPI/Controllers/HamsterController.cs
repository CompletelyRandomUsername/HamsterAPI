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

        [HttpGet]
        public IEnumerable<Hamster> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Hamster
            {
                Type = Types[rng.Next(Types.Length)],
                WeightGrams = rng.Next(20, 70),
                AgeYears = rng.Next(1, 3),
                Ration = Rations[rng.Next(Rations.Length)],
            })
            .ToArray();
        }
    }
}
