using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alogitma
{
    public class AlgorithmOne
    {
        public int CalculateScore(int[] arr)
        {
            int score = 0;

            foreach (int num in arr)
            {
                if (num == 8)
                {
                    score += 5;
                }
                else if (num % 2 == 0)
                {
                    score += 1;
                }
                else
                {
                    score += 3;
                }
            }

            return score;
        }
    }
}
