using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kpo4162.Ivanov.Lib
{
    public static class ProjectTestHelper
    {
        public static bool ValidateFields(SETI target)
        {
            if (string.IsNullOrWhiteSpace(target.Name) || target.Name.Length > 32)
            {
                return false;
            }

            if (target.Year < 1900 || target.Year>2017)
            {
                return false;
            }

            if (target.Diametr <= 0)
            {
                return false;
            }

            if (target.Chastota <= 0 || target.Chastota >= 1000000)
            {
                return false;
            }
            return false;
        }
    }
}
