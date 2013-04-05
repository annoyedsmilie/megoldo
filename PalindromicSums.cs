using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using long2 = System.Int64;

namespace WpfApplication7
{
    class PalindromicSums
    {
        private bool isPal(long2 nn)
        {
            long2 n = nn;
            long[] d = new long[20];
            long dc = 0;

            for (int i = 0; i < 20; i++)
            {
                d[dc] = n % 10;
                dc++;
                n /= 10;
                if (n == 0)
                    break;
            }

            for (int i = 0; i < dc / 2; i++)
                if (d[i] != d[dc - i - 1])
                    return false;

            return true;
        }

        public void Init()
        {
        }

        public void Start(System.Windows.Controls.TextBlock t, BackgroundWorker worker)
        {
            long2 MAX = 10000;
            long2 MAXMAX = 100000000;

            long2[] ss = new long2[1000];
            long2 ssc = 0;
            for (long2 i = 1; i < MAX; i++)
            {
                for (long2 j = i + 2; j < MAX; j++)
                {
                    bool tooLarge = false;
                    long2 sum = 0;
                    for (long2 k = i; k < j; k++)
                    {
                        sum += k * k;
                        if (sum > MAXMAX)
                        {
                            tooLarge = true;
                            break;
                        }
                    }
                    if (tooLarge)
                        break;
                    else
                    {
                        if (isPal(sum))
                        {
                            ss[ssc] = sum;
                            ssc++;
                        }
                    }
                }
                //if (i % 100 == 0)
                  //  worker.ReportProgress((int)i / 100, "S");
            }

            long2 sumsum = 0;
            for (long2 i = 0; i < ssc; i++)
            {
                bool hasSame = false;
                for (long2 j = 0; j < i; j++)
                {
                    if (ss[i] == ss[j])
                        hasSame = true;
                }
                if (!hasSame)
                    sumsum += ss[i];
            }
            worker.ReportProgress(100, "\nSUMSUM= " + sumsum.ToString());
        }
    }
}
