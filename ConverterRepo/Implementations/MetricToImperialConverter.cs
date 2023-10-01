using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Converter.ConverterRepository.Interfaces;
using Converter.Helpers;
using Converter.Model;
using DataAccess.DataModels;
using Converter.DataModel;

namespace Converter.ConverterRepository.Implementations
{
    public class MetricToImperialConverter : IMetricToImperialConverter
    {
        private readonly DataContext _context;

        public MetricToImperialConverter()
        {

        }

        public MetricToImperialConverter(DataContext context)
        {
            _context = context;
        }        

        public string MetricToImerial(ConvertRequest request)
        {
            string output = string.Empty;
            bool isViseVersa = false;

            switch (request.type)
            {
                case Enums.ConvertionType.LENGHT:
                    LengthConversion _data = getCalcImperialValue(request, ref isViseVersa);

                    output = _data.ImperialUnit.ToLength(request.Target, request.value, isViseVersa);
                    break;
                case Enums.ConvertionType.TEMPRATURE:
                    output = request.value.ToTemprature(request.Source, request.Target);
                    break;
                default:
                    break;
            }

            return output;
        }

        private LengthConversion getCalcImperialValue(ConvertRequest request, ref bool isViseVersa)
        {
            var _data = (from _d in _context.LengthConversions
                         where _d.Source == request.Source && _d.Target == request.Target
                         select _d).FirstOrDefault();

            if (_data == null)
            {
                _data = (from _d in _context.LengthConversions
                         where _d.Source == request.Target && _d.Target == request.Source
                         select _d).FirstOrDefault();

                isViseVersa = true;
            }

            return _data;
        }
    }
}