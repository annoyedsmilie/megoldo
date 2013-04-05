using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace WpfApplication7
{
    class FewRepeatedDigits
    {
        long[] fact;

        public void Init()
        {
            // a little speed-up
            fact = new long[19];
            fact[0] = fact[1] = 1;
            for (long i = 2; i < 19; i++)
                fact[i] = i * fact[i - 1];
        }

        public void Start(System.Windows.Controls.TextBlock t, BackgroundWorker worker)
        {
            long MAGIC = 4;
            long zeros = 4;
            long sumsum = 0;
            long sumsum2 = 0;

            for (int i = 0; i < 19; i++)
                worker.ReportProgress(0, i.ToString() + " - " + fact[i].ToString() + "\n");


                for (long d0 = 0; d0 < 4; d0++)  // 0
                    for (long d1 = 0; d1 < 4; d1++)
                    {
                        worker.ReportProgress((int)(d0 * 20 + d1 * 5), ".");
                        for (long d2 = 0; d2 < 4; d2++)  // 2
                            for (long d3 = 0; d3 < 4; d3++)
                                for (long d4 = 0; d4 < 4; d4++)  // 4
                                    for (long d5 = 0; d5 < 4; d5++)
                                        for (long d6 = 0; d6 < 4; d6++)  // 6
                                            for (long d7 = 0; d7 < 4; d7++)
                                                for (long d8 = 0; d8 < zeros; d8++)  // 8
                                                {
                                                    if (d0 + d1 + d2 + d3 + d4 + d5 + d6 + d7 + d8 > MAGIC)
                                                        break;
                                                    if (d0 + d1 + d2 + d3 + d4 + d5 + d6 + d7 + d8 < MAGIC - 3)
                                                        break;

                                                    long d9 = MAGIC - d0 - d1 - d2 - d3 - d4 - d5 - d6 - d7 - d8;
                                                    long a = MAGIC;
                                                    long sum = fact[a] / fact[d0] / fact[a - d0];
                                                    a -= d0;
                                                    sum *= fact[a] / fact[d1] / fact[a - d1];
                                                    a -= d1;
                                                    sum *= fact[a] / fact[d2] / fact[a - d2];
                                                    a -= d2;
                                                    sum *= fact[a] / fact[d3] / fact[a - d3];
                                                    a -= d3;
                                                    sum *= fact[a] / fact[d4] / fact[a - d4];
                                                    a -= d4;
                                                    sum *= fact[a] / fact[d5] / fact[a - d5];
                                                    a -= d5;
                                                    sum *= fact[a] / fact[d6] / fact[a - d6];
                                                    a -= d6;
                                                    sum *= fact[a] / fact[d7] / fact[a - d7];
                                                    a -= d7;
                                                    sum *= fact[a] / fact[d8] / fact[a - d8];
                                                    a -= d8;
                                                    sum *= fact[a] / fact[d9] / fact[a - d9];
                                                    sumsum += sum;
                                                    if (sumsum < 0)
                                                    {
                                                        worker.ReportProgress((int)(d0 * 20 + d1 * 5), "\nERROR\n");
                                                        return;
                                                    }

                                                }
                    }

            MAGIC--;
            zeros--;
            for (long d0 = 0; d0 < 4; d0++)  // 0
                for (long d1 = 0; d1 < 4; d1++)
                {
                    worker.ReportProgress((int)(d0 * 20 + d1 * 5), ".");
                    for (long d2 = 0; d2 < 4; d2++)  // 2
                        for (long d3 = 0; d3 < 4; d3++)
                            for (long d4 = 0; d4 < 4; d4++)  // 4
                                for (long d5 = 0; d5 < 4; d5++)
                                    for (long d6 = 0; d6 < 4; d6++)  // 6
                                        for (long d7 = 0; d7 < 4; d7++)
                                            for (long d8 = 0; d8 < zeros; d8++)  // 8
                                            {
                                                if (d0 + d1 + d2 + d3 + d4 + d5 + d6 + d7 + d8 > MAGIC)
                                                    break;
                                                if (d0 + d1 + d2 + d3 + d4 + d5 + d6 + d7 + d8 < MAGIC - 3)
                                                    break;

                                                long d9 = MAGIC - d0 - d1 - d2 - d3 - d4 - d5 - d6 - d7 - d8;
                                                long a = MAGIC;
                                                long sum = fact[a] / fact[d0] / fact[a - d0];
                                                a -= d0;
                                                sum *= fact[a] / fact[d1] / fact[a - d1];
                                                a -= d1;
                                                sum *= fact[a] / fact[d2] / fact[a - d2];
                                                a -= d2;
                                                sum *= fact[a] / fact[d3] / fact[a - d3];
                                                a -= d3;
                                                sum *= fact[a] / fact[d4] / fact[a - d4];
                                                a -= d4;
                                                sum *= fact[a] / fact[d5] / fact[a - d5];
                                                a -= d5;
                                                sum *= fact[a] / fact[d6] / fact[a - d6];
                                                a -= d6;
                                                sum *= fact[a] / fact[d7] / fact[a - d7];
                                                a -= d7;
                                                sum *= fact[a] / fact[d8] / fact[a - d8];
                                                a -= d8;
                                                sum *= fact[a] / fact[d9] / fact[a - d9];
                                                sumsum2 += sum;
                                            }
                }

            /*MAGIC--;
            zeros--;
            for (long d0 = 0; d0 < 4; d0++)  // 0
                for (long d1 = 0; d1 < 4; d1++)
                {
                    worker.ReportProgress((int)(d0 * 20 + d1 * 5), ".");
                    for (long d2 = 0; d2 < 4; d2++)  // 2
                        for (long d3 = 0; d3 < 4; d3++)
                            for (long d4 = 0; d4 < 4; d4++)  // 4
                                for (long d5 = 0; d5 < 4; d5++)
                                    for (long d6 = 0; d6 < 4; d6++)  // 6
                                        for (long d7 = 0; d7 < 4; d7++)
                                            for (long d8 = 0; d8 < zeros; d8++)  // 8
                                            {
                                                if (d0 + d1 + d2 + d3 + d4 + d5 + d6 + d7 + d8 > MAGIC)
                                                    break;
                                                if (d0 + d1 + d2 + d3 + d4 + d5 + d6 + d7 + d8 < MAGIC - 3)
                                                    break;

                                                long d9 = MAGIC - d0 - d1 - d2 - d3 - d4 - d5 - d6 - d7 - d8;
                                                long a = MAGIC;
                                                long sum = fact[a] / fact[d0] / fact[a - d0];
                                                a -= d0;
                                                sum *= fact[a] / fact[d1] / fact[a - d1];
                                                a -= d1;
                                                sum *= fact[a] / fact[d2] / fact[a - d2];
                                                a -= d2;
                                                sum *= fact[a] / fact[d3] / fact[a - d3];
                                                a -= d3;
                                                sum *= fact[a] / fact[d4] / fact[a - d4];
                                                a -= d4;
                                                sum *= fact[a] / fact[d5] / fact[a - d5];
                                                a -= d5;
                                                sum *= fact[a] / fact[d6] / fact[a - d6];
                                                a -= d6;
                                                sum *= fact[a] / fact[d7] / fact[a - d7];
                                                a -= d7;
                                                sum *= fact[a] / fact[d8] / fact[a - d8];
                                                a -= d8;
                                                sum *= fact[a] / fact[d9] / fact[a - d9];
                                                sumsum += sum;
                                            }
                }

            MAGIC--;
            zeros--;
            for (long d0 = 0; d0 < 4; d0++)  // 0
                for (long d1 = 0; d1 < 4; d1++)
                {
                    worker.ReportProgress((int)(d0 * 20 + d1 * 5), ".");
                    for (long d2 = 0; d2 < 4; d2++)  // 2
                        for (long d3 = 0; d3 < 4; d3++)
                            for (long d4 = 0; d4 < 4; d4++)  // 4
                                for (long d5 = 0; d5 < 4; d5++)
                                    for (long d6 = 0; d6 < 4; d6++)  // 6
                                        for (long d7 = 0; d7 < 4; d7++)
                                            for (long d8 = 0; d8 < zeros; d8++)  // 8
                                            {
                                                if (d0 + d1 + d2 + d3 + d4 + d5 + d6 + d7 + d8 > MAGIC)
                                                    break;
                                                if (d0 + d1 + d2 + d3 + d4 + d5 + d6 + d7 + d8 < MAGIC - 3)
                                                    break;

                                                long d9 = MAGIC - d0 - d1 - d2 - d3 - d4 - d5 - d6 - d7 - d8;
                                                long a = MAGIC;
                                                long sum = fact[a] / fact[d0] / fact[a - d0];
                                                a -= d0;
                                                sum *= fact[a] / fact[d1] / fact[a - d1];
                                                a -= d1;
                                                sum *= fact[a] / fact[d2] / fact[a - d2];
                                                a -= d2;
                                                sum *= fact[a] / fact[d3] / fact[a - d3];
                                                a -= d3;
                                                sum *= fact[a] / fact[d4] / fact[a - d4];
                                                a -= d4;
                                                sum *= fact[a] / fact[d5] / fact[a - d5];
                                                a -= d5;
                                                sum *= fact[a] / fact[d6] / fact[a - d6];
                                                a -= d6;
                                                sum *= fact[a] / fact[d7] / fact[a - d7];
                                                a -= d7;
                                                sum *= fact[a] / fact[d8] / fact[a - d8];
                                                a -= d8;
                                                sum *= fact[a] / fact[d9] / fact[a - d9];
                                                sumsum -= sum;
                                            }
                }*/
            worker.ReportProgress(100, "\nSUMSUM = " + sumsum.ToString());
            worker.ReportProgress(100, "\nSUMSUM2= " + sumsum2.ToString());
        }
    }
}
