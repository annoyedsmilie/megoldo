using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using long2 = System.Int64;

namespace WpfApplication7
{
    class PrimesWithRuns
    {
        public void Init()
        {
        }

        public void Start(System.Windows.Controls.TextBlock t, BackgroundWorker worker)
        {
            long2 size = 10;
            long2 sum = 0;

            Primes pr = new Primes();
            pr.Init(400000);

            // at first: for not zeros
            for (long2 i = 1; i < 10; i++)
            {
                long2 sum2 = 0;
                long2 startnum = ((long2)Math.Pow(10, size) - 1) / 9 * i; // for example: 4444 if size = 4 and i = 4
                for (long2 j = 0; j < size; j++) // the distinct digit's position
                {
                    long2 pos = (long2)Math.Pow(10, j);
                    for (long2 k = -i; k < 10 - i; k++) // loop for the distinct digit's value
                    {
                        if (pr.IsPrime2(startnum + k * pos))
                        {
                            sum2 += startnum + k * pos;
                            //if (i > 5)
                               // worker.ReportProgress((int)i * 10, i.ToString() + " : " + (startnum + k * pos).ToString() + "\n");
                        }
                    }
                }
                sum += sum2;
                worker.ReportProgress((int)i * 10, "SUM: " + i.ToString() + " : " + sum2.ToString() + "\n");
            }

            for (long2 i = 2; i < 10; i += 6)
            {
                long2 sum2 = 0;
                long2 startnum = ((long2)Math.Pow(10, size) - 1) / 9 * i;
                for (long2 j = 0; j < size; j++)
                {
                    long2 pos = (long2)Math.Pow(10, j);
                    for (long2 k = -i; k < 10 - i; k++) // loop for the distinct digit's value
                    {
                        for (long2 j2 = 0; j2 < j; j2++)
                        {
                            long2 pos2 = (long2)Math.Pow(10, j2);
                            for (long2 k2 = -i; k2 < 10 - i; k2++) // loop for the distinct digit's value
                            {

                                if (pr.IsPrime2(startnum + k * pos + k2 * pos2))
                                {
                                    sum2 += startnum + k * pos + k2 * pos2;
                                    //worker.ReportProgress((int)i * 10, i.ToString() + " : " + (startnum + k * pos + k2 * pos2).ToString() + "\n");
                                }
                            }
                        }
                    }
                }
                sum += sum2;
                worker.ReportProgress((int)i * 10, i.ToString() + " : " + sum2.ToString() + "\n");
            }

            long2 sum3 = 0;
            for (long2 i = 1; i < 10; i++)
            {
                long2 sum2 = 0;
                long2 startnum = (long2)Math.Pow(10, size - 1) * i;
                for (long2 j = 0; j < size - 2; j++) // the distinct digit's position
                {
                    long2 pos = (long2)Math.Pow(10, j);
                    for (long2 k = 0; k < 10; k++) // loop for the distinct digit's value
                    {
                        if (pr.IsPrime2(startnum + k * pos))
                        {
                            sum2 += startnum + k * pos;
                            worker.ReportProgress((int)i * 10, i.ToString() + " : " + (startnum + k * pos).ToString() + "\n");
                        }
                    }
                }
                sum3 += sum2;
            }
            worker.ReportProgress(100, sum3.ToString() + "\n");
            sum += sum3;
            worker.ReportProgress(100, "SUM : " + sum.ToString() + "\n");
        }
    }
}
