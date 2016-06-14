using RefactorMe.DontRefactor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RefactorMe.DontRefactor.Data.Implementation
{
    public class PhoneCaseRepository : BaseReadOnlyRepository<PhoneCase>
    {
        protected override PhoneCase[] Data {
            get {
                return new PhoneCase[] {
                    new PhoneCase() { 
                        Id = Guid.NewGuid(),
                        Name = "Amazon Fire Burgundy Phone Case",
                        Colour = "Burgundy",
                        Material = "PVC",
                        TargetPhone = "Amazon Fire",
                        Price = 14.0
                    },
                    new PhoneCase() {
                        Id = Guid.NewGuid(),
                        Name = "Nokia Lumia 920/930/Icon Crimson Phone Case",
                        Colour = "Red",
                        Material = "Rubber",
                        TargetPhone = "Nokia Lumia 920/930/Icon",
                        Price = 10.0
                    }
                };
            }
        }
    }
}
