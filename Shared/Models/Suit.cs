using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class Suit
    {
        public int Id { get; set; }
        public string OrderId { get; set; }
        public int Size { get; set; }
        public string PrimaryMaterial { get; set; }
        public string SecondaryMaterial { get; set; }
        public string TertiaryMaterial { get; set; }
        public string PrimaryColor { get; set; }
        public string SecondaryColor { get; set; }
        public string TertiaryColor { get; set; }
        public bool Vest { get; set; }
        public string Cut { get; set; }
        public int Buttons { get; set; }
        public string Lapel { get; set; }
        public int Price { get; set; }
    }
}
