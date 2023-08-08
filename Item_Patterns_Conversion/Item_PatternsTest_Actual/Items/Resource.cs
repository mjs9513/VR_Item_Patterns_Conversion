using Item_PatternsTest_Actual.Behaviors;
using Item_PatternsTest_Actual.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_PatternsTest_Actual.Items
{
    class Resource : Item
    {
        private ResourceType resourceType;
        public Resource(ResourceType resourceType, ItemBehavior itemInfo, StackBehavior stackInfo) : base(itemInfo, stackInfo)
        {
            this.resourceType = resourceType;
        }

        //Methods designed to use the Template design pattern from Item.cs
        public override string GetItemName() { return itemBehavior.Name(); }
        public override string GetItemBaseDescription() { return itemBehavior.BaseDescription(); }
        public override float GetItemWeight() { return itemBehavior.Weight() * stackBehavior.Count(); }
        public override string GetItemStats() { return stackBehavior.GetStackStats(); }

        //Methods for accessing/editing info in the StackBehavior
        public void ModifyStack(int modifier) //Standard method for modifying the count, takes the MAX_STACK into account
        {
            if (stackBehavior.Stackable() == true)
                stackBehavior.ModifyStack(modifier);
        }
        public void SetCount(int newCount) //blanket method for overriding the count for an item
        {
            stackBehavior.SetCount(newCount);
        }
    }
}
