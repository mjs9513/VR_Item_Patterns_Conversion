using System;
using Item_PatternsTest_Actual.Behaviors;
using Item_PatternsTest_Actual.Enums;
using Item_PatternsTest_Actual.Factories;
using Item_PatternsTest_Actual.Interfaces;

namespace Item_PatternsTest_Actual
{//Called this Item_PatternsTest_Actual because I tried porting the original VR game code into 'Item_PatternsTest' straight from Unity and it was a bit of a mess.
    //Testing out different Design Patterns.
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

            //Using testItem to get items from the ResourceFactory (since Resource extends from Item) and testResource reference the data in testItem to edit it with Resource methods.
            Item testItem;
            Resource testResource;

            //Testing Wood and Stone resources.
            testItem = ItemFactory.ResourceFactory(ResourceType.Wood);
            Console.WriteLine("\nCreated a piece of wood, printing out the description:\n");
            Console.WriteLine(testItem.GetDescription());
            Console.WriteLine("\nAdding more wood onto the stack of wood:\n");
            testResource = testItem as Resource; // storing the testItem as a Resource so it can be modified using Resource methods
            testResource.ModifyStack(5);
            Console.WriteLine(testItem.GetDescription()); //Printing back out the testItem.GetDescription()

            Console.WriteLine("\nChanging the wood to stone\n");
            testItem = ItemFactory.ResourceFactory(ResourceType.Stone);
            Console.WriteLine(testItem.GetDescription());
            Console.WriteLine("\nAdding more stone onto the stack of stone:\n");
            testResource = testItem as Resource; // Re-storing the testItem as a Resource so it changes to stone and can be modified using Resource methods
            testResource.ModifyStack(10);
            Console.WriteLine(testItem.GetDescription());

            Console.WriteLine("\nChanging stone back into  wood\n");
            testItem = ItemFactory.ResourceFactory(ResourceType.Wood);
            Console.WriteLine(testItem.GetDescription()); 
        }
    }
}
