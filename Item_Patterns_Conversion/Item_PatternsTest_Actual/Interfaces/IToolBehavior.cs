using Item_PatternsTest_Actual.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_PatternsTest_Actual.Interfaces
{
    //Tool behavior interface
    interface IToolBehavior
    {
        public abstract float GetDamage(); //return the damage + any damage modifier attached to the tool.
        public abstract DamageType GetDamageType(); // retrieve the damage type
        public abstract ToolType GetToolType(); 
        public abstract float GetDurability();
        public abstract bool IsBroken();
        public abstract void ModifyDurability(float modifier);

        //public abstract string GetToolDescription();
    }
}
