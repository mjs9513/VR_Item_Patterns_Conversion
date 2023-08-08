using Item_PatternsTest_Actual.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_PatternsTest_Actual.Interfaces
{
    interface ITool
    {   
        //Access individual info from the ToolBehavior of this object
        public abstract float GetDurability();
        public abstract float GetDamage();
        public abstract DamageType GetDamageType();
        public abstract ToolType GetToolType();
        public abstract bool IsBroken();

        //Be able to modify the durability of a ToolBehavior.
        public abstract void ModifyDurability(float modifier);

        //Output the damage of this tool
        public abstract float DealDamage(); 

    }
}
