using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWizardsSlay.sprits
{
    abstract class Enemy : EnemyInterface
    {
        public string enemyName { get; set; }
        public int health { get; set; }
        public int maxHealth { get; set; }
        public int armour { get; set; }
        private int level { get; set; }
        public int attack { get; set; }
        public bool alive { get; set; }

        public int playerLevel { get; set; }

        public Enemy(int playerLevel,string location,int nerf, int buff )
        {
            this.playerLevel = playerLevel;
            level = calcLevel(playerLevel);
            alive = true;
            
        }


        public int enemyAttack()
        {
            int percentFactor = (attack * 30 / 100) + 1;
            int min = attack - percentFactor;
            int max = attack + percentFactor;

            Random rand = new Random();
            int output = rand.Next(min, max);

            return output;
        }

        public int expGained()
        {
            throw new NotImplementedException();
        }

        protected int calcLevel(int playerLevel)
        {
            Random rand = new Random();

            switch ((rand.Next(0, 5) + 1))
            {
                case 1:
                    if(playerLevel-2 < 0) { return 1; };
                    return playerLevel - 2;
                    break;
                case 2:
                    if (playerLevel - 1 < 0) { return 1; };
                    return playerLevel - 1;
                    break;
                case 3:
                    return playerLevel;
                    break;
                case 4:
                    return playerLevel +1;
                    break;
                case 5:
                    return playerLevel + 2;
                    break;
                default:
                    return playerLevel;
                    break;
            }

        }

        public void takeAHit(int dmg)
        {
            health -= dmg;
            if (!isStillAlive())
            {
                Console.WriteLine("{0} has been defeated, how pathetic...", enemyName);
            }
        } 

        private bool isStillAlive(){
            if(health <= 0)
            {
                alive = false;
                return false;
            }
            return true;
        }

        public string toString()
        {
            string enemy = string.Format("This {0} is a humble level {1}, with an attack of {2}",
                enemyName,level,attack);
            return enemy;
        }

 
    }
}
