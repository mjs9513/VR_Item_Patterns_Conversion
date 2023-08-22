using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_PatternsTest_Actual.Interfaces
{
    interface IDescribable
    {
        //Methods necessary for providing the descriptive information of an item.
        //Used with the Template design pattern implemented in Item.cs
        public abstract string GetItemName();
        public abstract int GetID();
        public abstract string GetItemBaseDescription();
        public abstract float GetItemWeight();
        public abstract string GetItemStats();
    }
}
