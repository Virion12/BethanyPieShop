using BethanyPieShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace BethanyPieShop.Controlers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IPieRepository _pieRepository;

        public SearchController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var allPies = _pieRepository.AllPies;
            return Ok(allPies);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var pie = _pieRepository.GetPieById(id);
            if (pie == null)
            {
                return NotFound();
            }
            //if (!_pieRepository.AllPies.Any(p => p.PieId == id)) { return NotFound(); }
            else
            {
                return Ok(pie);
            }
        }

        [HttpPost()]
        public IActionResult SearchPie([FromBody] string searchquery)
        {
            IEnumerable<Pie> pies = new List<Pie>();

            if (!string.IsNullOrEmpty(searchquery))
            {
                pies = _pieRepository.SearchPies(searchquery);
            }
            return new JsonResult(pies);
        }


    }
}
