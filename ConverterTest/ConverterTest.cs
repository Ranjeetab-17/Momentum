using Converter.Controllers;
using Converter.ConverterRepository.Implementations;
using Converter.ConverterRepository.Interfaces;
using Converter.DataModel;
using Converter.Enums;
using Converter.Model;
using DataAccess.DataModels;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;


namespace ConverterTest
{

    [TestFixture]
    public class ConverterTest
    {
        Mock<DataContext> dataDBContextMock = new Mock<DataContext>();

        IQueryable<LengthConversion>? data;

        [SetUp]
        public void Setup()
        {
            data = new List<LengthConversion>
             {
                 new LengthConversion { Id = 1, ImperialUnit = 25.4000m, Source = "in", Target = "mm" },
                 new LengthConversion { Id = 2, ImperialUnit = 1000, Source = "m", Target = "mm" },
                 new LengthConversion { Id = 3, ImperialUnit = 100, Source = "m", Target = "cm" },
                 new LengthConversion { Id = 4, ImperialUnit = 3.2810m, Source = "m", Target = "ft" },
                 new LengthConversion { Id = 5, ImperialUnit = 10, Source = "cm", Target = "mm" },
                 new LengthConversion { Id = 6, ImperialUnit = 1000, Source = "km", Target = "m" },
                 new LengthConversion { Id = 7, ImperialUnit = 12.0000m, Source = "ft", Target = "in" },
                 new LengthConversion { Id = 8, ImperialUnit = 2.5400m, Source = "in", Target = "cm" },
                 new LengthConversion { Id = 9, ImperialUnit = 100000.0000m, Source = "km", Target = "cm" },
                 new LengthConversion { Id = 10, ImperialUnit = 39.3700m, Source = "m", Target = "in" },
                 new LengthConversion { Id = 11, ImperialUnit = 1.0940m, Source = "m", Target = "y" },
             }.AsQueryable();

            dataDBContextMock.Setup<DbSet<LengthConversion>>(x => x.LengthConversions).ReturnsDbSet(data);
        }

        [TestCase("in", "mm", ConvertionType.LENGHT, 25, ExpectedResult = "635.00 mm", TestName = "Innch To Milimeter")]
        [TestCase("m", "mm", ConvertionType.LENGHT, 25, ExpectedResult = "25000 mm", TestName = "Meter to Milimeter")]
        [TestCase("m", "cm", ConvertionType.LENGHT, 25, ExpectedResult = "2500 cm", TestName = "Meter to Centimeter")]
        [TestCase("m", "ft", ConvertionType.LENGHT, 25, ExpectedResult = "82.02 ft", TestName = "Meter To Foot")]
        [TestCase("m", "y", ConvertionType.LENGHT, 25, ExpectedResult = "27.35 y", TestName = "Meter to yeard")]
        [TestCase("m", "in", ConvertionType.LENGHT, 25, ExpectedResult = "984.25 in", TestName = "Meter To Inch")]
        [TestCase("mm", "cm", ConvertionType.LENGHT, 25, ExpectedResult = "2.5 cm", TestName = "Milimeter to Centimeter")]
        [TestCase("km", "m", ConvertionType.LENGHT, 25, ExpectedResult = "25000 m", TestName = "Kilometer to meter")]
        [TestCase("km", "cm", ConvertionType.LENGHT, 25, ExpectedResult = "2500000.00 cm", TestName = "Kilometer to Centimeter")]
        [TestCase("in", "cm", ConvertionType.LENGHT, 25, ExpectedResult = "63.50 cm", TestName = "Inch to Centimeter")]
        [TestCase("ft", "in", ConvertionType.LENGHT, 25, ExpectedResult = "300.00 in", TestName = "Foot to Inch")]
        [Category("Length")]
        public string MetricUnitToImperialUnitConversion(string source, string target, ConvertionType type, int value)
        {
            //Act
            IMetricToImperialConverter metricToImperialConverter = new MetricToImperialConverter(dataDBContextMock.Object);

            //Arrange
            var converterController = new UnitConverterController(metricToImperialConverter);
            var _output = converterController.MetricToImerial(new ConvertRequest { Source = source, Target = target, type = type, value = value });

            //Assert
            return ((dynamic)_output).Value.ToString();
        }

        [TestCase("c", "f", ConvertionType.TEMPRATURE, 10, ExpectedResult = "50 °F", TestName = "Celcius to Fahrenheit")]
        [TestCase("f", "c", ConvertionType.TEMPRATURE, 10, ExpectedResult = "-12.2222 °C", TestName = "Fahrenheit To Celcius")]
        [Category("Temprature")]
        public string Temprature(string source, string target, ConvertionType type, int value)
        {
            //Act
            IMetricToImperialConverter metricToImperialConverter = new MetricToImperialConverter(dataDBContextMock.Object);

            //Arrange
            var converterController = new UnitConverterController(metricToImperialConverter);
            var _output = converterController.MetricToImerial(new ConvertRequest { Source = source, Target = target, type = ConvertionType.TEMPRATURE, value = value });

            //Assert            
            return ((dynamic)_output).Value.ToString();
        }
    }
}
