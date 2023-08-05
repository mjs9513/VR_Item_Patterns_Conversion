using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_PatternsTest_Actual.Enums
{
    public enum ToolType
    {//enum for the types of tools
        Axe,
        Pickaxe,
        Hammer,
        Cultivator,
        Torch,
        Shield
    }
    
    public enum ToolQuality
    {//enum for the quality levels of tools that can be made
        Stone,
        Iron,
        Steel,
        Mythical
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
