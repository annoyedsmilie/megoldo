using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using long2 = System.Int64;

namespace WpfApplication7
{
    class Lychrel
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

        private long2 reverse(long2 nn)
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

            long2 res = 0;

            long2 mul = 1;
            for (long i = dc - 1; i >= 0; i--)
            {
                res += mul * d[i];
                mul *= 10;
            }

            return res;
        }

        private bool isLychrel(long n)
        {
            long nn = n + reverse(n);
            if (isPal(nn))
                return false;

            for (int i = 0; i < 30; i++)
            {
                nn = nn + reverse(nn);
                if (isPal(nn))
                    return false;
            }
            return true;
        }

        public void Start(System.Windows.Controls.TextBlock t, BackgroundWorker worker) // TODO : can't access the TextBlock !
        {
            string res = "";
            long2 cnt = 0;
            long MAX = 10000;
            long step = MAX / 100;
            for (long2 i = 1; i < MAX; i++)
            {
                if (isLychrel(i))
                {
                    //res += i.ToString() + " : True\n";
                    cnt++;
                }
                //else
                  //  res += i.ToString() + " : False\n";

                if (i % step == 0)
                {
                    worker.ReportProgress((int)i, res);
                    res = "";
                }
                //System.Threading.Thread.Sleep(500);
            }
            res += cnt.ToString();
            worker.ReportProgress(100, res);
        }

        public void Test(System.Windows.Controls.TextBlock t)
        {
            t.Text += reverse(196).ToString();

        }
    }
}
