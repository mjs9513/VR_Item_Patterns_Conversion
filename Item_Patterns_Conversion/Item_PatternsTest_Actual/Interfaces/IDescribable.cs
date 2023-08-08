using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_PatternsTest_Actual.Interfaces
{
    interface IDescribable
    {
        public abstract string GetItemName();
        public abstract string GetItemBaseDescription();
        public abstract float GetItemWeight();
        public abstract string GetItemStats();
        //public abstract string GetDescription();
    }
}
