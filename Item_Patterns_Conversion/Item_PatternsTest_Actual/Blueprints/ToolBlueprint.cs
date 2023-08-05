using Item_PatternsTest_Actual.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_PatternsTest_Actual.Blueprints
{
    //Struct used in the ItemFactory for tools, used for holding the base information for a fresh, unmodified, tool
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
