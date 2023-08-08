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
        public abstract float GetDurability();
        public abstract bool isBroken();

        //Access individual info from the ToolBehavior of this object
        public abstract float Damage();
        public abstract ToolType ToolType();
        public abstract DamageType DamageType();
        public abstract void ModifyDurability(float modifier);

        //Output the damage of this tool
        public abstract float DealDamage(); 

    }
}
