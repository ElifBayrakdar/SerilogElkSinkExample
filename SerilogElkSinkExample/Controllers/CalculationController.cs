using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;

namespace SerilogElkSinkExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculationController : ControllerBase
    {

        private readonly ILogger<CalculationController> _logger;
        private readonly IConfiguration _configuration;

        public CalculationController(ILogger<CalculationController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet]
        public int Get()
        {
            int firstNumber = 10;
            int secondNumber = 0;
            int result = 0; ;
            Student student = new Student { Name = "Elif", Surname = "Bayrakdar" };

            try
            {
                Log.Information("{@Student} is dividing {firstNumber} by {secondNumber}", student, firstNumber, secondNumber);

                result = firstNumber / secondNumber;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Something went wrong while dividing {firstNumber} by {secondNumber}!", firstNumber, secondNumber);
            }
            return result;
        }
    }
}
