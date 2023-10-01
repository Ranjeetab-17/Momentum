using Converter.Model;

namespace Converter.ConverterRepository.Interfaces
{
    public interface IMetricToImperialConverter
    {
        string MetricToImerial(ConvertRequest request);
    }
}