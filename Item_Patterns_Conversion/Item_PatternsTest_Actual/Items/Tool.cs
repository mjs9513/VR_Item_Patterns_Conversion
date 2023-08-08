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
        //Using the Strategy Pattern, this handles the basic info of the tool itself
        protected ToolBehavior toolBehavior;

        //Tool Constructors
        public Tool(ItemBehavior itemInfo, ToolBehavior toolInfo) : base(itemInfo, new StackBehavior(1, false, 1))
        {
            this.toolBehavior = toolInfo;
        }
        public Tool(){}

        //Access individual info from the ToolBehavior of this object
        public virtual float GetDurability() { return toolBehavior.Durability(); }
        public virtual float GetDamage() { return toolBehavior.Damage(); }
        public virtual DamageType GetDamageType() { return toolBehavior.DamageType(); }
        public virtual ToolType GetToolType() { return toolBehavior.ToolType(); }
        public virtual bool IsBroken() { return toolBehavior.BrokenStatus(); }

        //Return the enchanted status of the toolBehavior, temporary solution until I have more time to figure out a better way to chain enchants together.
        public virtual bool IsEnchanted() { return toolBehavior.EnchantedStatus(); }
        
        //Edit attributes of the ToolBehavior, should probably renamed to not be confused with the toolBehavior method signature.
        public virtual void ModifyDurability(float modifier) { toolBehavior.ModifyDurability(modifier); }
        public virtual void ModifyEnchantedStatus(bool enchantStatus) { toolBehavior.ModifyEnchantedStatus(enchantStatus); }

        //Methods designed to use the Template design pattern from Item.cs, get information from the associated behaviors of the item.
        public override string GetItemName() { return itemBehavior.Name(); }
        public override string GetItemBaseDescription() { return itemBehavior.BaseDescription(); }
        public override float GetItemWeight() { return itemBehavior.Weight(); }
        public override string GetItemStats() {
            string toolStats =
                  "\nDurability: " + GetDurability() + "/100"
                + "\nDamage: " + toolBehavior.Damage()
                + "\nDamage Type: " + toolBehavior.DamageType();
            return toolStats;
        }

        //Output the damage of this tool
        public virtual float DealDamage()
        {
            float damageToDeal = 0;
            if (toolBehavior.BrokenStatus() == true) //if the tool is broken, deal a quarter of the damage it is meant to deal with no modifiers
                damageToDeal = toolBehavior.Damage() * .25f;
            else
                damageToDeal = toolBehavior.Damage();

            return damageToDeal;
        }
    }
}