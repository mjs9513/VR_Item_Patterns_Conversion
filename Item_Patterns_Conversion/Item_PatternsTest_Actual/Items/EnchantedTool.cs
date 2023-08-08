using Item_PatternsTest_Actual.Blueprints;
using Item_PatternsTest_Actual.Enums;
using Item_PatternsTest_Actual.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_PatternsTest_Actual.Behaviors
{
    //Designed with the Decorator Design pattern in mind
    //ITool is added to ensure the appropriate tool methods are overloaded and re-routed to baseTool. Alternatively, EnchantedTool could
    //Potentially inherit just from the base Item class and still implement the ITool interface potentially? Probably worth testing.
    public class EnchantedTool : Tool, ITool 
    {
        //Base tool to be used with ITool methods
        protected Tool baseTool; 

        //Enchantment Information
        protected string _enchantName = "";
        protected float _damageModifier = 0;
        protected float _weightModifier = 0;

        //Enchanted Tool Contructors
        public EnchantedTool(EnchantmentBlueprint enchant, Tool baseTool)
        {
            this.baseTool = baseTool;
            _enchantName = enchant._enchantmentName;
            _damageModifier = Math.Max(enchant._damageModifier, 0);//prevent the weight modifier from going below 0
            _weightModifier = Math.Max(enchant._weightModifier, 0);//prevent the damage modifier from going below 0 
        }

        //Overloads of Tool methods to re-route them to use baseTool.
        public override float GetItemWeight() { return baseTool.GetItemWeight() + _weightModifier; }
        public override float GetDurability() { return baseTool.GetDurability(); }
        public override float GetDamage() { return baseTool.GetDamage() + _damageModifier; }
        public override DamageType GetDamageType() { return baseTool.GetDamageType(); }
        public override ToolType GetToolType() { return baseTool.GetToolType(); }
        public override bool isBroken() { return baseTool.isBroken(); }
        public override void ModifyDurability(float modifier)
        {
            baseTool.ModifyDurability(modifier);
        }

        //Methods designed for the Template design pattern from Item.cs, get information from the associated behaviors of the item.
        public override string GetItemName() { return _enchantName + " " + baseTool.GetItemName(); }
        public override string GetItemBaseDescription() { return baseTool.GetItemBaseDescription(); }
        public override string GetItemStats()
        {
            string toolStats =
                  "\nDurability: " + GetDurability() + "/100"
                + "\nDamage: " + GetDamage()
                + "\nDamage Type: " + GetDamageType();
            return toolStats;
        }
        public override string GetDescription()
        {//Overriding the GetDescription method to append the Enchantment related information to it.
            return base.GetDescription()
            + "\n---------------------"
            + "\nEnchantment: " + _enchantName
            + "\nDamage Modifier: " + _damageModifier
            + "\nWeight Modifier: " + _weightModifier;
        }

        public override float DealDamage() { return baseTool.DealDamage() + _damageModifier; }
    }
}
/*
public void ModifyWeightModifier(float modifier) { _weightModifier = Math.Max(_weightModifier + modifier, 0); } //prevent the weight modifier from going below 0
public void ModifyDamageModifier(float modifier) { _damageModifier = Math.Max(_damageModifier + modifier, 0); } //prevent the damage modifier from going below 0 
*/
