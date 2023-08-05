using Item_PatternsTest_Actual.Behaviors;
using Item_PatternsTest_Actual.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_PatternsTest_Actual
{
    class Tool : Item
    {
        protected ToolBehavior toolBehavior;

        //Access info from the ToolBehavior of this object
        //Methods designed to use the Template design pattern, used in Item.cs
        protected override float CalculateItemWeight() { return itemBehavior.GetWeight() + toolBehavior.GetWeightModifier(); }
        protected override string GetItemDescription() { return toolBehavior.GetToolDescription(); }

        public float Damage() { return toolBehavior.GetDamage(); }
        public ToolType ToolType() { return toolBehavior.GetToolType(); }
        public DamageType DamageType() { return toolBehavior.GetDamageType(); }

        //Tool Constructor
        public Tool (ItemBehavior itemInfo, ToolBehavior toolInfo) : base(itemInfo, new StackBehavior(1, false, 1))
        {
            this.toolBehavior = toolInfo;
        }

        //Edit attributes of the ToolBehavior
        public void ModifyDurability(float modifier)
        {
            toolBehavior.ModifyDurability(modifier);
        }
        public void ModifyDamageModifier(float modifier)
        {
            toolBehavior.ModifyDamageModifier(modifier);
        }
        public void ModifyWeightModifier(float modifier)
        {
            toolBehavior.ModifyWeightModifier(modifier);
        }

        //Output the damage of this tool
        public float DealDamage()
        {
            float damageToDeal = 0;
            if (toolBehavior.IsBroken() == true) //if the tool is broken, deal a quarter of the damage it is meant to deal with no modifiers
                damageToDeal = toolBehavior.GetDamage() * .25f;
            else
                damageToDeal = toolBehavior.GetDamage() + toolBehavior.GetDamageModifier();

            return damageToDeal;
        }

        //Clone the tool for copying it's data
        public override Item Clone()
        {
            throw new NotImplementedException();
        }
    }
}
