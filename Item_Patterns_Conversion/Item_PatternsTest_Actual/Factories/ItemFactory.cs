using Item_PatternsTest_Actual.Behaviors;
using Item_PatternsTest_Actual.Blueprints;
using Item_PatternsTest_Actual.Enums;
using Item_PatternsTest_Actual.Items;
using Item_PatternsTest_Actual.ProgramData;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_PatternsTest_Actual.Factories
{
    //Built with the goal of a Factory/Abstract Factory design pattern in mind

    /*I imagine if I wanted to implement something like Object Pooling, I would create Pools of base Items and 
    *run them through the factory to assign them the different items from the "Atlases" in ItemAtlas.cs to change their type, as seen in Program.cs
    *and then when I delete the item in game by either adding it to the player's inventory or despawning it, I nullify the Item and return it to
    *a list/collection of available items in the pool.
    */
    class ItemFactory
    {
        //Establishing ItemFactory to follow a singleton design pattern
        private ItemFactory() { }
        private static ItemFactory instance = null;
        public static ItemFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ItemFactory();
                }
                return instance;
            }
        }

        public Tool ToolFactory(ToolQuality toolQuality, ToolType toolType)
        {
            Tool newTool = null;
            switch (toolType)
            {
                case ToolType.Pickaxe:
                    newTool = new Tool(ItemAtlas.ToolAtlas_Pickaxe[toolQuality].itemInfo, ItemAtlas.ToolAtlas_Pickaxe[toolQuality].toolInfo.Clone());
                    break;
            }
            if(newTool == null)
            {
                Console.Error.WriteLine("Unable to create item " + toolType + " of quality " + toolQuality);
            }
            return newTool;
        }

        public Tool EnchantFactory(EnchantType enchant, Tool toEnchant)
        {
            EnchantedTool enchantedTool = null;
            //check if the toEnchant tool has already been enchanted, part of the temporary solution until I have more time to figure out how to chain enchantments together better.
            if(toEnchant.IsEnchanted() == true)
            {
                Console.Error.WriteLine("Unable to enchant item " + toEnchant.GetItemName() + " as it is already enchanted\n");
                return toEnchant;
            }
            else
            {
                enchantedTool = new EnchantedTool(ItemAtlas.EnchantAtlas[enchant], toEnchant);
                if (enchantedTool == null)
                {
                    Console.Error.WriteLine("Unable to add enchant of type " + enchant + " to tool " + toEnchant.GetItemName());
                    return toEnchant;
                }
                return enchantedTool;
            }
        }

        public Resource ResourceFactory(ResourceType resourceType)
        {
            Resource newResource = null;

            //Fill out newResource by using the ResourceAtlas to get fresh copies of the item that is being requested.
            newResource = new Resource(resourceType, ItemAtlas.ResourceAtlas[resourceType].itemInfo, ItemAtlas.ResourceAtlas[resourceType].stackInfo.Clone());

            if (newResource == null)
            {
                Console.Error.WriteLine("Unable to create item " + resourceType);
            }
            return newResource;
        }
    }
}

//Original Item Factory setup before I slept on it and had a much better idea:

/// <summary>
/// Tools
/// </summary>
/*
//Stone
static ItemBehavior StonePickaxe_Item = new ItemBehavior("Stone Pickaxe", 1, "Gotta start somewhere, right?", 30f);
static ToolBehavior StonePickaxe_Tool = new ToolBehavior(5f, DamageType.Piercing, ToolType.Pickaxe, 100);
//Iron
static ItemBehavior IronPickaxe_Item = new ItemBehavior("Iron Pickaxe", 2, "Simple but Sturdy!", 25f);
static ToolBehavior IronPickaxe_Tool = new ToolBehavior(10f, DamageType.Piercing, ToolType.Pickaxe, 100);
//Steel
static ItemBehavior SteelPickaxe_Item = new ItemBehavior("Steel Pickaxe", 3, "Stronger than the previous version!", 30f);
static ToolBehavior SteelPickaxe_Tool = new ToolBehavior(15f, DamageType.Piercing, ToolType.Pickaxe, 100);
//Mythical
static ItemBehavior MythicalPickaxe_Item = new ItemBehavior("Mythical Pickaxe", 4, "The strongest pickaxe imaginable!", 10f);
static ToolBehavior MythicalPickaxe_Tool = new ToolBehavior(50f, DamageType.Piercing, ToolType.Pickaxe, 100);
*/

/// <summary>
/// Resource Item Behaviors
/// </summary>
/*
static ItemBehavior Wood_Item = new ItemBehavior("Wood", 5, "Simple Wood", 3f);
static ItemBehavior Stone_Item = new ItemBehavior("Stone", 6, "It's not just a boulder... It's a rock!", 5f);
static ItemBehavior Flint_Item = new ItemBehavior("Flint", 7, "It's a rock, but different", 4f);
static ItemBehavior Clay_Item = new ItemBehavior("Clay", 8, "Earth you can mold!", 2f);
*/

/*
public static Tool ToolFactory(ToolQuality toolQuality, ToolType toolType)
{
    Tool newTool = null;
    switch(toolType)
    {
        case ToolType.Axe:
            Console.Error.WriteLine("Haven't gotten around to making this yet");
            break;
        case ToolType.Cultivator:
            Console.Error.WriteLine("Haven't gotten around to making this yet");
            break;
        case ToolType.Hammer:
            Console.Error.WriteLine("Haven't gotten around to making this yet");
            break;
        case ToolType.Pickaxe:
            switch(toolQuality)
            {
                case ToolQuality.Stone:
                    newTool = new Tool(StonePickaxe_Item, StonePickaxe_Tool);
                    break;
                case ToolQuality.Iron:
                    newTool = new Tool(IronPickaxe_Item, IronPickaxe_Tool);
                    break;
                case ToolQuality.Steel:
                    newTool = new Tool(SteelPickaxe_Item, SteelPickaxe_Tool);
                    break;
                case ToolQuality.Mythical:
                    newTool = new Tool(MythicalPickaxe_Item, MythicalPickaxe_Tool);
                    break;
            }
            break;
        case ToolType.Shield:
            Console.Error.WriteLine("Haven't gotten around to making this yet");
            break;
        case ToolType.Torch:
            Console.Error.WriteLine("Haven't gotten around to making this yet");
            break;
    }
    return newTool;
}

public static Resource ResourceFactory(ResourceType resourceType)
{
    Resource newResource = null;
    switch(resourceType)
    {
        case ResourceType.Wood:
            newResource = new Resource(ResourceType.Wood, Wood_Item, FiftyStackMax);
            break;
        case ResourceType.Stone:
            newResource = new Resource(ResourceType.Wood, Stone_Item, TwentyFiveStackMax);
            break;
        case ResourceType.Flint:
            newResource = new Resource(ResourceType.Flint, Flint_Item, SingleStack);
            break;
        case ResourceType.Clay:
            newResource = new Resource(ResourceType.Clay, Clay_Item, TenStackMax);
            break;
    }
    return newResource;
}

 */