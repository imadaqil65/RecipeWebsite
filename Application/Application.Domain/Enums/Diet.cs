using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Domain.Enums
{
    public enum Diet
    {
        [Description("Vegetarian")] vegetarian = 1,
        [Description("Vegan")] vegan,
        [Description("Halal")] halal,
        [Description("Kosher")] kosher,
        [Description("Gluten Free")] glutenFree,
        [Description("Lactose Free")] lactoseFree
    }
}
