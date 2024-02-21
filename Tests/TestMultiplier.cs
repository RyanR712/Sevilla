using Sevilla.Sevilla;

namespace Sevilla.Tests
{
    /**
     * Contains tests for Sevilla/Multiplier.cs.
     */
    public class TestMultiplier
    {
        public static void TestAll()
        {
            TestMultiply();
        }

        public static void TestMultiply()
        {
            TestUtils.Expect(Multiplier.Multiply(new Longword(1), new Longword(1)).GetSigned(), 1);
            TestUtils.Expect(Multiplier.Multiply(new Longword(0), new Longword(1890273)).GetSigned(), 0);
            TestUtils.Expect(Multiplier.Multiply(new Longword(-1), new Longword(42)).GetSigned(), -42);
            TestUtils.Expect(Multiplier.Multiply(new Longword(1), new Longword(-42)).GetSigned(), -42);
            TestUtils.Expect(Multiplier.Multiply(new Longword(-10), new Longword(-10)).GetSigned(), 100);
        }
    }
}
