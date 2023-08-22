using Item_PatternsTest_Actual.Interfaces;
using Item_PatternsTest_Actual.Items;
using System;
using System.Collections.Generic;
using System.Linq; //Use linq methods to try and optimize
using System.Text;
using System.Threading.Tasks;

namespace Item_PatternsTest_Actual.Behaviors
{
    class StorageBehavior : IStorage
    {
        protected string _storageName;
        protected List<Item> _storageInventory;
        protected int MAX_SIZE;
        public StorageBehavior(int size, string name)
        {
            _storageName = name;
            MAX_SIZE = size;
            _storageInventory = new List<Item>(size);
                //new Item[size];
        }
        public int GetStorageUsed() { return _storageInventory.Count; }
        public int GetStorageMaxSize() { return _storageInventory.Capacity; }
        public string GetStorageName() { return _storageName; }

        public string GetStorageInfo()
        {
            string storageInfo = "*Storage: " + GetStorageName() + "*"
                + "\nStorage Capacity: " + GetStorageUsed() + "/" + GetStorageMaxSize()
                + "\nItems:\n";
            foreach (Item itm in _storageInventory)
            {
                if(itm != null)
                    storageInfo += itm.GetDescription() + "\n";
            }
            return storageInfo;
        }

        public void AddItem(Item toPickup)
        {
            int currSize = _storageInventory.Count;
            if (currSize >= _storageInventory.Capacity)
            {
                Console.WriteLine("Unable to add an item to this inventory. The current size is: " + currSize + ", the MAX size is: " + _storageInventory.Capacity);
                return;
            }

            //Check if the item being added is stackable.
            bool isStackable = toPickup.GetStackable();

            if (isStackable == true)
            {//If it is, see if the storage has an item of that type already
                Item locatedMatch = null;
                bool validMatch = _storageInventory.Any(check =>
                {
                    if (check.GetID() == toPickup.GetID() && !check.IsMaxStacked())
                    {//Check for matching IDs that are not at max stack
                        if (check.GetCurrentCount() + toPickup.GetCurrentCount() <= check.GetMaxAmount())
                        {//Ensure that item found with matching IDs and is not max stacked can facilitate adding the new item's count
                            locatedMatch = check;
                            return true;
                        }
                    }
                    return false;
                });

                if (validMatch == true && locatedMatch != null)
                {// if it does add the counts.
                    Resource itemAsResource = (Resource)locatedMatch;
                    itemAsResource.ModifyStack(toPickup.GetCurrentCount());
                    toPickup = null;
                }
                else
                {//Add new item entry
                    AddItemEntry(toPickup);
                    toPickup = null;
                }
            }
            else
            {//If not, add it as a new entry.
                AddItemEntry(toPickup);
                toPickup = null;
            }
        }

        public string GetItemInfo(int invSlot)
        {
            if (_storageInventory[invSlot] == null)
            {
                Console.WriteLine("Unable to drop item from inventory at slot: " + invSlot + ", no item detected");
                return null;
            }
            string itemInfo = "IN STORAGE\n"
                + _storageInventory[invSlot].GetDescription();
            return itemInfo;
        }

        public Item DropItem(int invSlot)
        {
            if (_storageInventory[invSlot] == null)
            {
                Console.WriteLine("Unable to drop item from inventory at slot: " + invSlot + ", no item detected");
                return null;
            }
            Item toDrop = _storageInventory[invSlot];
            _storageInventory[invSlot] = null;
            return toDrop;
        }

        public void RemoveItem(int invSlot)
        {
            if (_storageInventory[invSlot] == null)
            {
                Console.WriteLine("Unable to drop item from inventory at slot: " + invSlot + ", no item detected");
                return;
            }
            _storageInventory[invSlot] = null;
        }

        private void AddItemEntry(Item toPickup)
        {
            try
            {
                _storageInventory.Add(toPickup);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred when trying to add an item to this storage. Error: " + ex.Message);
            }
        }
    }
}
