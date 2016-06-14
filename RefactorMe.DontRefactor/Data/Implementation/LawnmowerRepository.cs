using RefactorMe.DontRefactor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorMe.DontRefactor.Data.Implementation
{
    public class LawnmowerRepository : BaseReadOnlyRepository<Lawnmower>
    {
        protected override Lawnmower[] Data {
            get {
                return new Lawnmower[] {
                    new Lawnmower() {
                        Id = Guid.NewGuid(),
                        Name = "Hewlett-Packard Rideable Lawnmower",
                        FuelEfficiency = "Very Low",
                        IsVehicle = true,
                        Price = 3000.0
                    },
                    new Lawnmower() {
                        Id = Guid.NewGuid(),
                        Name = "Fisher Price's My First Lawnmower",
                        FuelEfficiency = "Ultimate",
                        IsVehicle = false,
                        Price = 45.0
                    },
                    new Lawnmower() {
                        Id = Guid.NewGuid(),
                        Name = "Volkswagen LawnMaster 39000B Lawnmower",
                        FuelEfficiency = "Moderate",
                        IsVehicle = false,
                        Price = 1020.0
                    }
                };
            }
        }
    }
}
