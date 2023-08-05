using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_PatternsTest_Actual.Behaviors
{
    //Designed with the Strategy pattern in mind
    //ItemBehavior serves as the base for all items in the game
    //I think this might fit the "Flyweight" design pattern, since _name, _id, _description, and _weight are all intrisict to their respective items
    //and don't change. I tested this out in Program.cs by changing the name of the Steel Pickaxe item, and that change was reflected to all over Steel Pickaxes
    //that were subsequently created and tested, so the data being referenced is the same for the steel pickaxes.
    //Other Behaviors I created for this use a MemberwiseClone() function and the base items in ItemFactory.cs act as prototypes for future items created.
    public class ItemBehavior : IItem
    {
        protected string _name; // All items have an associated name 
        protected int _id; // All items have an associated ID 
        protected string _description; // All items have a description
        protected float _weight; // All items have an associated Weight

        //Methods for accessing the basic info of an item
        public virtual void ChangeName(string newName) { _name = newName; } //Test function, not meant for the final product.
        public virtual string GetName() { return _name; }
        public virtual int GetID() { return _id; }
        public virtual float GetWeight() { return _weight; }

        public virtual string GetBaseDescription()
        { //Provide the name and any provided description for the item
            string itemDescription = "Name: " + _name +
                    "\nDescription: " + _description;
            return itemDescription;
        }

        public ItemBehavior(string name, int id, string description, float weight)
        {
            _name = name;
            _id = id;
            _weight = weight;
            _description = description;
        }
    }
}
