using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_PatternsTest_Actual
{
    //Base Item behavior interface
    interface IItem
    {
        //Defining methods that all items should have
        public string GetName();
        public int GetID();
        public float GetWeight();
        public string GetBaseDescription();

    }
}