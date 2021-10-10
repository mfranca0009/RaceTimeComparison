/************************************************************
 *                                                          *
 *  Author:        Matthew Franca                           *
 *  Course:        C# Programming                           *
 *  File:          RaceManager.cs                           *
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
    class RaceManager
    {
        private static readonly int totalRaceLimit = 10;
        private int totalRaceTimes;
        private int totalRaces;
        private AverageTime averageTime;
        private Race[] races;
        private int minTimeIndex;
        private int maxTimeIndex;

        public RaceManager() 
        {
            totalRaceTimes = 0;
            totalRaces = 0;
            averageTime = new AverageTime();
            races = new Race[totalRaceLimit];
        }

        public void SetTotalRaceTimes(int totalRaceTimes)
        {
            this.totalRaceTimes = totalRaceTimes;
        }

        public void SetTotalRaces(int totalRaces)
        {
            this.totalRaces = totalRaces;
        }

        public int GetTotalRaceTimes()
        {
            return totalRaceTimes;
        }

        public int GetTotalRaces()
        {
            return totalRaces;
        }

        public Race[] GetRaces()
        {
            return races;
        }

        public int GetMinTimeIndex()
        {
            return minTimeIndex;
        }

        public int GetMaxTimeIndex()
        {
            return maxTimeIndex;
        }

        public int GetTotalRaceLimit()
        {
            return totalRaceLimit;
        }

        public void AddRaceTime(int raceTime)
        {
            totalRaceTimes += raceTime;
        }

        public void AddRace(int index, Race race)
        {
            races[index] = race;
            totalRaces++;

            race.CalculateTime();
            AddRaceTime(race.GetTime());

        }

        public void GenerateAverageTime()
        {
            averageTime.CalculateAverageTime(totalRaceTimes, totalRaces);
        }

        public void DisplayRaceTimes()
        {
            // Display race times and which time was the fastest and slowest
            Console.WriteLine();
            Console.WriteLine("\n********Race Times************");
            Console.WriteLine("______________________________");
            for (int i = 0; i < GetTotalRaces(); i++)
            {
                Console.Write($"\nRace {i + 1}: {races[i].DisplayTime()} ");

                if (i == GetMinTimeIndex())
                {
                    Console.Write("**FASTEST**");
                }
                else if (i == GetMaxTimeIndex())
                {
                    Console.Write("**SLOWEST**");
                }

                Console.WriteLine();
            }
        }

        public void DisplayAverageTime()
        {
            // Display average time of all races
            Console.WriteLine("\n********Average Time**********");
            Console.Write("______________________________\n");

            Console.WriteLine($"\nAverage time: {averageTime.DisplayTime()}");

            Console.WriteLine("______________________________\n");
        }

        public void FindMinRaceTime()
        {
            // Find the race with the least amount of time
            int minTime = races[0].GetTime();
            minTimeIndex = 0;

            for (int i = 1; i < GetTotalRaces(); i++)
            {
                if (races[i].GetTime() < minTime)
                {
                    minTime = races[i].GetTime();
                    minTimeIndex = i;
                }
            }
        }

        public void FindMaxRaceTime()
        {
            // Find the race with the max amount of time
            int max = races[0].GetTime();
            maxTimeIndex = 0;

            for (int i = 1; i < GetTotalRaces(); i++)
            { 
                if (races[i].GetTime() > max)
                {
                    max = races[i].GetTime();
                    maxTimeIndex = i;
                }
            }
        }
    }
}
