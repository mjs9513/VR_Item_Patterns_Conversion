using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_PatternsTest_Actual
{
    //Base Item behavior interface
    interface IItemBehavior
    {
        //Defining methods that all items should have
        public string Name();
        public int GetID();
        public float Weight();
        public string BaseDescription();

    }
}