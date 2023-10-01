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
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using Moq.EntityFrameworkCore;


namespace ConverterTest
{

    [TestFixture]
    public class ConverterTest
    {
        Mock<DataContext> dataDBContextMock = new Mock<DataContext>();

        IQueryable<LengthConversion> data;

        [SetUp]
        public void Setup()
        {
            data = new List<LengthConversion>
             {
                 new LengthConversion { Id = 1, ImperialUnit = 25.4000m, Source = "in", Target = "mm" },
                 new LengthConversion { Id = 2, ImperialUnit = 1000, Source = "m", Target = "mm" },
                 new LengthConversion { Id = 3, ImperialUnit = 100, Source = "m", Target = "cm" },
                 new LengthConversion { Id = 4, ImperialUnit = 3.2810m, Source = "m", Target = "ft" },
                 new LengthConversion { Id = 5, ImperialUnit = 10, Source = "mm", Target = "cm" },
                 new LengthConversion { Id = 6, ImperialUnit = 1000, Source = "km", Target = "m" }
             }.AsQueryable();

            dataDBContextMock.Setup<DbSet<LengthConversion>>(x => x.LengthConversions).ReturnsDbSet(data);
        }

        [Test]
        public void InchToMilimeter()
        {
            //Act
            IMetricToImperialConverter metricToImperialConverter = new MetricToImperialConverter(dataDBContextMock.Object);

            //Arrange
            var converterController = new UnitConverterController(metricToImperialConverter);
            var _output = converterController.MetricToImerial(new ConvertRequest { Source = "in", Target = "mm", type = ConvertionType.LENGHT, value = 2 });

            //Assert
            Assert.That(((Microsoft.AspNetCore.Mvc.ObjectResult)_output).Value,Is.EqualTo("50.80 mm"));
        }

        [Test]
        public void MilimieterToInch()
        {
            //Act
            IMetricToImperialConverter metricToImperialConverter = new MetricToImperialConverter(dataDBContextMock.Object);

            //Arrange
            var converterController = new UnitConverterController(metricToImperialConverter);
            var _output = converterController.MetricToImerial(new ConvertRequest { Source = "mm", Target = "in", type = ConvertionType.LENGHT, value = 2 });

            //Assert
            Assert.That(((Microsoft.AspNetCore.Mvc.ObjectResult)_output).Value,Is.EqualTo("0.08 in"));
        }

        [Test]
        public void KilometerToMeter()
        {
            //Act
            IMetricToImperialConverter metricToImperialConverter = new MetricToImperialConverter(dataDBContextMock.Object);

            //Arrange
            var converterController = new UnitConverterController(metricToImperialConverter);
            var _output = converterController.MetricToImerial(new ConvertRequest { Source = "km", Target = "m", type = ConvertionType.LENGHT, value = 8 });

            //Assert
            Assert.That(((Microsoft.AspNetCore.Mvc.ObjectResult)_output).Value,Is.EqualTo("8000 m"));
        }


        [Test]
        public void MeterToKilometer()
        {
            //Act
            IMetricToImperialConverter metricToImperialConverter = new MetricToImperialConverter(dataDBContextMock.Object);

            //Arrange
            var converterController = new UnitConverterController(metricToImperialConverter);
            var _output = converterController.MetricToImerial(new ConvertRequest { Source = "m", Target = "km", type = ConvertionType.LENGHT, value = 2000 });

            //Assert            
            Assert.That(((Microsoft.AspNetCore.Mvc.ObjectResult)_output).Value,Is.EqualTo("2 km"));
        }

        [Test]
        public void celciusToFahrenheit()
        {
            //Act
            IMetricToImperialConverter metricToImperialConverter = new MetricToImperialConverter(dataDBContextMock.Object);

            //Arrange
            var converterController = new UnitConverterController(metricToImperialConverter);
            var _output = converterController.MetricToImerial(new ConvertRequest { Source = "c", Target = "f", type = ConvertionType.TEMPRATURE, value = 10 });

            //Assert            
             Assert.That(((Microsoft.AspNetCore.Mvc.ObjectResult)_output).Value,Is.EqualTo("50 °F"));
        }

          [Test]
        public void FahrenheitToCelcius()
        {
            //Act
            IMetricToImperialConverter metricToImperialConverter = new MetricToImperialConverter(dataDBContextMock.Object);

            //Arrange
            var converterController = new UnitConverterController(metricToImperialConverter);
            var _output = converterController.MetricToImerial(new ConvertRequest { Source = "f", Target = "c", type = ConvertionType.TEMPRATURE, value = 10 });

            //Assert            
             Assert.That(((Microsoft.AspNetCore.Mvc.ObjectResult)_output).Value,Is.EqualTo("-12.2222 °C"));
        }

    }
}
