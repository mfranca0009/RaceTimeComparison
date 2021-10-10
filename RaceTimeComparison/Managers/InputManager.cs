/************************************************************
 *                                                          *
 *  Author:        Matthew Franca                           *
 *  Course:        C# Programming                           *
 *  File:          InputManager.cs                          *
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
using RaceTimeComparison.Objects;

namespace RaceTimeComparison.Managers
{
    class InputManager
    {
        public void RetrieveRaceTimes(RaceManager raceManager)
        {
            // Retrieve user input on race times
            for (int i = 0; i < raceManager.GetTotalRaceLimit(); i++)
            {
                Race race = new Race();
                bool success;

                Console.WriteLine($"Enter the time for Race {i + 1} (-1 as hour to show results)");

                Console.Write("\nHours: ");
                success = int.TryParse(Console.ReadLine(), out int hourResult);

                while(!success) // Parse was not successful for hours
                {
                    Console.WriteLine("Invalid input for hours! Try again.");
                    Console.Write("\nHours: ");
                    success = int.TryParse(Console.ReadLine(), out hourResult);
                }

                // Ask for at least one race if the user tries to break out of the loop with 0 races
                while (hourResult == -1 && raceManager.GetRaces()[0] == null)
                {
                    Console.WriteLine("No races added! Add at least one race's time.");
                    Console.Write("\nHours: ");
                    success = int.TryParse(Console.ReadLine(), out hourResult);
                }

                // Break out of the loop if hour is `-1` and at least 1 race is present
                if (hourResult == -1 && raceManager.GetRaces()[0] != null)
                {
                    break;
                }

                Console.Write("Minutes: ");
                success = int.TryParse(Console.ReadLine(), out int minuteResult);

                while (!success)  // Parse was not successful for minutes
                {
                    Console.WriteLine("Invalid input for minutes! Try again.");
                    Console.Write("\nMinutes: ");
                    success = int.TryParse(Console.ReadLine(), out minuteResult);
                }

                Console.Write("Seconds: ");
                success = int.TryParse(Console.ReadLine(), out int secondResult);

                while (!success)  // Parse was not successful for seconds
                {
                    Console.WriteLine("Invalid input for seconds! Try again.");
                    Console.Write("\nSeconds: ");
                    success = int.TryParse(Console.ReadLine(), out secondResult);
                }

                // Set the new race's time from user input
                race.SetHour(hourResult);
                race.SetMinute(minuteResult);
                race.SetSecond(secondResult);

                // Adds the new race to the race manager
                raceManager.AddRace(i, race);

                Console.WriteLine();
            }
        }

        public void RetrieveContinueInput()
        {
            // Retrieve input from user
            Console.Write("Would you like to continue? (y/n): ");
            bool success = Char.TryParse(Console.ReadLine(), out char result);

            // If parse was not successful..
            if(!success)
            {
                Console.WriteLine("Invalid Input! Try again.\n");
                RetrieveContinueInput();
                return;
            }
            else // Parse was successful
            {
                // Convert character to lowercase, for less checks between lowercase and uppercase characters.
                result = Char.ToLower(result);

                // Input must be either 'y' or 'n' to continue or exit
                if (result != 'y' && result != 'n')
                {
                    Console.WriteLine("Input must be [y/Y or n/N]! Try again.\n");
                    RetrieveContinueInput();
                    return;
                }

                switch(result)
                {
                    case 'y': // Run program again
                        Program.RunMain();
                        break;
                    case 'n': // Exit program
                        return;
                }
            }
        }
    }
}
