using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Monte_Carlo_Rebuild
{
    static class IEnum
    {

        public static IEnumerable<long> Step(long startIndex, long endIndex, long stepSize)
        {

            for (long i = startIndex; i < endIndex; i = i + stepSize)
            {

                yield return i;

            }


        }
    }

}
