namespace ClassesHomework
{
    using System;
    public class GSMTest
    {
        const int GSM_COUNT = 3;
        public static void GSM_Test()
        {
            // creates a few instances of the GSM class
            GSM[] mobilePhones = new GSM[GSM_COUNT];
            mobilePhones[0] = new GSM("PESHUNG", "PESHAXY PESH2", int.MaxValue, "Mr. Samsung",
                new Battery("PESHUNG", "PeshoBattery", 300, 18, BatteryType.Pesho),
                new Display("PESHUNG", "Pesho - emitting diode (PED) multi-pesho capacitive pesho-screen", "PeshoxPesho", 2<<24));
            mobilePhones[1] = new GSM("SAMSUNG", "GALAXY S2", 300M, "Mr. Pesho Georgiev",
                new Battery("SAMSUNG", "MegaBattery", 300, 18, BatteryType.Li_Ion),
                new Display("SAMSUNG", "LED multi-touch capacitive touch-screen", "740x860", 2<<24));
            mobilePhones[2] = new GSM("LENOVO", "UNIVERSE F1", 2500M, "Mr. Gosho Peshov",
                new Battery("LENOVO", "GigaBattery", 300, 18, BatteryType.Li_Ion),
                new Display("LENOVO", "LED multi-touch resistive touch-screen", "820x980", 2 << 24));

            // displays information about the GSM instances in the GSM array
            for (int i = 0; i < GSM_COUNT; i++)
            {
                Console.WriteLine(mobilePhones[i]);
                Console.WriteLine();
            }

            // displays information about the static property iPhone4S
            Console.WriteLine(GSM.IPhone4S);
            Console.WriteLine();
        }
    }
}
