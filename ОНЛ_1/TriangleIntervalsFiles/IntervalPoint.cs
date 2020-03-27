using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ОНЛ_5.TriangleIntervalsFiles
{
    public class IntervalPoint
    {
        public double x;
        public int verity;

        public IntervalPoint()
        {
            verity = 0;
            x = 0;
        }
        public IntervalPoint(double x, int verity)
        {
            this.x = x;
            this.verity = verity;
        }
    }
}
