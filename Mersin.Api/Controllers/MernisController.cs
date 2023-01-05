using Mersin.Api.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mersin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MernisController : ControllerBase
    {
        private readonly MernisContext context;

        public MernisController(MernisContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            var result = context.Citizens.Take(10).ToList();
            DateTime start = DateTime.Now;
            DateTime stop = DateTime.Now;

            TimeSpan timeSpan = stop - start;
            var sonuc = timeSpan.Microseconds;


            if (result.Count == 0)
            {
                return Ok(result);
            }
            else
            {
                return NoContent();
            }


        }
        [HttpGet("{tcno}")]
        [Authorize]
        public IActionResult GetByTcNo(string tcno)
        {
            var result = context.Citizens.FirstOrDefault(p => p.NationalIdentifier == tcno);
            DateTime start = DateTime.Now;
            DateTime stop = DateTime.Now;

            TimeSpan timeSpan = stop - start;
            var sonuc = timeSpan.Microseconds;

            if (result != null)
            {
                return Ok(result);

            }
            else
            {
                return NoContent();
            }






        }
    }
}
