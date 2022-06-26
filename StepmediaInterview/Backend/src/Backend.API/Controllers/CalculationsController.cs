using Backend.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationsController : ControllerBase
    {
        private readonly ICalculationsService _calculatorService;
        private readonly IConfiguration Configuration;

        public CalculationsController(IConfiguration configuration,ICalculationsService calculationsService)
        {
            Configuration = configuration;
            _calculatorService = calculationsService;
        }
        // GET: api/<CalculationsController>
        [HttpPost]
        public ActionResult<IEnumerable<int>> CalculateAlgorithmResult([FromBody] List<int> input)
        {
            try
            {
                var step = Configuration["StepMediaExercise:Step"];
                var result = _calculatorService.NumbersCalculation(Int32.Parse(step), input);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
