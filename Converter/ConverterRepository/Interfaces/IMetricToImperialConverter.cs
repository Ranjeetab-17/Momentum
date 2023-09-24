using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Converter.Model;

namespace Converter.ConverterRepository.Interfaces
{
    public interface IMetricToImperialConverter
    {
        string MetricToImerial(ConvertRequest request);
    }
}