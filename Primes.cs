using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using long2 = System.Int64;

namespace WpfApplication7
{
    class Primes
    {
        long2[] p;
        long2 pc;

        // all the primes < n will be collected in p[]
        public void Init(long2 n)
        {
            p = new long2[n];
            p[0] = 2;
            pc = 1;

            for (long2 i = 3; i < n; i += 2)
            {
                if (IsPrime(i))
                {
                    p[pc] = i;
                    pc++;
                }                    
            }
        }

        // prime test only for odd numbers, n <= p[pc-1]*p[pc-1]
        public bool IsPrime(long2 n)
        {
            for (long2 i = 1; i < pc; i++)
            {
                if (p[i] >= n)
                    return true;
                if (n % p[i] == 0)
                    return false;
            }
            return true;
        }

        // prime test, n <= p[pc-1]*p[pc-1]
        public bool IsPrime2(long2 n)
        {
            if (n == 2)
                return true;
            if (n % 2 == 0)
                return false;

            for (long2 i = 1; i < pc; i++)
            {
                if (p[i] >= n)
                    return true;
                if (n % p[i] == 0)
                    return false;
            }
            return true;
        }
    }
}
