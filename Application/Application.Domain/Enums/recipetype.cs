using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Domain.Enums
{
    public enum recipetype
    {
        [Description("Main Course")]
        Maincourse = 1,
        [Description("Drink")] 
        Drink,
        [Description("Dessert")]
        Dessert
    }
}
