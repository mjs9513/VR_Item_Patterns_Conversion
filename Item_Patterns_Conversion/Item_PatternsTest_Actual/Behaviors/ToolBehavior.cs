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
    public class ToolBehavior : ITool
    {
        private float _damage; // all tools have a damage
        private DamageType _damageType; //create a variable associated damage type, some things are more vulnerable than others to certain types of damage
        private ToolType _toolType; // specify the type of tool this is
        private float _durability; //track the health of the item itself.
        private bool _isBroken; //Is the tool broken or not

        private float _damageModifier; // some tools have a damage modifier
        private float _weightModifier; // some tools have a weight modifier

        public float GetDamage() { return _damage; } //return the damage + any damage modifier attached to the tool.
        public DamageType GetDamageType() { return _damageType; } // retrieve the damage type
        public ToolType GetToolType() { return _toolType; }
        public float GetWeightModifier() { return _weightModifier; }
        public float GetDamageModifier() { return _damageModifier; }
        public float GetDurability() { return _durability; }
        public bool IsBroken() { return _isBroken; }
        public string GetToolDescription()
        {
            string toolDescription =
                  "\nDurability: " + GetDurability() + "/100"
                + "\nDamage: " + GetDamage()
                + "\nDamage Type: " + GetDamageType()
                + "\nDamage Modifier: " + GetDamageModifier()
                + "\nWeight Modifier: " + GetWeightModifier();

            return toolDescription;
        }

        public void ModifyWeightModifier(float modifier) 
        {
            _weightModifier = Math.Max(_weightModifier + modifier, 0); //prevent the weight modifier from going below 0
        }
        public void ModifyDamageModifier(float modifier)
        {
            _damageModifier = Math.Max(_damageModifier + modifier, 0); //prevent the damage modifier from going below 0
        }

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
    }
}
