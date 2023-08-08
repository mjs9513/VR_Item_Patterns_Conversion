using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_PatternsTest_Actual.Behaviors
{
    //Designed with the Strategy pattern in mind
    //ItemBehavior serves as the base for all items in the game
    //I think this might fit the "Flyweight" design pattern, since _name, _id, _description, and _weight are all intrisict to their respective BASE items
    //and don't change (Unless a tool item is decorated as an EnchatedTool for instance, in which case it has an override implementation).
    //I tested this out in Program.cs by changing the name of the Steel Pickaxe item, and that change was reflected to all over Steel Pickaxes
    //that were subsequently created and tested, so the data being referenced is the same for the steel pickaxes.
    //Other Behaviors I created similar to this use a MemberwiseClone() function and the base items in defined in ItemAtlas.cs act as prototypes for future items created in ItemFactory.cs.
    public class ItemBehavior : IItemBehavior
    {
        protected string _name; // All items have an associated name 
        protected int _id; // All items have an associated ID 
        protected string _description; // All items have a description
        protected float _weight; // All items have an associated Weight

        public ItemBehavior(string name, int id, string description, float weight)
        {
            _name = name;
            _id = id;
            _weight = weight;
            _description = description;
        }

        //Methods for accessing the basic info of an item
        public virtual string Name() { return _name; }
        public virtual int GetID() { return _id; }
        public virtual float Weight() { return _weight; }
        public virtual string BaseDescription()
        { //Provide the name and any provided description for the item
            string itemDescription = "\nDescription: " + _description;
            return itemDescription;
        }


        public virtual void ChangeName(string newName) { _name = newName; } //Test function, not meant for the final product.
    }
}
