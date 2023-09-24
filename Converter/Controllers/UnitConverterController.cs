using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Converter.ConverterRepository.Interfaces;
using Converter.Enums;
using Converter.Model;
using Microsoft.AspNetCore.Mvc;

namespace Converter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UnitConverterController : ControllerBase
    {
        private readonly IMetricToImperialConverter _metricToImperialConverter;

        // private readonly ILogger<UnitConverterController> _logger;

        public UnitConverterController(IMetricToImperialConverter metricToImperialConverter)
        {
            _metricToImperialConverter = metricToImperialConverter;
        }

        [HttpPost("[action]")]
        public IActionResult MetricToImerial([FromBody] ConvertRequest request)
        {
            return Ok(_metricToImperialConverter.MetricToImerial(request));
        }

        [HttpGet]
        public decimal ImperialToMetric(decimal imperial)
        {
            return 10.5m;
        }

    }
}