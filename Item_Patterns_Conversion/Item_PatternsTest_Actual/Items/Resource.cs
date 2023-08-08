using Item_PatternsTest_Actual.Behaviors;
using Item_PatternsTest_Actual.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_PatternsTest_Actual.Interfaces
{
    class Resource : Item
    {
        private ResourceType resourceType;
        public Resource(ResourceType resourceType, ItemBehavior itemInfo, StackBehavior stackInfo) : base(itemInfo, stackInfo)
        {
            this.resourceType = resourceType;
        }

        //Methods designed to use the Template design pattern from Item.cs
        public override string GetItemName() { return itemBehavior.GetName(); }
        public override string GetItemBaseDescription() { return itemBehavior.GetBaseDescription(); }
        public override float GetItemWeight() { return itemBehavior.GetWeight() * stackBehavior.Count(); }
        public override string GetItemStats() { return stackBehavior.GetStackStats(); }
        public override string GetDescription()
        {
            return "Name: " + GetItemName()
            + GetItemBaseDescription()
            + "\nWeight: " + GetItemWeight() //The implementation of GetItemWeight varies between Tools and Resources, this is one of the reasons I abstracted out "GetDescription" from the base Item Class.
            + GetItemStats();
        }

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
