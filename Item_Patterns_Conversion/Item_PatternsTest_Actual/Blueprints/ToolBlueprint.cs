using Item_PatternsTest_Actual.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_PatternsTest_Actual.Blueprints
{
    //Struct used in the ItemFactory for tools, used for holding the base information for a fresh, unmodified, tool
    /*I think I would actually be able to possibly extend this out to use the Flyweight design pattern?
     *The thinking on that would be that I store these "Blueprint" classes in Tool/Resource itself,
     *But move things like _durability, _isBroken, _damageModifier, _weightModifier, etc. out of the Behavior classes
     *and into the Tool.cs class itself, thus the core unchanging information would exist in the Behavior classes and 
     *have their info be accessed through these struct classes, while the changing info would exist in Tool/Resource.cs
     *thus I would only ever need to create one copy of the Blueprint per item, and all Tools/Resources would reference it.
     */

    public struct ToolBlueprint
    {
        public ItemBehavior itemInfo { get; }
        public ToolBehavior toolInfo { get; }
        public ToolBlueprint(ItemBehavior itmInfo, ToolBehavior tlInfo)
        {
            itemInfo = itmInfo;
            toolInfo = tlInfo;
        }
    }
}
