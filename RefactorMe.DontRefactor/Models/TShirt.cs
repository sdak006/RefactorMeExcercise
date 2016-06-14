using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorMe.DontRefactor.Models
{
    public class TShirt
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Colour { get; set; }

        public double Price { get; set; }

        public string ShirtText { get; set; }
    }
}
