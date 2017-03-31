using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWizardsSlay.player
{
    class Player
    {
        public  int maxHp { get; set; }
        public  int hp { get; set; }
        public  int attack { get; set; }
        public  int dex { get; set; }
        public  int magic { get; set; }
        public  int actionPoints { get; set; }
        public  int mp { get; set; }
        public  int armour { get; set;}
        public  int level { get; set; }
        public int criticalHit { get; set; }
        public bool playerAlive { get; set; }

        public Player()
        {
            while(rollChar() < 30)
            {
                rollChar();
            }
            armour = 1;
            level = 1;
            criticalHit = 10;
            playerAlive = true;
            Console.WriteLine(toString());

        }

        public int performAttack()
        {
            int percentFactor = (attack * 20 / 100)+1;
            int min = attack - percentFactor;
            int max = attack + percentFactor;

            Random rand = new Random();
            int output = rand.Next(min, max);

            if (isitACrit())
            {
                output = output *2 - (output / 2);
            }

            return output;
        }

        public bool isitACrit()
        {
            Random rand = new Random();
            int num = rand.Next(1, 100) + 1;
            if(num <= criticalHit)
            {
                return true;
            }

            return false;
        }

        public void takeAHit(int dmg)
        {
            hp -= dmg;
            if (!isStillAlive())
            {
                Console.WriteLine("You have fallen already, how disapointing");
            }
        }

        private bool isStillAlive()
        {
            if (hp <= 0)
            {
                playerAlive = false;
                return false;
            }
            return true;
        }




        private int rollChar()
        {

            Random rand = new Random();
            maxHp = rand.Next(4, 11);
            hp = maxHp;
            attack = rand.Next(5, 11);
            dex = rand.Next(1, 11);
            magic = rand.Next(1, 11);
            actionPoints = rand.Next(3, 11);
            mp = rand.Next(0, 11);

            return maxHp+hp+attack+dex+magic+actionPoints+mp;
        }

         public string toString()
        {
            string user = string.Format( "Your states player: \n" +
                "HP: {0} out of {1} \n" +
                "Attack: {2} \n" +
                "Dexterity: {3} \n" +
                "Magic: {4} \n" +
                "Action Points: {5} \n" +
                "Magic Points: {6} \n" +
                "Level: {7} \n" +
                "Amour: {8} \n",
                hp,maxHp,attack,dex,magic,actionPoints,mp,level,armour);

            return user;
        }







    }
}
