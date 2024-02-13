using Sevilla.Sevilla;

namespace Sevilla.Tests
{
    /**
     * Contains tests for Sevilla/Bit.cs.
     */
    public class TestBit
    {
        public static void TestAll()
        {
            TestZeroArgSet();
            TestClear();
            TestOneArgSet();
            TestToggle();
            TestAnd();
            TestOr();
            TestNot();
            TestXor();
            TestToString();
        }

        public static void TestZeroArgSet()
        {
            Bit bitOne = new Bit(0);
            bitOne.Set();
            TestUtils.Expect(bitOne.GetValue(), 1);

            Bit bitTwo = new Bit(1);
            bitTwo.Set();
            TestUtils.Expect(bitTwo.GetValue(), 1);
        }

        public static void TestClear()
        {
            Bit bitOne = new Bit(0);
            bitOne.Clear();
            TestUtils.Expect(bitOne.GetValue(), 0);

            bitOne.Set(1);
            bitOne.Clear();
            TestUtils.Expect(bitOne.GetValue(), 0);
        }

        public static void TestOneArgSet()
        {
            Bit bitOne = new Bit(0);
            bitOne.Set(0);
            TestUtils.Expect(bitOne.GetValue(), 0);

            bitOne.Set(1);
            TestUtils.Expect(bitOne.GetValue(), 1);

            try
            {
                bitOne.Set(99);
            }
            catch (Exception) { }
        }

        public static void TestToggle()
        {
            Bit bitOne = new Bit(0);
            bitOne.Toggle();
            TestUtils.Expect(bitOne.GetValue(), 1);

            bitOne.Toggle();
            TestUtils.Expect(bitOne.GetValue(), 0);
        }
        public static void TestAnd()
        {
            Bit bitOne = new Bit(0);
            Bit bitTwo = new Bit(0);

            TestUtils.Expect(bitOne.And(bitTwo).GetValue(), 0);

            bitOne.Set();

            TestUtils.Expect(bitOne.And(bitTwo).GetValue(), 0);

            bitOne.Clear();
            bitTwo.Set();

            TestUtils.Expect(bitOne.And(bitTwo).GetValue(), 0);

            bitOne.Set();

            TestUtils.Expect(bitOne.And(bitTwo).GetValue(), 1);
        }

        public static void TestOr()
        {
            Bit bitOne = new Bit(0);
            Bit bitTwo = new Bit(0);

            TestUtils.Expect(bitOne.Or(bitTwo).GetValue(), 0);

            bitOne.Set();

            TestUtils.Expect(bitOne.Or(bitTwo).GetValue(), 1);

            bitOne.Clear();
            bitTwo.Set();

            TestUtils.Expect(bitOne.Or(bitTwo).GetValue(), 1);

            bitOne.Set();

            TestUtils.Expect(bitOne.Or(bitTwo).GetValue(), 1);
        }

        public static void TestNot()
        {
            Bit bitOne = new Bit(0);

            TestUtils.Expect(bitOne.Not().GetValue(), 1);

            bitOne.Set();

            TestUtils.Expect(bitOne.Not().GetValue(), 0);
        }

        public static void TestXor()
        {
            Bit bitOne = new Bit(0);
            Bit bitTwo = new Bit(0);

            TestUtils.Expect(bitOne.Xor(bitTwo).GetValue(), 0);

            bitOne.Set();

            TestUtils.Expect(bitOne.Xor(bitTwo).GetValue(), 1);

            bitOne.Clear();
            bitTwo.Set();

            TestUtils.Expect(bitOne.Xor(bitTwo).GetValue(), 1);

            bitOne.Set();

            TestUtils.Expect(bitOne.Xor(bitTwo).GetValue(), 0);
        }

        public static void TestToString()
        {
            Bit bitOne = new Bit(0);

            TestUtils.Expect(bitOne.ToString(), "0");

            bitOne.Toggle();

            TestUtils.Expect(bitOne.ToString(), "1");
        }
    }
}
