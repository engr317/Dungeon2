using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public abstract class Character
    {
        private int _life;

        public string Name { get; set; }
        public int MaxLife { get; set; }
        public int Block { get; set; }
        public int HitBonus { get; set; }
        public int Life
        {
            get { return _life; }
            set
            {
                _life = value <= MaxLife ? value : MaxLife;
            }
        }

        public Character(string name, int life, int maxLife, int block, int hitBonus)
        {
            Name = name;
            MaxLife = maxLife;
            Life = life;
            Block = block;
            HitBonus = hitBonus;
        }

        //We won't write a ToString() because we will out unique outputs for the Player and Monster Classes

        public virtual int CalcBlock()
        {
            return Block;
        }

        //MINI-LAB!
        //Build the CalcHitBonus to return HitBonus
        //and CalcDamage method to return 0.
        //Make it to where we can change it later in our child classes. 

        public virtual int CalcHitBonus()
        {
            return HitBonus;
        }

        public virtual int CalcDamage()
        {
            return 0;
        }
    }
}
