using Item_PatternsTest_Actual.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_PatternsTest_Actual
{
    //Programmed with the Prototype Design Pattern in mind.
    public abstract class Item
    {
        protected ItemBehavior itemBehavior; //Using the Strategy Pattern, this handles the basic info of the item such as name, description, weight
        protected StackBehavior stackBehavior; //Using the Strategy Pattern, this handles if an item is stackable and what the total weight is.

        public string GetName() { return itemBehavior.GetName(); }
        public int GetID() { return itemBehavior.GetID(); }


        //Using the Template design pattern for calculating the weight of an item and getting the description of an item
        protected abstract float CalculateItemWeight();
        public float GetWeight() { return CalculateItemWeight(); }
        protected abstract string GetItemDescription();
        public string GetDescription() { return itemBehavior.GetBaseDescription() + GetItemDescription(); }


        //Methods that access the StackBehavior of the item.
        public virtual int GetCount() { return stackBehavior.Count(); }
        public virtual int GetMaxCount() { return stackBehavior.MaxCount(); }

        public Item(ItemBehavior itemInfo, StackBehavior stackInfo)
        {
            this.itemBehavior = itemInfo;
            this.stackBehavior = stackInfo;
        }

        public abstract Item Clone();
    }
}
