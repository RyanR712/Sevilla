using Sevilla.Sevilla;

namespace Sevilla.Tests
{
    /**
     * Contains tests for Sevilla/RippleAdder.cs.
     */
    public class TestRippleAdder
    {
        public static void TestAll()
        {
            TestAdd();
            TestSubtract();
        }

        public static void TestAdd()
        {
            TestUtils.Expect(RippleAdder.Add(new Longword(0), new Longword(0)).GetSigned(), 0);
            TestUtils.Expect(RippleAdder.Add(new Longword(1), new Longword(1)).GetSigned(), 2);
            TestUtils.Expect(RippleAdder.Add(new Longword(2), new Longword(-5)).GetSigned(), -3);
            TestUtils.Expect(RippleAdder.Add(new Longword(-256), new Longword(256)).GetSigned(), 0);
            TestUtils.Expect(RippleAdder.Add(new Longword(-5), new Longword(-5)).GetSigned(), -10);
        }

        public static void TestSubtract()
        {
            TestUtils.Expect(RippleAdder.Subtract(new Longword(0), new Longword(0)).GetSigned(), 0);
            TestUtils.Expect(RippleAdder.Subtract(new Longword(1), new Longword(1)).GetSigned(), 0);
            TestUtils.Expect(RippleAdder.Subtract(new Longword(-5), new Longword(5)).GetSigned(), -10);
            TestUtils.Expect(RippleAdder.Subtract(new Longword(0), new Longword(-5)).GetSigned(), 5);
            TestUtils.Expect(RippleAdder.Subtract(new Longword(-10), new Longword(-20)).GetSigned(), 10);
        }
    }
}
