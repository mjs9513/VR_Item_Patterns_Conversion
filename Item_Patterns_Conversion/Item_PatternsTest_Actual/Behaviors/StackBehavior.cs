using Item_PatternsTest_Actual.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_PatternsTest_Actual.Behaviors
{
    //Designed with the Strategy pattern in mind
    public class StackBehavior : IStackable
    {
        protected int MAX_STACK; //maximum number of items that can be stacked
        protected int _count; //current stack count
        protected bool _stackable; //is the item stackable
        public int MaxCount() { return MAX_STACK; }
        public int Count() { return _count; }
        public bool Stackable() { return _stackable; }

        public StackBehavior(int baseCount, bool stackable, int MAX_STACK)
        {
            _count = baseCount;
            _stackable = stackable;
            this.MAX_STACK = MAX_STACK;
        }

        public void ModifyStack(int modifier)
        {
            if (_stackable == true)
                _count = Math.Min(_count += modifier, MAX_STACK);
        }

        public void SetCount(int newCount) //blanket method for overriding the count for an item
        {
            _count = newCount;
        }

        public string GetStackDescription()
        {
            string stackDescription = "Count: " + _count + "/" + MAX_STACK;
            return stackDescription;
        }
    }
}
