using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErenDenemeProje1
{
    public class Sehirler
    {
        public int SehirId { get; set; }
        public string SehirAdi { get; set; }
        public string CografiBolge { get; set; }

        public int ilcesayisi { get; set; }
        public string PlakaNo 
        {
            get 
            {
                return SehirId > 10 ? SehirId.ToString() : "0" + SehirId.ToString();
            }
        }
    }
}
