using System;
using Item_PatternsTest_Actual.Behaviors;
using Item_PatternsTest_Actual.Enums;
using Item_PatternsTest_Actual.Factories;

namespace Item_PatternsTest_Actual
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!\n");

            //Manual Pickaxe Creation and Tests
            Console.WriteLine("Creating an Iron Pickaxe Item manually!");
            Item Iron_Pickaxe = new Tool(new ItemBehavior("Iron Pickaxe", 1, "Simple but Sturdy!", 25f), new ToolBehavior(10f, DamageType.Piercing, ToolType.Pickaxe, 100));
            Console.WriteLine("Getting the Description of the Iron Pickaxe!\n");
            Console.WriteLine(Iron_Pickaxe.GetDescription());


            //Steel pickaxe creation with the factory
            Console.WriteLine("\nCreating a Steel Pickaxe with the Item Factory\n");
            Tool changingPickaxe = ItemFactory.ToolFactory(ToolQuality.Steel, ToolType.Pickaxe);
            Console.WriteLine(changingPickaxe.GetDescription());
            Console.WriteLine("\nMaking the Steel Pickaxe lose durability\n");
            changingPickaxe.ModifyDurability(-10f);
            Console.WriteLine(changingPickaxe.GetDescription());

            //changing the Steel pickaxe to Mythical and testing it
            Console.WriteLine("\nChanging the Steel Pickaxe to a Mythical Pickaxe\n");
            changingPickaxe = ItemFactory.ToolFactory(ToolQuality.Mythical, ToolType.Pickaxe);
            Console.WriteLine(changingPickaxe.GetDescription());

            //Changing the Mythical Pickaxe back to Steel
            Console.WriteLine("\nChanging the Mythical Pickaxe back to a Steel One\n");
            changingPickaxe = ItemFactory.ToolFactory(ToolQuality.Steel, ToolType.Pickaxe);
            Console.WriteLine(changingPickaxe.GetDescription());

            //Testing Wood and Stone resources.
            Item Wood = ItemFactory.ResourceFactory(ResourceType.Wood);
            Console.WriteLine("\nCreated a piece of wood, printing out the description:\n");
            Console.WriteLine(Wood.GetDescription());

            Console.WriteLine("\nChanging the wood to stone\n");
            Wood = ItemFactory.ResourceFactory(ResourceType.Stone);
            Console.WriteLine(Wood.GetDescription());

            //I imagine if I wanted to implement something like Object Pooling, I would create Pools of either: Resources, Tools, Stones, and then I would 
            //Either run them through the factory to change their type like like I did with 'changingPickaxe'? Or would it be more efficient to spawn an instance of every object
            //first, fill out the "Clone" methods I had started building in Tool.cs and Resource.cs and if I needed to spawn a new Pickaxe,
            //use an Item/Tool/Resource from the pool and clone the pre-spawned base pickaxe into it? 
        }
    }
}
