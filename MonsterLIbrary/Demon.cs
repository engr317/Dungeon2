using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;

namespace MonsterLIbrary
{
    public class Demon : Monster
    {
        public int EvilMeter { get; set; }
        public bool SummonLesserDemon { get; set; }

        public Demon(string name, int life, int maxLife, int hitBonus, int block,
                     int minDamage, int maxDamage, string description,
                     int evilMeter)
                    : base(name, life, maxLife, hitBonus, block, minDamage, maxDamage, description)
        {
            EvilMeter = evilMeter;
            SummonLesserDemon = false;

            if (EvilMeter >= 75)
            {
                MinDamage += 10;
                MaxDamage += 10;
                HitBonus += 5;
            }
            else if (EvilMeter >= 50)
            {
                MinDamage += 5;
                MaxDamage += 5;
                HitBonus += 2;
            }
            else if (EvilMeter == 0)
            {
                SummonLesserDemon = true;
                Life += 15;
            }
        }//End FQCTOR

        public override string ToString()
        {
            return string.Format("{0}\nEvil Meter: {1}",
                base.ToString(),
                EvilMeter);

        }//End ToString()
    }
}
