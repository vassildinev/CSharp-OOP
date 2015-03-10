namespace ClassesHomework
{
    public class RunTests
    {
        const int PREFERABLE_BUFFER_HEIGHT = 51;
        const int PREFERABLE_WINDOW_HEIGHT = 51;
        static void Main()
        {
            // extend the console height for a better overview of the test methods' results
            ExtendConsoleHeight();

            // launch the tests
            GSMTest.GSM_Test();
            GSMCallHistoryTest.GSMCallHistory_Test();
        }

        private static void ExtendConsoleHeight()
        {
            System.Console.BufferHeight = PREFERABLE_BUFFER_HEIGHT;
            System.Console.WindowHeight = PREFERABLE_WINDOW_HEIGHT;
        }
    }
}
