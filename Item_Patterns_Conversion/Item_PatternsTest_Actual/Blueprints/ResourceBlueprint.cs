using Item_PatternsTest_Actual.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_PatternsTest_Actual.Blueprints
{
    //Struct used in the ItemFactory for Resources, used for holding the base information for a fresh version of a resource
    public struct ResourceBlueprint
    {
        public ItemBehavior itemInfo { get; }
        public StackBehavior stackInfo { get; }
        public ResourceBlueprint(ItemBehavior itmInfo, StackBehavior stckInfo)
        {
            itemInfo = itmInfo;
            stackInfo = stckInfo;
        }
    }
}
