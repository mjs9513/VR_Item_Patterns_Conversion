using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_PatternsTest_Actual.Behaviors
{
    //Designed with the Strategy pattern in mind
    //ItemBehavior serves as the base for all items in the game
    public class ItemBehavior : IItem
    {
        protected string _name; // All items have an associated name 
        protected int _id; // All items have an associated ID 
        protected string _description; // All items have a description
        protected float _weight; // All items have an associated Weight

        public virtual string GetName() { return _name; }
        public virtual int GetID() { return _id; }
        public virtual float GetWeight() { return _weight; }
        public virtual string GetBaseDescription()
        { //Get any provided description for the item, then list the weight in the description.
            string itemDescription = _description + 
                  "\nWeight: " + GetWeight();
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
