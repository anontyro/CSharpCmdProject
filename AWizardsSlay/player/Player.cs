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

        public Player()
        {
            while(rollChar() < 30)
            {
                rollChar();
            }
            Console.WriteLine(toString());

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
                "Magic Points: {6}",
                hp,maxHp,attack,dex,magic,actionPoints,mp);

            return user;
        }







    }
}
