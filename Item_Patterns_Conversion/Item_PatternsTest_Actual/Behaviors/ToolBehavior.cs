using Item_PatternsTest_Actual.Enums;
using Item_PatternsTest_Actual.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_PatternsTest_Actual.Behaviors
{
    //Designed with the Strategy pattern in mind
    public class ToolBehavior : IToolBehavior
    {
        private float _damage; // all tools have a damage
        private DamageType _damageType; //create a variable associated damage type, some things are more vulnerable than others to certain types of damage
        private ToolType _toolType; // specify the type of tool this is
        private float _durability; //track the health of the item itself.
        private bool _isBroken; //Is the tool broken or not
        

        //Temporary solution until I have more time to work in chaining multiple enchantments to a tool object potentially.
        private bool _isEnchanted = false;
        public bool EnchantedStatus() { return _isEnchanted; }
        public void ModifyEnchantedStatus(bool enchant) { _isEnchanted = enchant; }


        public float Damage() { return _damage; } //return the damage
        public DamageType DamageType() { return _damageType; } // retrieve the damage type
        public ToolType ToolType() { return _toolType; } // What type of tool is it? Going to be used when harvesting resource, (i.e. using an axe against a tree is different than using a pickaxe)
        public float Durability() { return _durability; } //Get the items durability. < 0 and it's considered broken
        public bool BrokenStatus() { return _isBroken; } //Is the durability less than 0?

        public ToolBehavior(float damage, DamageType damageType, ToolType toolType, float durability)
        {
            _damage = damage;
            _damageType = damageType;
            _toolType = toolType;
            _durability = durability;
            if (_durability > 0)
                _isBroken = false;
            else
                _isBroken = true;
        }

        public void ModifyDurability(float modifier)
        {
            _durability = Math.Clamp(_durability += modifier, 0, 100); //edit the durability but only between 0 and 100

            if (_durability <= 0) //if the durability falls to or below 0, set it to broken
                _isBroken = true;
            else
                _isBroken = true; // if the durability is above 0, it is not broken
        }

        //Clone the tool for copying it's data, , using this to fulfill the Prototype Design Pattern
        public ToolBehavior Clone()
        {
            return (ToolBehavior)this.MemberwiseClone();
        }
    }
}
