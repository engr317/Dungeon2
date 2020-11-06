using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;

namespace MonsterLIbrary
{
    public class Dragon : Monster
    {
        public int EvilMeter { get; set; }
        public bool SummonLesserDemon { get; set; }

        public Dragon(string name, int life, int maxLife, int hitBonus, int block,
                     int minDamage, int maxDamage, string description,
                     int evilMeter)
                    : base(name, life, maxLife, hitBonus, block, minDamage, maxDamage, description)
        {
            EvilMeter = evilMeter;
            SummonLesserDemon = false;

            if (EvilMeter >= 75)
            {
                MinDamage += 5;
                MaxDamage += 15;
                HitBonus += 5;
            }
            else if (EvilMeter >= 50)
            {
                MinDamage += 20;
                MaxDamage += 20;
                HitBonus += 2;
            }
            else if (EvilMeter == 10)
            {
                SummonLesserDemon = false;
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
