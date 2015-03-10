namespace ClassesHomework
{
    using System;
    public class GSMCallHistoryTest
    {
        const decimal TEST_PRICE_CALLS_PER_MIN = 0.37M;
        public static void GSMCallHistory_Test()
        {
            // creates a new instance of class GSM
            GSM mobilePhone = new GSM("SAMSUNG", "GALAXY S2", 300M, "Mr. Pesho Georgiev",
                new Battery("SAMSUNG", "MegaBattery", 300, 18, BatteryType.Li_Ion),
                new Display("SAMSUNG", "LED multi-touch capacitive touch-screen", "740x860", 2 << 24));

            // adds a few calls to the call history
            mobilePhone.AddCall(new Call(new DateTime(2015, 03, 09, 18, 53, 03),
                                         new DateTime(2015, 03, 09, 18, 55, 51),
                                         "+359888888888"));
            mobilePhone.AddCall(new Call(new DateTime(2015, 03, 07, 15, 20, 13),
                                         new DateTime(2015, 03, 07, 16, 08, 26),
                                         "+359888888888"));
            mobilePhone.AddCall(new Call(new DateTime(2015, 03, 06, 08, 30, 04),
                                         new DateTime(2015, 03, 06, 09, 28, 51),
                                         "+359888888888"));

            // displays all calls in the call history
            for (int i = 0; i < mobilePhone.CallHistory.Count; i++)
            {
                Console.WriteLine(mobilePhone.CallHistory[i]);
                Console.WriteLine();
            }

            // calculates and prints the total price of all calls
            Console.WriteLine("Total price of all calls:\n{0:C}\n", 
                              mobilePhone.TotalPriceOfOutgoingCalls(TEST_PRICE_CALLS_PER_MIN));

            // removes the longest conversation
            Call longestCall = mobilePhone.CallHistory[0];
            for (int i = 0; i < mobilePhone.CallHistory.Count; i++)
            {
                if (mobilePhone.CallHistory[i].Duration > longestCall.Duration)
                {
                    longestCall = mobilePhone.CallHistory[i];
                }
            }

            mobilePhone.DeleteCall(longestCall);

            Console.WriteLine("Total price after removing the longest call:\n{0:C}\n", 
                              mobilePhone.TotalPriceOfOutgoingCalls(TEST_PRICE_CALLS_PER_MIN));

            // clears the call history and prints it
            mobilePhone.ClearCallHistory();

            Console.WriteLine("Call history after cleaning:");

            for (int i = 0; i < mobilePhone.CallHistory.Count; i++)
            {
                Console.WriteLine(mobilePhone.CallHistory[i]);
                Console.WriteLine();
            }
        }
    }
}
