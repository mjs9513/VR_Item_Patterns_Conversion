using System;
using Item_PatternsTest_Actual.Behaviors;
using Item_PatternsTest_Actual.Enums;

namespace Item_PatternsTest_Actual
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!\n");
            Console.WriteLine("Creating an Iron Pickaxe Item manually!\n");
            Tool Iron_Pickaxe = new Tool(new ItemBehavior("Iron Pickaxe", 1, "Simple but Sturdy!", 25f), new ToolBehavior(10f, DamageType.Piercing, ToolType.Pickaxe, 100));
            Console.WriteLine("Getting the Description of the Iron Pickaxe!\n");
            Console.WriteLine(Iron_Pickaxe.GetDescription());
        }
    }
}
