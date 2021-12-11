using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Combat
    {

        //This class is just a repository for combat methods

        public static void DoAttack(Character attacker, Character defender)
        {
            //Get a random number from 1-100 as our dice roll
            int diceRoll = new Random().Next(1, 101);
            System.Threading.Thread.Sleep(30);
            if (diceRoll <= (attacker.CalcHitChance() - defender.CalcBlock()))
            {
                //If the attacker hits, calculate the damage
                int damageDealt = attacker.CalcDamage();

                //assign the damage
                defender.Life -= damageDealt;

                //Write the result to the screen
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{attacker.Name} hit {defender.Name} for {damageDealt} damage!");
                Console.ResetColor();
            }//end if
            else
            {
                //The attack missed
                Console.WriteLine($"{attacker.Name} missed!");
            }

        }//end DoAttack()

        public static void DoBattle(PlayerChar player, Monster monster)
        {
            //player attacks first
            DoAttack(player, monster);

            //Monster attacks second, if they're alive
            if (monster.Life > 0)
            {
                DoAttack(monster, player);
            }

        }//end DoBattle()

    }
}
