using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Converter.Controllers;
using Converter.ConverterRepository.Interfaces;
using Converter.Enums;
using Converter.Model;
using Moq;

namespace ConverterTest
{

    public class ConverterTest
    {
        [Test]
        public void inTomm()
        {
            var templateRepo = new Mock<IMetricToImperialConverter>();

            var request = new ConvertRequest { Source = "in", Target = "mm", type = ConvertionType.LENGHT, value = 20 };

            var converterControllerTest = new UnitConverterController(templateRepo.Object);

            templateRepo.SetUp(p => p.MetricToImerial(request));

            var output = converterControllerTest.MetricToImerial(request);

        }
    }
}
