using System.Diagnostics;
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
using Converter.ConverterRepository.Implementations;
using DataAccess.DataModels;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Converter.DataModel;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

namespace ConverterTest
{

    [TestFixture]
    public class ConverterTest
    {

        IMetricToImperialConverter converter;
        MockDbContext mockDbContext = new MockDbContext();

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void inTomm()
        {
            var data = new List<LengthConversion> {
                new LengthConversion { Id = 1, ImperialUnit = 25.4000m, Source = "in", Target = "mm" }
            }.AsQueryable();

            mockDbContext.CreateDbSetMock(data);

            var metricToImperialConverter = new MetricToImperialConverter(mockDbContext.Context.Object);

            var controller = new UnitConverterController(metricToImperialConverter);

            var output = controller.MetricToImerial(new ConvertRequest { type = ConvertionType.LENGHT, Source = "mm", Target = "in", value = 20 });

            Assert.Equals("508.00 mm", output);
        }

        [Test]
        public void celciusToF()
        {
            var data = new List<LengthConversion> { new LengthConversion { Id = 2, ImperialUnit = 20, Source = "c", Target = "f" } }.AsQueryable();

            mockDbContext.CreateDbSetMock(data);

            var metricToImperialConverter = new MetricToImperialConverter(mockDbContext.Context.Object);

            var controller = new UnitConverterController(metricToImperialConverter);

            var output = controller.MetricToImerial(new ConvertRequest { type = ConvertionType.LENGHT, Source = "mm", Target = "in", value = 20 });

            Assert.Equals("68.00° F", output);             
        }
    }
}
