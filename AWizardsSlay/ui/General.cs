using AWizardsSlay.sprits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWizardsSlay.ui
{
    class General
    {
        //State controls
        static bool newGameState = true; //check if the game is new or just paused
        static bool menuState = true; //contoles main menu
        static bool gameState = false;

        AWizardsSlay.player.Player player;

        public General()
        {
            Console.WriteLine("Welcome to A Wizards Slay Select an option to contiune");
            mainFramework();
        }


        private void mainFramework()
        {
            mainMenu();
        }

        private void mainMenu()
        {
            while (menuState)
            {
                Console.WriteLine("Select an option to contiune");
                if (newGameState)
                {
                    Console.WriteLine("[S]tart a game");

                }
                if (newGameState == false)
                {
                    Console.WriteLine("[C]arry on your adventure");

                }
                Console.WriteLine("[R]ules and controls");
                Console.WriteLine("e[X]it and run for safety");

                string userSelection = Console.ReadLine();

                mainSelection(userSelection);
            }



        }

        private int mainSelection(string userVal)
        {
            int selection = 0;
            if(userVal.Equals(""))
            {
                Console.WriteLine("Select something");
                mainMenu();
            }
            userVal = userVal.Trim().Substring(0,1).ToLower();

            switch (userVal)
            {
                case "s":
                    if (newGameState)
                    {
                        Console.WriteLine("Good luck on your quest");

                    }
                    selection = 1;
                    mainGameRun();
                    break;
                case "r":
                    Console.WriteLine("This is how you roll and also role");
                    selection = 2;
                    break;
                case "c":
                    if(newGameState == false){
                        Console.WriteLine("Good hunting");
                        mainGameRun();
                        selection = 2;
                        break;
                    }
                    goto default;
                default:
                    Console.WriteLine("Get going");
                    selection = 0;
                    Environment.Exit(0);
                    break;
            }

            return selection;
        }

        private void mainGameRun()
        {
            menuState = false;
            gameState = true;
            if (newGameState)
            {
                newGameState = false;
                Console.WriteLine("Welcome young adventurer you can press the [x] button at anytime to bring up the main menu");
                //code to create character elements and setup the beginning
                player = new AWizardsSlay.player.Player();
                
            }
            else
            {
                Console.WriteLine("Welcome back from your nap, I hope you enjoyed your rest");
            }

            while (gameState)
            {
                Console.WriteLine("[L]ook around to find treature or treachery");
                Console.WriteLine("[W]ait in the shadows to see if anything comes this way");
                Console.WriteLine("e[X]it as always to bring up the menu");


                string userInput = Console.ReadLine();
                ingameSelection(userInput);
            }

        }

        private int ingameSelection(string userVal)
        {
            int selection = 0;
           
            while(userVal.Equals(""))
            {
                Console.WriteLine("You stare vacantly at the wall just waiting for someone to tell you what " +
                    "to do...");
                userVal = Console.ReadLine();
            }

            userVal = userVal.Trim().Substring(0, 1).ToLower();

            switch (userVal)
            {
                case "l":
                    combatState();
                    break;
                case "w":
                    Console.WriteLine("You wait longingly...");
                    break;
                case "x":
                    Console.WriteLine("Game Paused");
                    gamePause();
                    break;
                default:
                    break;

            }

            return selection;
        }

        private void combatSelection(string userVal, Enemy enemy)
        {
            while (userVal.Equals(""))
            {
                Console.WriteLine("You stare vacantly at the wall just waiting for someone to tell you what " +
                    "to do...");
                userVal = Console.ReadLine();
            }

            userVal = userVal.Trim().Substring(0, 1).ToLower();

            switch (userVal)
            {
                case "a":
                    enemy.takeAHit(player.attack);
                    break;
                case "d":
                    
                    break;
                case "x":
                    Console.WriteLine("Game Paused");
                    gamePause();
                    break;
                default:
                    break;

            }
        }

        //basic test for a combat state
        private bool combatState()
        {
            bool combat = true;
            GnomeEn gnome = new GnomeEn(player.level,"str", 0,0);
            Console.WriteLine("Watch out a wild {0} appears", gnome.enemyName);

            while (combat)
            {
                Console.WriteLine("Your health: {0} / {1} , {2}'s health {3} / {4}",
                    player.hp,player.maxHp,gnome.enemyName,gnome.health,gnome.maxHealth);
                string userVal = Console.ReadLine();

                userVal = userVal.Trim().Substring(0, 1).ToLower();

                combatSelection(userVal, gnome);

                if (!gnome.alive)
                {
                    combat = false;
                    Console.WriteLine("You win!");
                }else
                {
                    player.takeAHit(gnome.attack);
                }
                if (!player.playerAlive)
                {
                    combat = false;
                    Console.WriteLine("You died");
                }
            }
            return false;
        }


        private int gamePause()
        {
            if (menuState)
            {
                menuState = false;
                gameState = true;
                mainGameRun();
                return 0;
            }
            else
            {
                menuState = true;
                gameState = false;
                mainMenu();
                return 1;
            }
        }




    }
}
