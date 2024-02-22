namespace Sevilla.Tests
{
    public class TestAll
    {
        /**
         * Contains the entire test suite.
         */
        public static void Main()
        {
            TestBit.TestAll();
            TestLongword.TestAll();
            TestRippleAdder.TestAll();
            TestMultiplier.TestAll();
            TestALU.TestAll();
            TestMemory.TestAll();

            Console.WriteLine("Aye, yer tests passed!");
        }
    }
}
