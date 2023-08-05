using Item_PatternsTest_Actual.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_PatternsTest_Actual.Blueprints
{
    //Struct used in the ItemFactory for Resources, used for holding the base information for a fresh version of a resource

    /*I think I would actually be able to possibly extend this out to use the Flyweight design pattern?
     *The thinking on that would be that I store these "Blueprint" classes in Tool/Resource itself,
     *But move things like _count for this case in Resource out of the Behavior classes and into the Resource.cs class itself,
     *thus the core unchanging information (MAX_STACK, Stackable) would exist in the Behavior classes and 
     *have their info be accessed through these struct classes, while the changing info would exist in Tool/Resource.cs
     *thus I would only ever need to create one copy of the Blueprint per item, and all Tools/Resources would reference it.
     */
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
