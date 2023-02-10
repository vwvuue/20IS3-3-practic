using Microsoft.AspNetCore.Mvc;

namespace Web1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static List<string> Summaries = new()
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public List<string> Get()
        {
            return Summaries;
        }
        [HttpPost]
        public IActionResult Add(string name)
        {
            //if (name == null)
            //{
            //    return BadRequest("Имя не должно быть пустым!!!!");
            //}
            Summaries.Add(name);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(int index, string name)
        {
            //if (name == null)
            //{
            //    return BadRequest("Имя не должно быть пустым!!!!");
            //}
            if (index<0 || index>=Summaries.Count)
            {
                return BadRequest("Такой индекс неверный!!!!");
            }
           
            Summaries[index] = name;
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int index)
        {

            if (index < 0 || index >= Summaries.Count)
            {
                return BadRequest("Такой индекс неверный!!!!");
            }
            Summaries.RemoveAt(index);
            return Ok();
        }

        [HttpGet("{index}")]
        public string GetOneName(int index)
        {
            if (index<0 || index >= Summaries.Count)
            {
                return "Такой индекс неверный!!!!";
            }
            return Summaries[index];
        }

        [HttpGet("find-by-name")]
        public int GetCountByName(string name)
        {
            int count = 0;
            for (int i = 0; i< Summaries.Count; i++)
            {
                if (Summaries[i] == name)
                    count++;
              
            }
            return count;
        }

        [HttpGet("sort")]
        public IActionResult GetAll(int? sortStrategy)
        {
            if (sortStrategy == null)
                return Ok(Summaries);
            if (sortStrategy == 1)
            {
                Summaries.Sort();
                return Ok(Summaries);
            }
            if (sortStrategy == -1)
            {
                Summaries.Sort();
                Summaries.Reverse();
                return Ok(Summaries);
            }
              return BadRequest("Некорректное значение параметра sortStrategy"); 
        }
    }
}