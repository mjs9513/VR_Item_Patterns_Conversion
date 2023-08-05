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
        protected override float CalculateItemWeight() { return itemBehavior.GetWeight() * stackBehavior.Count(); }
        protected override string GetItemDescription() { return stackBehavior.GetStackDescription(); }
    }
}
