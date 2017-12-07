using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTime.Infraestrutura
{
    public class FoodTimeContext : DbContext, IFoodTimeContext
    {
        public FoodTimeContext() : this("name=CrescerFoodTime") { }

        public FoodTimeContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }
    }
}
