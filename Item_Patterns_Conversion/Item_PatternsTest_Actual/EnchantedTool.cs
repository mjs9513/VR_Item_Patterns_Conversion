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
    public class EnchantedTool : Tool, ITool
    {//Acts as another Tool item, 
        protected Tool baseTool; //Base tool to be used with ITool methods
        protected string _enchantName;
        protected float _damageModifier; // Enchanted tools have a damage modifier
        protected float _weightModifier; // Enchanted tools have a weight modifier

        public EnchantedTool(EnchantmentBlueprint enchant, Tool baseTool)
        {
            baseTool.ApplyEnchantment(enchant);
            this.baseTool = baseTool;
            _enchantName = enchant._enchantmentName;
            _damageModifier = Math.Max(enchant._damageModifier, 0);//prevent the weight modifier from going below 0
            _weightModifier = Math.Max(enchant._weightModifier, 0);//prevent the damage modifier from going below 0 
        }
        public override string GetItemName() { return _enchantName + baseTool.GetItemName(); }
        public override bool GetEnchanted() { return baseTool.GetEnchanted();}
        public override float GetItemWeight() { return baseTool.GetItemWeight() + _weightModifier; }
        public override float GetDurability() { return baseTool.GetDurability(); }
        public override bool isBroken() { return baseTool.isBroken(); }
        public override float Damage() { return baseTool.Damage() + _damageModifier; }
        public override ToolType ToolType() { return baseTool.ToolType(); }
        public override DamageType DamageType() { return baseTool.DamageType(); }
        public override float DealDamage() { return baseTool.DealDamage() + _damageModifier; }

        public override string GetDescription()
        {
            return baseTool.GetDescription()
            + "\n---------------------"
            + "\nEnchantment: " + _enchantName
            + "\nDamage Modifier: " + _damageModifier
            + "\nWeight Modifier: " + _weightModifier;
        }
        public override void ModifyDurability(float modifier) 
        { 
            baseTool.ModifyDurability(modifier); 
        }
    }
}
/*
public void ModifyWeightModifier(float modifier) { _weightModifier = Math.Max(_weightModifier + modifier, 0); } //prevent the weight modifier from going below 0
public void ModifyDamageModifier(float modifier) { _damageModifier = Math.Max(_damageModifier + modifier, 0); } //prevent the damage modifier from going below 0 
*/
