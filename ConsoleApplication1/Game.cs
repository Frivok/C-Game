using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Mime;
using System.Security.Cryptography.X509Certificates;

namespace Adventure
{
    public static class Game
    {

        // variable declaration
        static string characterName = "";
        static string[] items = Item.items;
        static List<string> inventory = Item.Inventory;
 


        public static void Start()
        {
            Title();
            NameCharacter();
            Chapter1();
            Fight();
            EndGame();
            

        }

        static void Title()
        {
            string title = @"
 __          __  _                            _          ____                          _       
 \ \        / / | |                          | |        |  _ \                        (_)      
  \ \  /\  / /__| | ___ ___  _ __ ___   ___  | |_ ___   | |_) | __ _ _ __   __ _ _ __  _  __ _ 
   \ \/  \/ / _ \ |/ __/ _ \| '_ ` _ \ / _ \ | __/ _ \  |  _ < / _` | '_ \ / _` | '_ \| |/ _` |
    \  /\  /  __/ | (_| (_) | | | | | |  __/ | || (_) | | |_) | (_| | | | | (_| | | | | | (_| |
     \/  \/ \___|_|\___\___/|_| |_| |_|\___|  \__\___/  |____/ \__,_|_| |_|\__,_|_| |_|_|\__,_|
                                                                                               
                                                                                               
";
            // change the color to red and write the string title above
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(title);
            // reset the color
            Console.ResetColor();
            
            Console.WriteLine("Press enter to start the game");
            Console.ReadKey();
            Console.Clear();
        }

        static void NameCharacter()
        {
            Console.WriteLine("What would you like your name to be");
            // Console.ReadLine(): Reads the next line of characters entered.
            characterName = Console.ReadLine();

            // Console.ReadKey(): Obtains the next character entered.
            //Console.ReadKey();

            Console.WriteLine("Great your character is now named " + characterName + ". Good luck!\n\n");
            Console.Clear();

        }

        static void Dialog(string message, string color)
        {
            if (color == "red")
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            else if (color == "green")
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine(message);
            Console.ResetColor();
        }
        

        static void Chest()
        {
            {
                if (Character.Luck())
                {
                    Console.WriteLine("Congratulation you unlocked the chest and got a sword !");
                    Character.weaponValue += 1;
                   
                }

                else
                {
                    Console.WriteLine("Looks like your luck isn't good enough you didn't find anything in this chest");
                }
            }
        }
        

        static void Chapter1()
        {
            string input = "";
            Console.WriteLine(characterName + " Which way will you choose? West or East");
            Console.WriteLine("Press A for West anything else for East");
            input = Console.ReadLine();
            input = input.ToUpper();
            Console.Clear();

            // if player press A
            if (input == "A")
            {
                Console.WriteLine("You have chosen West");
                Console.WriteLine("Congratulation you got a " + items[0]);
                inventory.Add(items[0]);
            }

            // if player press something else
            else
            {
                Console.WriteLine("You have chosen East");
                Console.WriteLine("Congratulation you got a " + items[1]);
                inventory.Add(items[1]);
                Chest();
            }
        }

        static void Fight()
        {
          
            int monsterDamage = Monster.monsterAtk - Character.armor;
            int characterAttack = Character.atk + Character.weaponValue;
            
            while (Monster.monsterHp > 0)
            {
                    Console.WriteLine("==========================================");
                    Console.WriteLine("|Hp: " + Character.hp +                 "|");
                    Console.WriteLine("|Potions: " + Character.potions);
                    Console.WriteLine("|Enemy Hp: " + Monster.monsterHp +      "|");
                    Console.WriteLine("|Press A to attack                       |");
                    Console.WriteLine("|Press D to defend                      |");
                    Console.WriteLine("|Press P to use a potion                   |");
                    Console.WriteLine("==========================================");
                    
                    string input = Console.ReadLine();
                    input = input.ToUpper();
                    
                    if (input == "A")
                    {
                        // attack
                        Console.WriteLine("you lose " + Monster.monsterAtk + " hp and deal " + Character.atk + " damage");
                        Monster.monsterHp -= characterAttack; 
                        Character.hp -= monsterDamage;
                    }

                    if (input == "D")
                    {
                        // defend 
                        Console.WriteLine("you defended against the enemy and you lose " + Monster.monsterAtk /2 + " hp");
                        Character.hp -= monsterDamage / 2;
                    }

                    if (input == "P")
                    {
                        // heal
                        if (Character.potions > 0)
                        {
                            Console.WriteLine("You used a potion and gain " + Character.potionValue + " hp");
                            Character.hp += Character.potionValue;
                        }

                        else
                        {
                            
                        }
                    }
                    
                    
                    
                    if (Monster.monsterHp <= 0)
                    {
                        Console.WriteLine("You killed the giant rat");
                        Console.WriteLine("The giant rat dropped 10 gold and a key");
                        Console.WriteLine("You picked up the gold and the key and put it in your inventory");
                        
                        Character.gold += 10;
                        inventory.Add("a key");
                        Console.WriteLine("Gold: " + Character.gold);
                    }

                    if (Character.hp <= 0)
                    {
                        Console.WriteLine("Oh no you died");
                        System.Environment.Exit(0);
                    }
            }
            Console.ReadKey();
        }

        static void EndGame()
        {
            // for each item in inventory display them on the screen
            foreach (string item in inventory)
            {
                Console.WriteLine("Items in your inventory: " + item);
            }
            
            if (inventory.Contains(items[3]))
            {
                Console.WriteLine("Congratulation you slashed the demon king and killed him");
            }

            else
            {
                Console.WriteLine("Bad ending");
            }
            
        }
        
    }
}