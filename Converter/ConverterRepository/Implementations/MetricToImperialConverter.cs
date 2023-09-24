using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Converter.ConverterRepository.Interfaces;
using Converter.DataModel;
using Converter.Model;

namespace Converter.ConverterRepository.Implementations
{
    public class MetricToImperialConverter : IMetricToImperialConverter
    {
        private readonly DataContext _context;

        public MetricToImperialConverter(DataContext context)
        {
            _context = context;
        }

        public string MetricToImerial(ConvertRequest request)
        {
            try
            {
                var _data = (from _d in _context.LengthConversions
                             select _d).ToList();

                return string.Empty;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}