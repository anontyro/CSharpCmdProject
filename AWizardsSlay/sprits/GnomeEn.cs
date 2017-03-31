using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWizardsSlay.sprits
{
    class GnomeEn : Enemy
    {
        public GnomeEn(int playerLevel, string location, int nerf, int buff) : base(playerLevel, location, nerf, buff)
        {
            enemyName = "Gnome Warrior";
            attack = 3;
            health = 5;
            maxHealth = health;
        }
    }
}
