/************************************************************
 *                                                          *
 *  Author:        Matthew Franca                           *
 *  Course:        C# Programming                           *
 *  File:          AverageTime.cs                           *
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

namespace RaceTimeComparison.Objects
{
    class AverageTime
    {
        private double average;
        private int hour;
        private int minute;
        private int second;

        public AverageTime()
        {
            average = 0.0;
            hour = 0;
            minute = 0;
            second = 0;
        }

        public void SetAverage(double average)
        {
            this.average = average;
        }

        public void SetHour(int hour)
        {
            this.hour = hour;
        }

        public void SetMinute(int minute)
        {
            this.minute = minute;
        }

        public void SetSecond(int second)
        {
            this.second = second;
        }

        public double GetAverage()
        {
            return average;
        }

        public int GetHour()
        {
            return hour;
        }

        public int GetMinute()
        {
            return minute;
        }

        public int GetSecond()
        {
            return second;
        }

        public void CalculateAverageTime(int totalRaceTimes, int totalRaces)
        {
            // Calculate average time of all races
            average = (double)totalRaceTimes / totalRaces;

            int avg = (int)average;
            hour = avg / 3600;
            avg %= 3600;
            minute = avg / 60;
            avg %= 60;
            second = avg;

            if (average > ((hour * 3600) + (minute * 60) + second))
            {
                second += 1;
            }
        }

        public string DisplayTime()
        {
            return $"{hour}:{minute}:{second}";
        }
    }
}
