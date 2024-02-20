namespace Sevilla.Tests
{
    public class TestAll
    {
        public static void Main()
        {
            TestBit.TestAll();
            TestLongword.TestAll();
            TestRippleAdder.TestAll();

            Console.WriteLine("Aye, yer tests passed!");
        }
    }
}
