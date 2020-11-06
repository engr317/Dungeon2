using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Player : Character
    {
        public Race CharacterRace { get; set; }
        public Weapon EquippedWeapon { get; set; }

        public Player(string name, int life, int maxLife, int block, int hitBonus,
                      Weapon equippedWeapon, Race characterRace)
                     : base(name, life, maxLife, block, hitBonus)
        {
            EquippedWeapon = equippedWeapon;
            CharacterRace = characterRace;
            //Switch -> tab -> tab / Type in enum property and hit enter
            switch (CharacterRace)
            {
                case Race.Elf:
                    Block += 5;
                    break;
                case Race.Dwarf:
                    MaxLife += 10;
                    Life += 10;
                    break;
                case Race.Troll:
                    HitBonus += 5;
                    Block -= 5;
                    break;
                case Race.Human:
                    EquippedWeapon.MaxDamage += 2;
                    EquippedWeapon.MinDamage += 2;
                    break;
                case Race.Gnome:
                    HitBonus += 10;
                    Block += 10;
                    break;
                case Race.Halfling:
                    MaxLife += 5;
                    Life += 5;
                    break;
                case Race.Orc:
                    MaxLife += 10;
                    Life += 10;
                    HitBonus += 3;
                    break;
                default:
                    break;
            }//end Switch
        }//end FQCTOR

        public override string ToString()
        {
            return string.Format("******{0}******\nLife: {1} of {2}\nHit Bonus: {3}\nWeapon: {4}\nBlock: {5}\nRace: {6}",
                Name,
                Life,
                MaxLife,
                CalcHitBonus(),
                EquippedWeapon,
                Block,
                CharacterRace);
        }//end ToStirng()

        public override int CalcHitBonus()
        {
            return HitBonus + EquippedWeapon.BonusHitChance;
        }//end CalcHitBonus()

        public override int CalcDamage()
        {
            return new Random().Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage + 1);
        }//end CalcDamage()
    }
}
