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

        //public List<Hamster> AddHamster(List<Hamster> HamsterList)
        //{
        //    var rng = new Random();
        //    Hamster hamster = new Hamster(Types[rng.Next(Types.Length)], rng.Next(20, 70), rng.Next(2019, 2022), Rations[rng.Next(Rations.Length)]);
        //    HamsterList.Add(hamster);
        //    return HamsterList;
        //}




        //public IEnumerable<Hamster> OutHamster(List<Hamster> HamsterList)
        //{
        //    var rng = new Random();

        //        return Enumerable.Range(0, HamsterList.Count).Select(index => new Hamster
        //        {
        //            Type = HamsterList[index].GetHamsterType,
        //            WeightGrams = HamsterList[index].GetWeightGrams,
        //            AgeYears = HamsterList[index].GetAgeYears,
        //            Ration = HamsterList[index].GetRation
        //        });
        //        .ToArray();

        //}

        public void AddHamster()
        {
            Random rng = new Random();
            using (ApplicationContext db = new ApplicationContext())
            {
                Hamster hamster = new Hamster(Types[rng.Next(Types.Length)], rng.Next(20, 70), rng.Next(2019, 2022), Rations[rng.Next(Rations.Length)]);
                db.hamsters.Add(hamster);
                db.SaveChanges();
            }
        }

        public IEnumerable<OutHamster> OutHamsters()
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
        public IEnumerable<OutHamster> Get()         
        {
            return OutHamsters();

            //List<Hamster> HamsterList = new List<Hamster>();

            //foreach (var index in Enumerable.Range(5, 10))
            //    AddHamster(HamsterList);


            //return OutHamster(HamsterList);


        }

        

        
        
    }
}
