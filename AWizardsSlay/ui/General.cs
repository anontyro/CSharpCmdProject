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
            string userInput = Console.ReadLine();
            ingameSelection(userInput);
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
                case "x":
                    Console.WriteLine("Game Paused");
                    gamePause();
                    break;
                default:
                    break;

            }

            return selection;
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
