using Item_PatternsTest_Actual.Behaviors;
using Item_PatternsTest_Actual.Enums;
using Item_PatternsTest_Actual.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_PatternsTest_Actual.Factories
{
    /* Tool Qualities
    Stone,
    Iron,
    Steel,
    Mythical
     */
    //Built with the goal of a Factory/Abstract Factory design pattern in mind
    class ItemFactory
    {        
        //Pre-defining items that can be crafted in the game. I assume these could be shifted to a separate file/class entirely and listed as static variables within.
        //Any suggestions on how to do this a bit better would be helpful if you have any.
        /// <summary>
        /// Tools
        /// </summary>
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

        /// <summary>
        /// Resource Item Behaviors
        /// </summary>
        static ItemBehavior Wood_Item = new ItemBehavior("Wood", 5, "Simple Wood", 3f);
        static ItemBehavior Stone_Item = new ItemBehavior("Stone", 6, "It's not just a boulder... It's a rock!", 5f);
        static ItemBehavior Flint_Item = new ItemBehavior("Flint", 7, "It's a rock, but different", 4f);
        static ItemBehavior Clay_Item = new ItemBehavior("Clay", 8, "Earth you can mold!", 2f);

        /// <summary>
        /// Stackable Types
        /// </summary>
        static StackBehavior SingleStack = new StackBehavior(1, false, 1);
        static StackBehavior TenStackMax = new StackBehavior(1, true, 10);
        static StackBehavior TwentyFiveStackMax = new StackBehavior(1, true, 20);
        static StackBehavior FiftyStackMax = new StackBehavior(1, true, 50);

        //Two factory methods, one for creating tools and one for resources. I imagine there is probabily a better way to do this than giant switch statements?

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
    }
}
