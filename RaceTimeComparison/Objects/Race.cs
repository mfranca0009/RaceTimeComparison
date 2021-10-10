/************************************************************
 *                                                          *
 *  Author:        Matthew Franca                           *
 *  Course:        C# Programming                           *
 *  File:          Race.cs                                  *
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
    class Race
    {
        private int hour;
        private int minute;
        private int second;
        private int time;

        public Race()
        {
            hour = 0;
            minute = 0;
            second = 0;
            time = 0;
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

        public void SetTime(int time)
        {
            this.time = time;
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

        public int GetTime()
        {
            return time;
        }

        public void CalculateTime()
        {
            time = GetSecond() + (GetMinute() * 60) + (GetHour() * 3600);
        }

        public string DisplayTime()
        {
            return $"{GetHour()}:{GetMinute()}:{GetSecond()}";
        }
    }
}
