using System;

namespace Adventure
{
     class Character
    {
        // character stats
        public static int luck = 5;
        public static int hp = 10;
        public static int atk = 2;
        public static int weaponValue = 0;
        public static int armor = 0;
        public static int potions = 5;
        public static int potionValue = 4;
        public static int gold = 0;
        
        // create new random class called randomNumber
        static Random randomNumber = new Random();

        public static bool Luck()
        {
            // requirement is a random number between 0 and 10
            int requirement = randomNumber.Next(1,10);
            
            // result is false by default
            bool result = false;
            
            // if luck is superior to requirement result become true and adds a sword to inventory
            if (luck >= requirement)
            {
                Item.Inventory.Add("a sword");
                return result = true;
            }

            // if user has a key in his inventory unlock the chest
            if (Item.Inventory.Contains("a key"))
            {
                Item.Inventory.Add("a sword");
                return result = true;
            }
            
            // return result whether it's true or false according to the code above
            return result;
        }

    }
}