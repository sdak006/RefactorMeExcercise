using RefactorMe.DontRefactor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorMe.DontRefactor.Data.Implementation
{
    public class TShirtRepository : BaseReadOnlyRepository<TShirt>
    {
        protected override TShirt[] Data {
            get {
                return new TShirt[] {
                    new TShirt() {
                        Id = Guid.NewGuid(),
                        Colour = "Blue",
                        Name = "Xamarin C# T-Shirt",
                        Price = 15.0,
                        ShirtText = "C#, Xamarin"
                    },
                    new TShirt() {
                        Id = Guid.NewGuid(),
                        Colour = "Black",
                        Name = "New York Yankees T-Shirt",
                        Price = 8.0,
                        ShirtText = "NY"
                    },
                    new TShirt() {
                        Id = Guid.NewGuid(),
                        Colour = "Green",
                        Name = "Disney Sleeping Beauty T-Shirt",
                        Price = 10.0,
                        ShirtText = "Mirror mirror on the wall..."
                    }
                };
            }
        }
    }
}
