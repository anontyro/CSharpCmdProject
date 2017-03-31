using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWizardsSlay.sprits
{
    abstract class Enemy : EnemyInterface
    {
        public int health { get; set; }
        public int maxHealth { get; set; }
        public int armour { get; set; }
        private int level;

        int Level
        {
            get { return level; }
            set
            {

            }
        }


        public int attack()
        {
            throw new NotImplementedException();
        }

        public int expGained()
        {
            throw new NotImplementedException();
        }

 
    }
}
