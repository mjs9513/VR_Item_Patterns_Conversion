using Item_PatternsTest_Actual.Behaviors;
using Item_PatternsTest_Actual.Blueprints;
using Item_PatternsTest_Actual.Enums;
using Item_PatternsTest_Actual.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_PatternsTest_Actual
{
    public class Tool : Item, ITool
    {
        protected ToolBehavior toolBehavior;

        List<EnchantmentBlueprint> appliedEnchantments;

        protected string appliedEnchantmentNames = "";
        protected float appliedDamageModifiers = 0;
        protected float appliedWeightModifiers = 0;

        //Tool Constructor
        public Tool(ItemBehavior itemInfo, ToolBehavior toolInfo) : base(itemInfo, new StackBehavior(1, false, 1))
        {
            this.toolBehavior = toolInfo;
        }

        public Tool(){}

        public bool ApplyEnchantment(EnchantmentBlueprint newEnchant)
        {
            if (appliedEnchantments == null)
                appliedEnchantments = new List<EnchantmentBlueprint>();
            if(appliedEnchantments.Contains(newEnchant) == false)
            {//This item has not been enchanted with this enchantment yet, apply it.
                appliedEnchantments.Add(newEnchant);
                //Apply the enchantment effects to this item.
                appliedEnchantmentNames += newEnchant._enchantmentName + " ";
                appliedDamageModifiers += newEnchant._damageModifier;
                appliedWeightModifiers += newEnchant._weightModifier;
                return true;
            }
            return false;
        }

        //Methods designed to use the Template design pattern from Item.cs, get information from the associated behaviors of the item.
        public override string GetItemName() { return appliedEnchantmentNames + itemBehavior.GetName(); }
        public override float GetItemWeight() { return itemBehavior.GetWeight() + appliedWeightModifiers; }
        protected override string GetItemDescription() { return toolBehavior.GetToolDescription(); }
       
        
        //public virtual ToolBehavior GetToolBehavior() { return toolBehavior; }
        public virtual float GetDurability() { return toolBehavior.GetDurability(); }
        public virtual bool isBroken() { return toolBehavior.IsBroken(); }

        //Access individual info from the ToolBehavior of this object
        public virtual float Damage() { return toolBehavior.GetDamage() + appliedDamageModifiers; }
        public virtual ToolType ToolType() { return toolBehavior.GetToolType(); }
        public virtual DamageType DamageType() { return toolBehavior.GetDamageType(); }

        //Edit attributes of the ToolBehavior
        public virtual void ModifyDurability(float modifier)
        {
            toolBehavior.ModifyDurability(modifier);
        }

        //Output the damage of this tool
        public virtual float DealDamage()
        {
            float damageToDeal = 0;
            if (toolBehavior.IsBroken() == true) //if the tool is broken, deal a quarter of the damage it is meant to deal with no modifiers
                damageToDeal = toolBehavior.GetDamage() * .25f;
            else
                damageToDeal = toolBehavior.GetDamage();

            return damageToDeal;
        }
    }
}
