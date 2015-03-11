namespace TimerNamepace
{
    using System.Diagnostics;

    public delegate void DelegateTest();

    class RunTestTimer
    {
        static void Main()
        {
            DelegateTest simpleDelegate = new DelegateTest(Timer.TimerDelegateTest);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while (true)
            {
                if (stopwatch.ElapsedTicks % 2500000 == 0)
                {
                    simpleDelegate();
                }

                if (stopwatch.ElapsedTicks > 25000000)
                {
                    break;
                }
            }
        }
    }
}
