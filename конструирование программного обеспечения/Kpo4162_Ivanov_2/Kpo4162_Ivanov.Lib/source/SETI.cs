using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kpo4162.Ivanov.Lib
{
    public class SETI
    {
        public int Year { get; set; }
        public string Name { get; set; }
        public int Diametr { get; set; }
        public int Chastota { get; set; }
        public string Primechanie { get; set; }
        public SETI()
        {
            Year = 0;
            Name = "";
            Diametr = 0;
            Chastota = 0;
            Primechanie="наблюдались объекты от 2 звезд до нескольких галактик";

        }
    }
}
