using DungeonLibrary;//added
using DungeonMonster;//added
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            int score = 0;

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
                defaultPlayer.ChooseClass(), equippedWeapon, equippedArmor, gold);

            Console.Clear();

            Console.WriteLine(player.ToString());

            Wolf wolf1 = new Wolf();//uses the default ctor, creates a young wolf

            Wolf wolf2 = new Wolf("Mackenzie Valley Wolf", 30, 30, 50, 20, 2, 10, 5,
                "That is one huge wolf! He looks very angry", 15, true);

            Bat bat1 = new Bat();//uses the default ctor, creates a small bat

            Bat bat2 = new Bat("Vampire Bat", 30, 30, 50, 20, 2, 10, 5,
                "That is one big bat.", 10, true);

            Bear bear1 = new Bear();//uses the default ctor, creates a black bear

            Bear bear2 = new Bear("Grizzly Bear", 30, 30, 50, 20, 2, 10, 5,
                "That is a big bear!", 20, true);

            Monster[] baseMonsters = { wolf1, wolf1, bat1, bat1, bear1, bear1 };
            Monster[] bossMonsters = { wolf2, bat2, bear2 };

            Monster currentMonster = new Monster();


            bool exit = false;

            do //This loop is for the whole charater instance
            {
                player.Life = player.MaxLife; //makes sure player health is full prior to entering a new dungeon

                bool reload = false;

                do //This loop is for the dungeon instance
                {

                    for (int i = 1; i <= 5; i++) //This is a five room dungeon with a bose fight
                    {



                        if (i == 5)
                        {
                            Console.WriteLine("This is the bose fight.");
                            int randomIndexBoss = new Random().Next(bossMonsters.Length);
                            currentMonster = bossMonsters[randomIndexBoss];
                            Console.WriteLine(Dungeon.printDungeon(currentMonster));
                        }
                        else
                        {
                            Console.WriteLine("Just a normal fight.");
                            int randomIndexBase = new Random().Next(baseMonsters.Length);
                            currentMonster = baseMonsters[randomIndexBase];
                            Console.WriteLine(Dungeon.printDungeon(currentMonster));
                        }

                        bool monsterDied = false;

                        do //for monster fight
                        {



                            Console.WriteLine(@"
Please choose an action:
A)Attack
R)Run Away
P)Player Info
M)Monster Info
X)Exit
");

                            string userChoice = Console.ReadKey(true).Key.ToString();

                            Console.Clear();

                            switch (userChoice)
                            {
                                case "A":

                                    Console.WriteLine("Attack Method Goes Here..");

                                    Combat.DoBattle(player, currentMonster);

                                    //Handle if the user wins
                                    if (currentMonster.Life <= 0)
                                    {

                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("\nYou killed {0}!\n", currentMonster.Name);
                                        Console.ResetColor();
                                        monsterDied = true;
                                        score += currentMonster.MonsterScore;
                                        player.Gold += currentMonster.GoldReward;
                                    }
                                    break;

                                case "R":
                                    //Give the monster a free attack
                                    Console.WriteLine("Run Away!!:");
                                    Console.WriteLine($"{currentMonster.Name} attacks as you flee!");
                                    Combat.DoAttack(currentMonster, player);//free attack
                                    Console.WriteLine();
                                    monsterDied = true; //monster did not die but we need to escape the fight loop
                                    reload = true; //"re"load a new room
                                    break;

                                case "P":
                                    Console.WriteLine("Player Info:");
                                    //Display Player info
                                    Console.WriteLine(player);
                                    Console.WriteLine("Monsters slain: " + score);
                                    break;

                                case "M":
                                    Console.WriteLine("Monster Info");
                                    //Display Monster info:
                                    Console.WriteLine(currentMonster);//this will use 
                                                                      //polymorphism to get the correct ToString
                                    break;

                                case "X":
                                case "E":
                                case "Escape":
                                    Console.WriteLine("No one likes a quitter....");
                                    i = 6;
                                    monsterDied = true; //monster did not die but need to escape fight loop
                                    reload = true; // need to escape dungeon loop
                                    exit = true; //
                                    break;

                                default:
                                    Console.WriteLine("Thou hast chosen an invalid option.");
                                    break;
                            }//end switch

                            //Check Player Life
                            if (player.Life <= 0)
                            {
                                Console.WriteLine("Dude... you died!\a");
                                exit = true;
                            }//end if player is dead!

                        } while (!monsterDied);
                    }

                    bool newDungeon = false;

                    if (exit == true)
                    {
                        newDungeon = true;
                    }                    

                    do
                    {



                        Console.WriteLine(@"
Please choose an action:
S)Store
N)New Dungeon
P)Player Info
X)Exit
");
                        string storeChoice = Console.ReadKey(true).Key.ToString();

                        switch (storeChoice)
                        {
                            case "S":
                                Console.WriteLine("If you buy a new piece of equipment we buy any old equipment for one quarter of it original cost.");
                                equippedWeapon = store.BuyWeapon(player.Gold);
                                if (equippedWeapon != player.EquippedWeapon) //test if the player bought a new weapon
                                {
                                    player.Gold += (int)(player.EquippedWeapon.Cost * .25); //The player sells their original weapon
                                    player.Gold -= equippedWeapon.Cost; //Buys the new weapon
                                    player.EquippedWeapon = equippedWeapon; //Equips the new weapon
                                }
                                
                                equippedArmor = store.BuyArmor(player.Gold);
                                if (equippedArmor != player.EquippedArmor) //Test if the player bought a new armor
                                {
                                    player.Gold += (int)(player.EquippedArmor.Cost * .25); //The player sells their orginal Armor
                                    player.Gold -= equippedArmor.Cost; //Buys the new Armor
                                    player.EquippedArmor = equippedArmor; //Equips the new Armor
                                }
                                
                                break;

                            case "N":
                                newDungeon = true;
                                break;

                            case "P":
                                Console.WriteLine("Player Info:");
                                //Display Player info
                                Console.WriteLine(player);
                                Console.WriteLine("Monsters slain: " + score);
                                break;

                            case "X":
                            case "E":
                            case "Escape":
                                Console.WriteLine("No one likes a quitter....");
                                newDungeon = true;
                                reload = true;
                                exit = true;
                                break;

                            default:
                                Console.WriteLine("Thou hast chosen an invalid option.");
                                break;
                        }

                    } while (!newDungeon);



                } while (!reload && !exit);
                //While reload and(&&) exits is BOTH NOT TRUE, keep looping
                //If reload is true, leave the inner loop. If exit is true, leave both loops.

            } while (!exit);//While exit is NOT TRUE, keep looping

            Console.WriteLine($"" +
                $"You defeated {score:n0} monster{(score == 1 ? "." : "s")}");


        }
    }
}
