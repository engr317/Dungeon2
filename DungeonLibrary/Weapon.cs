using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Weapon
    {
        /*
         * min max Damage
         * range
         * Weight
         * Two handed
         * durability
         * BonusHitChance
         */

        //Fields
        private int _minDamage;
        private int _maxDamage;
        private string _name;
        private int _bonusHitChance;
        private bool _isTwoHanded;

        //Properties

        public int MaxDamage
        {
            get { return _maxDamage; }
            set { _maxDamage = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int BonusHitChance
        {
            get { return _bonusHitChance; }
            set { _bonusHitChance = value; }
        }

        public bool IsTwoHanded
        {
            get { return _isTwoHanded; }
            set { _isTwoHanded = value; }
        }

        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                //left side of : = if
                //right side of : = else
                _minDamage = value > 0 && value <= MaxDamage ? value : MaxDamage / 2;

                //if ( value > 0 && value < MaxDamage)
                //{
                //    _minDamage = value;
                //} else
                //{
                //    _minDamage = MaxDamage / 2;
                //}
            }
        }

        //Constructor
        public Weapon(string name, int minDamage, int maxDamage, int bonusHitChance, bool isTwoHanded)
        {
            MaxDamage = maxDamage;//Since MinDamage business rules depend on the MaxDamage, set this first.
            MinDamage = minDamage;
            Name = name;
            BonusHitChance = bonusHitChance;
            IsTwoHanded = isTwoHanded;
        }

        public override string ToString()
        {
            return string.Format("{0}\n{1} to {2} damage\n Bonus hit: +{3}\n{4}",
                Name,
                MinDamage,
                MaxDamage,
                BonusHitChance,                
                IsTwoHanded ? "Two-Handed" : "One-Handed");
        }
    }
}
