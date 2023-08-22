using Item_PatternsTest_Actual.Behaviors;
using Item_PatternsTest_Actual.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_PatternsTest_Actual
{
    //Originally programmed with the Prototype Design Pattern in mind, but I don't think it qualifies as Prototype anymore.
    //This class serves as the base for items in the game. Tool and Resource extend off of it
    public abstract class Item : IDescribable
    {
        protected ItemBehavior itemBehavior; //Using the Strategy Pattern, this handles the basic info of the item such as name, description, weight
        protected StackBehavior stackBehavior; //Using the Strategy Pattern, this handles if an item is stackable and what the total weight is.

        //Accessors for information from itemBehavior
        public int GetID() { return itemBehavior.ID(); }

        //Accessors for information from stackbehavior
        public bool GetStackable() { return stackBehavior.Stackable(); }
        public bool IsMaxStacked() { return stackBehavior.MaxCountReached(); }
        public int GetMaxAmount() { return stackBehavior.MaxCount(); }
        public int GetCurrentCount() { return stackBehavior.Count(); }

        public Item(ItemBehavior itemInfo, StackBehavior stackInfo)
        {
            this.itemBehavior = itemInfo;
            this.stackBehavior = stackInfo;
        }
        public Item() { } //Blank constructor.

        //Using the Template design pattern for getting the description information of an item
        //If my understanding of Tempalte is correct, this fulfills it because GetItemName, GetItemWeight, GetItemStats, and GetItemBaseDescription are abstract and left up to the child
        //class to implement, and GetDescription defined a skeleton that calls whatever the child class methods end up being.
        public abstract string GetItemName();
        public abstract float GetItemWeight();
        public abstract string GetItemStats();
        public abstract string GetItemBaseDescription();
        public virtual string GetDescription()
        {
            string itemDescription = "";
            itemDescription +=
                "Name: " + GetItemName()
                + GetItemBaseDescription()
                +"\nWeight: " + GetItemWeight()
                + GetItemStats();

            return itemDescription;
        }



        public void ChangeName(string newName) { itemBehavior.ChangeName(newName); } //Test function, not meant for the final product. Used for testing the Flyweight design pattern (See ItemBehavior.cs)
    }
}
