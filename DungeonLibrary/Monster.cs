using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Monster : Character
    {
        private int _minDamage;

        public int MaxDamage { get; set; }
        public string Description { get; set; }
        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                _minDamage = value > 0 && value <= MaxDamage ? value : MaxDamage / 2;
            }//end set
        }//end MinDamage

        
        public Monster(string name, int life, int maxLife, int hitBonus, int block,
                        int minDamage, int maxDamage, string description)
                        : base(name, life, maxLife, block, hitBonus)
        {
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Description = description;
        }//end FQCTOR

        public override string ToString()
        {
            return string.Format("******{0}******\nLife: {1} of {2}\nDamage: {3} to {4}\nBlock: {5}\n{6}",
                Name,
                Life,
                MaxLife,
                MinDamage,
                MaxDamage,
                Block,
                Description);
        }//end ToString()

        public override int CalcDamage()
        {
            return new Random().Next(MinDamage, MaxDamage + 1);
        }//end CalcDamage()
    }
}
