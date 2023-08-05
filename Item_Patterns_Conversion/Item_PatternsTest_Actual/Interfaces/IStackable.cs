using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_PatternsTest_Actual.Interfaces
{
    //Stackable behavior interface
    interface IStackable
    {
        public abstract bool Stackable();
        public abstract void ModifyStack(int modifier);
        public abstract void SetCount(int newCount);
    }

}
