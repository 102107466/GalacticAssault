using System;

namespace GalacticAssault
{
    static class Utilities
    {
        /*========*/
        /* Fields */
        /*========*/

        private static Random _random = new Random();
        
        /*=========*/
        /* Methods */
        /*=========*/

        public static int Random(int min, int max)
        {
            return _random.Next(min, max);
        }

        public static T Clamp<T>(T val, T min, T max) where T : IComparable<T>
        {
            return val.CompareTo(min) < 0 ? min :
                   val.CompareTo(max) > 0 ? max :
                   val;
        }
    }
}
