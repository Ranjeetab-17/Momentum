using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Converter.ConverterRepository.Interfaces;
using Converter.DataModel;
using Converter.Helpers;
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
                string output = string.Empty;
                bool isViseVersa = false;

                switch (request.type)
                {
                    case Enums.ConvertionType.LENGHT:
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
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}