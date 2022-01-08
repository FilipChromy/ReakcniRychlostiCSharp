using System;
using System.Collections.Generic;
using System.Text;

namespace LearnCS
{
    class MatematickeOperace
    {
        public static int soucet(int a, int b)
        {
            return a + b;
        }

        public static int odecet(int a, int b)
        {
            return a - b;
        }

        public static int nasobeni(int a, int b)
        {
            return a * b;
        }

        public static double deleni(int a, int b)
        {
            try
            {
                return (double) a / b;
            }
            catch (DivideByZeroException)
            {
                return 0;
            }
        }
    }
}
