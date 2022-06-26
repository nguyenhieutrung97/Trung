using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Service
{
    public interface ICalculationsService
    {
        IEnumerable<int> NumbersCalculation(int step, IEnumerable<int> input);
    }
}
