using Item_PatternsTest_Actual.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_PatternsTest_Actual.Interfaces
{
    //Storage behavior interface
    interface IStorage
    {
        public abstract void AddItem(Item toPickup);
        public abstract void RemoveItem(int invSlot);
        public abstract Item DropItem(int invSlot);

        public abstract int GetStorageUsed();
        public abstract int GetStorageMaxSize();

        public abstract string GetItemInfo(int invSlot);

        public abstract string GetStorageInfo();
    }
}
