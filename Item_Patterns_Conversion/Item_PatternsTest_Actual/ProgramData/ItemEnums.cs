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
    {//Different damage types will yield different results, or be more/less effective against certain entities
        None,
        Piercing, //Pickaxe
        Cultivating, //Cultivator
        Hacking, // Axe
        Bludgeoning // Hammer
    }

    public enum EnchantType
    {//Types of enchants that can be applied to Tools
        Fiery,
        Crushing,
    }

    public enum ResourceType
    {//Different Resource items that the player can pick up
        Wood,
        Stone,
        Flint,
        Clay
    }
}
