using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alogitma
{
    public class AlgorithmTwo
    {
        public void OutputA(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(i);
                }
                Console.WriteLine();
            }
        }

        public void OutputB(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                for (int j = i; j >= 1; j--)
                {
                    Console.Write(j);
                }
                Console.WriteLine();
            }
        }

        public void OutputC(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(j);
                }

                
                for (int j = i - 1; j >= 1; j--)
                {
                    Console.Write(j);
                }

                Console.WriteLine();
            }
        }

        public void OutputD(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    Console.Write((i + j - 1) + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
