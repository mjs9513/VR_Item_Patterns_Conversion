using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_PatternsTest_Actual.Blueprints
{
    public struct EnchantmentBlueprint
    {
        public string _enchantmentName;
        public float _damageModifier;
        public float _weightModifier;

        public EnchantmentBlueprint(string enchantName, float damageMod, float weightMod)
        {
            _enchantmentName = enchantName;
            _damageModifier = damageMod;
            _weightModifier = weightMod;
        }
    }
}
