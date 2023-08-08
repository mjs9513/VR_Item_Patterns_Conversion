using Item_PatternsTest_Actual.Behaviors;
using Item_PatternsTest_Actual.Blueprints;
using Item_PatternsTest_Actual.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_PatternsTest_Actual.ProgramData
{
    public static class ItemAtlas
    {
        //Pre-defining items that can be crafted in the game.

        /// <summary>
        /// Tool Template/Blueprint creation
        /// </summary>
        public static Dictionary<ToolQuality, ToolBlueprint> ToolAtlas_Pickaxe = new Dictionary<ToolQuality, ToolBlueprint>
        {
            {ToolQuality.Stone, new ToolBlueprint(new ItemBehavior("Stone Pickaxe", 1, "Gotta start somewhere, right?", 30f), new ToolBehavior(5f, DamageType.Piercing, ToolType.Pickaxe, 100)) },
            {ToolQuality.Iron, new ToolBlueprint(new ItemBehavior("Iron Pickaxe", 2, "Simple but Sturdy", 25f), new ToolBehavior(10f, DamageType.Piercing, ToolType.Pickaxe, 100)) },
            {ToolQuality.Steel, new ToolBlueprint(new ItemBehavior("Steel Pickaxe", 3, "Stronger than Iron!", 30f), new ToolBehavior(15f, DamageType.Piercing, ToolType.Pickaxe, 100)) },
            {ToolQuality.Mythical, new ToolBlueprint(new ItemBehavior("Mythical Pickaxe", 4, "The strongest pickaxe imaginable!", 10f), new ToolBehavior(50f, DamageType.Piercing, ToolType.Pickaxe, 100)) },
        };

        /// <summary>
        /// Enchant Template/Blueprint creation
        /// </summary>
        public static Dictionary<EnchantType, EnchantmentBlueprint> EnchantAtlas = new Dictionary<EnchantType, EnchantmentBlueprint>
        {
            {EnchantType.Fiery, new EnchantmentBlueprint("Fiery", 5, 2)},
            {EnchantType.Crushing, new EnchantmentBlueprint("Crushing", 10, 5)},
        };

        /// <summary>
        /// Stackable Types, predefining the different stack types that resource items can have.
        /// </summary>
        public static StackBehavior SingleStack = new StackBehavior(1, false, 1);
        public static StackBehavior TenStackMax = new StackBehavior(1, true, 10);
        public static StackBehavior TwentyFiveStackMax = new StackBehavior(1, true, 20);
        public static StackBehavior FiftyStackMax = new StackBehavior(1, true, 50);

        /// <summary>
        /// Resource Template/Blueprint creation
        /// </summary>
        public static Dictionary<ResourceType, ResourceBlueprint> ResourceAtlas = new Dictionary<ResourceType, ResourceBlueprint>
        {
            {ResourceType.Wood, new ResourceBlueprint(new ItemBehavior("Wood", 5, "More than just a stick!", 3f), FiftyStackMax)},
            {ResourceType.Stone, new ResourceBlueprint(new ItemBehavior("Stone", 6, "It's not just a boulder... It's a rock!", 5f), TwentyFiveStackMax)},
            {ResourceType.Flint, new ResourceBlueprint(new ItemBehavior("Flint", 7, "It's a rock, but different!", 4f), TwentyFiveStackMax)},
            {ResourceType.Clay, new ResourceBlueprint(new ItemBehavior("Clay", 8, "Earth you can mold!", 2f), TenStackMax)},
        };
    }
}
