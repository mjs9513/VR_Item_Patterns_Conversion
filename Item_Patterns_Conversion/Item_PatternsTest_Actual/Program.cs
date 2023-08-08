using System;
using Item_PatternsTest_Actual.Behaviors;
using Item_PatternsTest_Actual.Enums;
using Item_PatternsTest_Actual.Factories;
using Item_PatternsTest_Actual.Items;

namespace Item_PatternsTest_Actual
{//Called this Item_PatternsTest_Actual because I tried porting the original VR game code into 'Item_PatternsTest' straight from Unity and it was a bit of a mess.
    //Testing out different Design Patterns and how they could be used for my VR survival game's item system.
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!\n");
            Console.WriteLine("\n*****TOOL TESTING*****\n");
            //Manual Pickaxe Creation and Tests
            /*Console.WriteLine("Creating an Iron Pickaxe Item manually!");
            Item Iron_Pickaxe = new Tool(ItemAtlas.ToolAtlas_Pickaxe[ToolQuality.Iron].itemInfo, ItemAtlas.ToolAtlas_Pickaxe[ToolQuality.Iron].toolInfo);
            Console.WriteLine("Getting the Description of the Iron Pickaxe!\n");
            Console.WriteLine(Iron_Pickaxe.GetDescription());*/

            //Steel pickaxe creation with the factory
            Console.WriteLine("\nCreating a Steel Pickaxe with the Item Factory\n");
            Tool changingPickaxe = ItemFactory.Instance.ToolFactory(ToolQuality.Steel, ToolType.Pickaxe);
            Console.WriteLine(changingPickaxe.GetDescription());
            Console.WriteLine("\nMaking the Steel Pickaxe lose durability\n");
            changingPickaxe.ModifyDurability(-10f);
            Console.WriteLine(changingPickaxe.GetDescription());

            //Testing what happens when I change the name of the Steel Pickaxe ItemBehavior
            Console.WriteLine("\nChanging the name of Steel Pickaxe to see what happens *TESTING THE FLYWEIGHT DESIGN PATTERN*.\n");
            changingPickaxe.ChangeName("Definitely NOT a Steel Pickaxe");
            Console.WriteLine(changingPickaxe.GetDescription());
            //Test Result: "Definitely NOT a Steel Pickaxe" becomes the name for all steel pickaxes. This makes me wonder if it meets the criteria for the flyweight design pattern
            //Since all Steel Pickaxes are referncing the same ItemBehavior associated with the Steel Pickaxe item.

            /*Item manualSteelPickaxe = ItemFactory.ToolFactory(ToolQuality.Steel, ToolType.Pickaxe);
            Console.WriteLine("\nCreated a new Steel Pickaxe from the ToolFactory, printing out the description of it\n");
            Console.WriteLine(manualSteelPickaxe.GetDescription());*/ // -> Created a new Steel Pickaxe with fresh data for durability different than changingPickaxe, but still had the name change.

            //changing the Steel pickaxe to Mythical and testing it
            Console.WriteLine("\nChanging the Steel Pickaxe to a Mythical Pickaxe\n");
            changingPickaxe = ItemFactory.Instance.ToolFactory(ToolQuality.Mythical, ToolType.Pickaxe);
            Console.WriteLine(changingPickaxe.GetDescription());

            //Changing the Mythical Pickaxe back to Steel
            Console.WriteLine("\nChanging the Mythical Pickaxe back to a Steel One\n");
            changingPickaxe = ItemFactory.Instance.ToolFactory(ToolQuality.Steel, ToolType.Pickaxe);
            Console.WriteLine(changingPickaxe.GetDescription());

            Console.WriteLine("\nChanging the name of 'Definitely NOT a Steel Pickaxe' back to Steel Pickaxe\n");
            changingPickaxe.ChangeName("Steel Pickaxe"); //Chaning the name of the Steel Pickaxe back.
            Console.WriteLine(changingPickaxe.GetDescription());

            Console.WriteLine("\n*****ENCHANT TESTING*****\n");

            Console.WriteLine("Enchanting the current Steel Pickaxe with the Fiery Enchant\n");
            changingPickaxe = ItemFactory.Instance.EnchantFactory(EnchantType.Fiery, changingPickaxe);
            Console.WriteLine(changingPickaxe.GetDescription());

            Console.WriteLine("\nAttempting to enchant the Fiery Steel Pickaxe with the Crushing Enchant\n");
            changingPickaxe = ItemFactory.Instance.EnchantFactory(EnchantType.Crushing, changingPickaxe);
            Console.WriteLine(changingPickaxe.GetDescription());

            //Changing the Fiery Steel Pickaxe back to a regular Steel Pickaxe
            Console.WriteLine("\nChanging the Fiery Steel Pickaxe back to a regular Steel Pickaxe\n");
            changingPickaxe = ItemFactory.Instance.ToolFactory(ToolQuality.Steel, ToolType.Pickaxe);
            Console.WriteLine(changingPickaxe.GetDescription());

            Console.WriteLine("\n*****RESOURCE TESTING*****\n");
            //Using testItem to get items from the ResourceFactory (since Resource extends from Item) and testResource reference the data in testItem to edit it with Resource methods.
            Item testItem;
            Resource testResource;

            //Testing Wood and Stone resources.
            testItem = ItemFactory.Instance.ResourceFactory(ResourceType.Wood);
            Console.WriteLine("Created a piece of wood, printing out the description:\n");
            Console.WriteLine(testItem.GetDescription());
            Console.WriteLine("\nAdding more wood onto the stack of wood:\n");
            testResource = testItem as Resource; // storing the testItem as a Resource so it can be modified using Resource methods
            testResource.ModifyStack(5);
            Console.WriteLine(testItem.GetDescription()); //Printing back out the testItem.GetDescription()

            Console.WriteLine("\nChanging the wood to stone\n");
            testItem = ItemFactory.Instance.ResourceFactory(ResourceType.Stone);
            Console.WriteLine(testItem.GetDescription());
            Console.WriteLine("\nAdding more stone onto the stack of stone:\n");
            testResource = testItem as Resource; // Re-storing the testItem as a Resource so it changes to stone and can be modified using Resource methods
            testResource.ModifyStack(10);
            Console.WriteLine(testItem.GetDescription());

            Console.WriteLine("\nChanging stone back into  wood\n");
            testItem = ItemFactory.Instance.ResourceFactory(ResourceType.Wood);
            Console.WriteLine(testItem.GetDescription()); 
        }
    }
}
