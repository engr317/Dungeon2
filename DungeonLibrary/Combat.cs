using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Combat
    {
        public static void DoAttack(Character attacker, Character defender)
        {
            //Get a random number from 1-20 as our dice roll
            int diceRoll = new Random().Next(1, 21);
            System.Threading.Thread.Sleep(30);
            if (diceRoll + attacker.CalcHitBonus() >= defender.CalcBlock())
            {
                //If the attacker hit calculate the damage
                int damageDealt = attacker.CalcDamage();

                //Assign the damage
                defender.Life -= damageDealt;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0} hit {1} for {2} damage!",
                    attacker.Name,
                    defender.Name,
                    damageDealt);

                Console.ResetColor();
            }//end if attacker hit
            else
            {
                Console.WriteLine("{0} missed!", attacker.Name);
            }//end else
        }//end DoAttack()

        public static void DoBattle(Player player, Monster monster)
        {
            DoAttack(player, monster);

            if (monster.Life > 0)
            {
                DoAttack(monster, player);
            }//end if
        }//end DoBattle()
    }
}
