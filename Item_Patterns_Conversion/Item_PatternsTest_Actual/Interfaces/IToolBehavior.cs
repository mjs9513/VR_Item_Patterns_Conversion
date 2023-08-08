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
        public abstract float Damage(); //return the damage
        public abstract DamageType DamageType(); //retrieve the damage type
        public abstract ToolType ToolType(); //What type of tool is it? Going to be used when harvesting resource, (i.e. using an axe against a tree is different than using a pickaxe)
        public abstract float Durability(); //Get the items durability. < 0 and it's considered broken
        public abstract bool IsBroken(); //Is the durability less than 0?
        public abstract void ModifyDurability(float modifier); //Modify the durability of the item, used when the item takes damage.
    }
}
