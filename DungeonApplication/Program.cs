using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DungeonLibrary;//added
using DungeonMonster;//added

namespace DungeonApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<Weapon> weaponStock = new List<Weapon>();
            List<Armor> armorStock = new List<Armor>();
            Weapon equippedWeapon = new Weapon();
            Armor equippedArmor = new Armor();
            PlayerChar defaultPlayer = new PlayerChar();

            //Weapon declaration to be added to the store
            Weapon shortSword = new Weapon(1, 6, "Short Sword", 10, false, 20);
            Weapon longSword = new Weapon(1, 8, "Long Sword", 10, false, 30);
            Weapon greatSword = new Weapon(2, 12, "Great Sword", 10, true, 140);
            Weapon battleAxe = new Weapon(1, 8, "Battleaxe", 10, false, 30);
            Weapon greatAxe = new Weapon(1, 12, "Greataxe", 10, true, 120);

            weaponStock.Add(shortSword);
            weaponStock.Add(longSword);
            weaponStock.Add(greatSword);
            weaponStock.Add(battleAxe);
            weaponStock.Add(greatAxe);

            //Armor declaration to be added to the store
            Armor studdedLeather = new Armor("Studded Leather", 3, 3, 50);
            Armor chainMail = new Armor("Chain Mail", 5, 5, 100);
            Armor halfPlate = new Armor("Half-Plate", 7, 7, 200);
            Armor fullPlate = new Armor("Full-Plate", 10, 10, 250);

            armorStock.Add(studdedLeather);
            armorStock.Add(chainMail);
            armorStock.Add(halfPlate);
            armorStock.Add(fullPlate);

            //Store declaration with it weaponStock and armorStock
            Store store = new Store(weaponStock, armorStock);
            string title = "Dungeon Crawler";

            Console.Title = title;
            Console.WriteLine("{0," +
                ((Console.WindowWidth / 2) + title.Length / 2) + "}", title);

            Console.WriteLine("In this adventure you will enter a dungeon and go room to room.");
            Console.WriteLine("Your character will encounter monsters along the way. You can");
            Console.WriteLine("fight your way through them or run away. Your score is equal to");
            Console.WriteLine("the number of monsters defeated.");

            Console.WriteLine("Your journey begins....\n");

            Console.Write("Enter your characters name: ");
            string charName = Console.ReadLine();

            int gold = 200;

            equippedWeapon = store.BuyWeapon(gold);
            gold -= equippedWeapon.Cost;
            equippedArmor = store.BuyArmor(gold);
            gold -= equippedArmor.Cost;


            PlayerChar player = new PlayerChar(charName, 70, 5, 40, 40, defaultPlayer.ChooseRace(), 
                defaultPlayer.ChooseClass(), equippedWeapon, equippedArmor, gold );

            Console.Clear();

            Console.WriteLine(player.ToString());

            
            //TODO 03 Create monster class and subclasses
            
            
            //TODO 08 Create a Dungeon room w/monster, loot, ect.
            //TODO 09 Make interface for the Dungeon
            //TODO 10 Do combat
            //TODO 11 make a scoring/experience system



        }
    }
}
