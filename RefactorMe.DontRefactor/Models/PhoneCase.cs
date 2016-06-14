using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorMe.DontRefactor.Models
{
    public class PhoneCase
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Colour { get; set; }

        public string TargetPhone { get; set; }

        public string Material { get; set; }
    }
}
