using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public sealed class PlayerChar : Character
    {

        //frugal / fields


        //people / properties

        public Race CharacterRace { get; set; }
        public CharClass CharacterClass { get; set; }
        public Weapon EquippedWeapon { get; set; }
        public Armor EquippedArmor { get; set; }
        public int Gold { get; set; }

        //collect / constructors (ctors)

        public PlayerChar(string name, int hitChance, int block, int life, int maxLife, Race characterRace, CharClass characterClass, 
            Weapon equippedWeapon, Armor equippedArmor, int gold)
        {
            //ASSIGNMENT : PascalCase = camelCase
            MaxLife = maxLife;
            Name = name;
            HitChance = hitChance;
            Block = block;
            Life = life;
            CharacterRace = characterRace;
            CharacterClass = characterClass;
            EquippedWeapon = equippedWeapon;
            EquippedArmor = equippedArmor;
            Gold = gold;

            //BONUS: Customize a prop based off of Race
            switch (CharacterRace)
            {

                case Race.Human:
                    MaxLife += 5;
                    Life += 5;
                    HitChance += 5;
                    break;

                case Race.Halfling:
                    Block += 5;
                    HitChance += 5;
                    break;

                case Race.Gnome:
                    Block += 10;
                    break;

                case Race.HalfOrc:
                    MaxLife += 10;
                    Life += 10;
                    break;

                case Race.Dwarf:
                    MaxLife += 5;
                    Life += 5;
                    Block += 5;
                    break;

                case Race.HalfElf:
                    HitChance += 7;
                    MaxLife += 3;
                    Life += 3;
                    break;

                case Race.Elf:
                    HitChance += 10;
                    break;

            }

            switch (CharacterClass)
            {

                case CharClass.Barbarian:
                    MaxLife += 10;
                    Life += 10;
                    break;

                case CharClass.Cleric:
                    Block += 10;
                    break;

                case CharClass.Fighter:
                    MaxLife += 5;
                    Life += 5;
                    HitChance += 5;
                    break;

                case CharClass.Paladin:
                    HitChance += 5;
                    Block += 5;
                    break;

                case CharClass.Ranger:
                    HitChance += 10;
                    break;

            }

        }//end FQ CTOR

        public PlayerChar() { }

        //money / methods
        public override string ToString()
        {
            string description = "";

            switch (CharacterRace)
            {
                case Race.Dwarf:
                    description = "Dwarf";
                    break;

                case Race.Elf:
                    description = "Elf";
                    break;

                case Race.HalfOrc:
                    description = "Half-Orc";
                    break;

                case Race.Gnome:
                    description = "Gnome";
                    break;

                case Race.Human:
                    description = "Human";
                    break;

                case Race.Halfling:
                    description = "Halfling";
                    break;

                case Race.HalfElf:
                    description = "Half-Elf";
                    break;

            }//end switch

            switch (CharacterClass)
            {

                case CharClass.Barbarian:
                    description += " Barbarian";
                    break;

                case CharClass.Cleric:
                    description += " Cleric";
                    break;
                case CharClass.Fighter:
                    description += " Fighter";
                    break;

                case CharClass.Paladin:
                    description += " Paladin";
                    break;

                case CharClass.Ranger:
                    description += " Ranger";
                    break;

            }

            return $"-=-= {Name} =-=-\n" +
                $"Life: {Life} / {MaxLife}\n" +
                $"Hit Chance: {CalcHitChance()}%\n" +
                $"Weapon: {EquippedWeapon}\n" +
                $"Armor: {EquippedArmor}\n" +
                $"Block: {Block}\n" +
                $"Gold: {Gold}\n" +
                $"Description: {description}\n";

        }//end ToString() Override

        public override int CalcDamage()
        {
            //return base.CalcDamage();
            //Create a random object
            Random rand = new Random();

            //determine damage
            int damage = rand.Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage + 1);

            //return the damage
            return damage;

        }//end CalcDamage()

        public override int CalcHitChance()
        {
            return base.CalcHitChance() + EquippedWeapon.BonusHitChance;
        }//end CalcHitChance()

        public Race ChooseRace()
        {

            string choosenRace = "";

            Console.WriteLine($"**************** PLAYER RACE ****************\n" +
                $"1)Human:\t\tMax Life 5\tHit Chance 5\n" +
                $"2)Halfling:\t\tHit Chance 5\tBlock 5\n" +
                $"3)Gnome:\t\tBlock 10\n" +
                $"4)Half-Orc:\t\tMax Life 10\n" +
                $"5)Dwarf:\t\tMax Life 5\tBlock 5\n" +
                $"6)Half-Elf:\t\tHit Chance 7\tMax Life 3\n" +
                $"7)Elf:\t\t\tHit Chance 10\n");

            Console.Write("Which Charater Race would you like to play?: ");
            choosenRace = Console.ReadLine();
            Console.WriteLine();

            switch (choosenRace)
            {
                case "1":
                    return Race.Human;
                    
                case "2":
                    return Race.Halfling;

                case "3":
                    return Race.Gnome;

                case "4":
                    return Race.HalfOrc;

                case "5":
                    return Race.Dwarf;

                case "6":
                    return Race.HalfElf;

                case "7":
                    return Race.Elf;

                default:
                    return Race.Human;

            }//end switch

        }

        public CharClass ChooseClass()
        {

            string choosenClass = "";

            Console.WriteLine($"**************** PLAYER CLASS ****************\n" +
                $"1)Barbarian:\t\tMax Life 10\n" +
                $"2)Cleric:\t\tBlock 10\n" +
                $"3)Fighter:\t\tMax Life 5\tHit Chance 5\n" +
                $"4)Paladin:\t\tHit Chance 5\tBlock 5\n" +
                $"5)Ranger:\t\tHit Chance 10\n");

            Console.Write("Which Charater Race would you like to play?: ");
            choosenClass = Console.ReadLine();
            Console.WriteLine();

            switch (choosenClass)
            {
                case "1":
                    return CharClass.Barbarian;

                case "2":
                    return CharClass.Cleric;

                case "3":
                    return CharClass.Fighter;

                case "4":
                    return CharClass.Paladin;

                case "5":
                    return CharClass.Ranger;

                default:
                    return CharClass.Fighter;

            }//end switch

        }

    }
}
