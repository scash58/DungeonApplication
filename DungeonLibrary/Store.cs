using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Store
    {

        //frugal / fields
        //private List<Weapon> _weaponStock;
        //private List<Armor> _armorStock;

        //people / properties
        public List<Weapon> WeaponStock { get; set; }
        public List<Armor> ArmorStock { get; set; }

        //collect / constructors (ctors)

        public Store( List<Weapon> weaponStock, List<Armor> armorStock)
        {
            WeaponStock = weaponStock;
            ArmorStock = armorStock;
        }


        //money / methods

        public override string ToString()
        {
            string weaponStock = "";
            string armorStock = "";
            int i = 1;

            foreach ( Weapon w in WeaponStock)
            {
                weaponStock += $"{i}) {w}\n";
                i++;
            }//end foreach

            i = 1;

            foreach ( Armor a in ArmorStock)
            {                
                armorStock += $"{i}) {a}\n";
                i++;
            }

            return $"\n***** Weapons *****\n" +
                $"{weaponStock}\n" +
                $"***** Armor *****\n" +
                $"{armorStock}\n";

        }

        public Weapon BuyWeapon( int gold, Weapon returnWeapon )
        {
            //Weapon returnWeapon = new Weapon();
            string weaponStock = "";
            int weaponSelection;
            int i = 1;

            foreach (Weapon w in WeaponStock)
            {
                weaponStock += $"{i}) {w}\n";
                i++;
            }//end foreach

            Console.WriteLine($"\n************ Weapons ************\n" +
                $"{weaponStock}\n");

            Console.WriteLine($"You have {gold} gold to buy a weapon for you character.");

            bool weaponNotEquiped = true;

            while (weaponNotEquiped)
            {
                Console.WriteLine("If you do not want a new weapon enter 0.");
                Console.Write("What number weapon do you want? ");
                weaponSelection = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                if (weaponSelection == 0)
                {
                    return returnWeapon;
                }

                returnWeapon = WeaponStock[weaponSelection - 1];

                if (gold > returnWeapon.Cost)
                {

                    weaponNotEquiped = false;
                }
                else
                {
                    Console.WriteLine("The weapon cost too much. Please choose one you can afford.\n");
                }

            }

            return returnWeapon;
        }

        public Armor BuyArmor( int gold, Armor returnArmor )
        {
            bool armorNotEquiped = true;
            //Armor returnArmor = new Armor();
            string armorStock = "";
            int i = 1;

            foreach (Armor a in ArmorStock)
            {
                armorStock += $"{i}) {a}\n";
                i++;
            }

            Console.WriteLine($"************ Armor ************\n" +
                $"{armorStock}\n");

            Console.WriteLine($"You have {gold} gold to buy armor for you character.");

            while (armorNotEquiped)
            {
                Console.WriteLine("If you do not want a new armor enter 0.");
                Console.Write("What number armor do you want? ");
                int armorSelection = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                if (armorSelection == 0)
                {
                    
                    return returnArmor;
                }

                returnArmor = ArmorStock[armorSelection - 1];

                if (gold > returnArmor.Cost)
                {
                    gold -= returnArmor.Cost;
                    armorNotEquiped = false;
                }
                else
                {
                    Console.WriteLine("The armor cost too much. Please choose one you can afford.\n");
                }

            }

            return returnArmor;

        }

    }
}
