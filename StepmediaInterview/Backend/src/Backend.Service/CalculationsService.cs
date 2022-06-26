using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Service
{
    public class CalculationsService : ICalculationsService
    {
        private readonly ILogger _logger;
        public CalculationsService(ILogger<CalculationsService> logger)
        {
            _logger = logger;
        }
        public IEnumerable<int> NumbersCalculation(int step, IEnumerable<int> input)
        {
            var result = input.ToList();

            try
            {
                _logger.LogInformation($"Input: {string.Join(",", input)}");

                result.Sort();
                var topLargest = result.TakeLast(step);
                var secondLargest = result.SkipLast(step).TakeLast(step);
                var thirdLargest = result.SkipLast(step * 2).TakeLast(step);
                var restNumbers = result.SkipLast(step * 3).ToList();
                var lenghtRestNumbers = restNumbers.Count;
                restNumbers.InsertRange(lenghtRestNumbers / 2, topLargest);

                result = secondLargest.Concat(restNumbers).Concat(thirdLargest).ToList();

                _logger.LogInformation($"Result: {string.Join(",", result)}");
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Error while processing calculation ");
                throw;
            }

            return result;
        }
    }
}
