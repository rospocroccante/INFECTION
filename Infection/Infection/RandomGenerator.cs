using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infection
{
    static class RandomGenerator
    {
        private static Random rand;

        static RandomGenerator()
        {
            rand = new Random();
        }

        public static int GetRandomInt(int min, int max)
        {
            int random = rand.Next(min, max);
            while (random == 0)
            {
                random = rand.Next(min, max);
            }
            return random;
        }

        public static float GetRandomIntF(int min, int max)
        {
            float randomF = GetRandomFloat();
            float random = rand.Next(min, max) * randomF;
            while (random == 0)
            {
                random = rand.Next(min, max);
            }
            return random;
        }

        public static float GetRandomFloat()
        {
            return (float)rand.NextDouble();
        }
    }
}
