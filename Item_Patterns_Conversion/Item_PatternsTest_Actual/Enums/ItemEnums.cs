using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_PatternsTest_Actual.Enums
{
    public enum ToolType
    {//enum for the types of crafting this resource is associated with
        Axe,
        Pickaxe,
        Hammer,
        Cultivator,
        Torch,
        Shield
    }

    public enum DamageType
    {
        None,
        Piercing, //Pickaxe
        Cultivating, //Cultivator
        Hacking, // Axe
        Bludgeoning // Hammer
    }

    public enum ResourceType
    {
        Wood,
        Stone,
        Flint,
        Clay
    }
}
