/************************************************************
 *                                                          *
 *  Author:        Matthew Franca                           *
 *  Course:        C# Programming                           *
 *  File:          Program.cs                               *
 *                                                          *
 *  Description:   Comparison of race times that the user   *
 *                 inputs to determine which race was the   *
 *                 fastest and slowest. Also calculates     *
 *                 the average time of all races that were  *
 *                 given by the user                        *
 *                                                          *
 *  Input:         User input to retrieve race times asking *
 *                 for the hour(s), minute(s), and          * 
 *                 second(s) of a race time.                *
 *                                                          *
 *  Output:        Displays all race times that were given  *
 *                 by the user, shows which race was the    *
 *                 fastest and slowest, as well as the      *
 *                 average time between all races given     *
 *                 by the user.                             *
 *                                                          *
 ************************************************************/

using System;
using RaceTimeComparison.Managers;

namespace RaceTimeComparison
{
    class Program
    {
        static void Main()
        {
            // Create a new race manager and input manager
            RaceManager raceManager = new RaceManager();
            InputManager inputManager = new InputManager();

            // Retrieve user input on race times
            inputManager.RetrieveRaceTimes(raceManager);

            // Determine which race had the least and max amount of time
            raceManager.FindMinRaceTime();
            raceManager.FindMaxRaceTime();

            // Generate average time of all races
            raceManager.GenerateAverageTime();

            // Display race times and average time of all races
            raceManager.DisplayRaceTimes();
            raceManager.DisplayAverageTime();

            // Check if user wants to continue using application
            inputManager.RetrieveContinueInput();
        }

        public static void RunMain()
        {
            // Triggered in InputManager.cs if the user decides to use the program again.
            Console.Clear();
            Main();
        }
    }
}
