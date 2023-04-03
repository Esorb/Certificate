using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esorb.Certificate.App.Model
{
    public class GradeCalculator
    {
        private IList<GradeLimit> gradeLimitList;

        public GradeCalculator(IList<GradeLimit> gradeLimits)
        {
            gradeLimitList = gradeLimits.OrderByDescending(gl => gl.PercentageLimit).ToList();
        }

        public string Calculate(int maximum, int actual)
        {
            if (maximum <= 0) return string.Empty;
            if (actual < 0) return string.Empty;
            double compareValue = (double)actual / maximum;
            foreach (GradeLimit gl in gradeLimitList)
            {
                if (compareValue >= gl.PercentageLimit)
                {
                    return gl.Grade;
                }
            }
            return string.Empty;
        }
    }
}
