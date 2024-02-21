using Sevilla.Sevilla;

namespace Sevilla.Tests
{
    /**
     * Contains tests for Sevilla/ALU.cs.
     * 
     * Opcodes:
     * 1000: AND
     * 1001: OR
     * 1010: XOR
     * 1011: NOT
     * 1100: LSHIFT
     * 1101: RSHIFT
     * 1110: ADD
     * 1111: SUB
     * 0111: MULT
     */
    public class TestALU
    {
        public static void TestAll()
        {
            TestDetermineAndPerformOperation();
        }

        public static void TestDetermineAndPerformOperation()
        {
            TestUtils.Expect(ALU.DetermineAndPerformOperation(createOpCodeBitArray(1, 0, 0, 0), new Longword(1), new Longword(1)).GetSigned(), 1);
            TestUtils.Expect(ALU.DetermineAndPerformOperation(createOpCodeBitArray(1, 0, 0, 0), new Longword(63), new Longword(63)).GetSigned(), 63);
            TestUtils.Expect(ALU.DetermineAndPerformOperation(createOpCodeBitArray(1, 0, 0, 0), new Longword(255), new Longword(0)).GetSigned(), 0);

            TestUtils.Expect(ALU.DetermineAndPerformOperation(createOpCodeBitArray(1, 0, 0, 1), new Longword(1), new Longword(1)).GetSigned(), 1);
            TestUtils.Expect(ALU.DetermineAndPerformOperation(createOpCodeBitArray(1, 0, 0, 1), new Longword(63), new Longword(63)).GetSigned(), 63);
            TestUtils.Expect(ALU.DetermineAndPerformOperation(createOpCodeBitArray(1, 0, 0, 1), new Longword(255), new Longword(0)).GetSigned(), 255);

            TestUtils.Expect(ALU.DetermineAndPerformOperation(createOpCodeBitArray(1, 0, 1, 0), new Longword(1), new Longword(1)).GetSigned(), 0);
            TestUtils.Expect(ALU.DetermineAndPerformOperation(createOpCodeBitArray(1, 0, 1, 0), new Longword(63), new Longword(63)).GetSigned(), 0);
            TestUtils.Expect(ALU.DetermineAndPerformOperation(createOpCodeBitArray(1, 0, 1, 0), new Longword(255), new Longword(0)).GetSigned(), 255);

            TestUtils.Expect(ALU.DetermineAndPerformOperation(createOpCodeBitArray(1, 0, 1, 1), new Longword(1), new Longword()).GetSigned(), -2);
            TestUtils.Expect(ALU.DetermineAndPerformOperation(createOpCodeBitArray(1, 0, 1, 1), new Longword(63), new Longword()).GetSigned(), -64);
            TestUtils.Expect(ALU.DetermineAndPerformOperation(createOpCodeBitArray(1, 0, 1, 1), new Longword(255), new Longword()).GetSigned(), -256);

            TestUtils.Expect(ALU.DetermineAndPerformOperation(createOpCodeBitArray(1, 1, 0, 0), new Longword(1), new Longword(1)).GetSigned(), 2);
            TestUtils.Expect(ALU.DetermineAndPerformOperation(createOpCodeBitArray(1, 1, 0, 0), new Longword(63), new Longword(1)).GetSigned(), 126);
            TestUtils.Expect(ALU.DetermineAndPerformOperation(createOpCodeBitArray(1, 1, 0, 0), new Longword(255), new Longword(1)).GetSigned(), 510);

            TestUtils.Expect(ALU.DetermineAndPerformOperation(createOpCodeBitArray(1, 1, 0, 1), new Longword(1), new Longword(1)).GetSigned(), 0);
            TestUtils.Expect(ALU.DetermineAndPerformOperation(createOpCodeBitArray(1, 1, 0, 1), new Longword(63), new Longword(1)).GetSigned(), 31);
            TestUtils.Expect(ALU.DetermineAndPerformOperation(createOpCodeBitArray(1, 1, 0, 1), new Longword(255), new Longword(1)).GetSigned(), 127);

            TestUtils.Expect(ALU.DetermineAndPerformOperation(createOpCodeBitArray(1, 1, 1, 0), new Longword(1), new Longword(2)).GetSigned(), 3);
            TestUtils.Expect(ALU.DetermineAndPerformOperation(createOpCodeBitArray(1, 1, 1, 0), new Longword(25), new Longword(3)).GetSigned(), 28);
            TestUtils.Expect(ALU.DetermineAndPerformOperation(createOpCodeBitArray(1, 1, 1, 0), new Longword(-5), new Longword(-10)).GetSigned(), -15);

            TestUtils.Expect(ALU.DetermineAndPerformOperation(createOpCodeBitArray(1, 1, 1, 1), new Longword(1), new Longword(2)).GetSigned(), -1);
            TestUtils.Expect(ALU.DetermineAndPerformOperation(createOpCodeBitArray(1, 1, 1, 1), new Longword(25), new Longword(3)).GetSigned(), 22);
            TestUtils.Expect(ALU.DetermineAndPerformOperation(createOpCodeBitArray(1, 1, 1, 1), new Longword(-5), new Longword(-10)).GetSigned(), 5);

            TestUtils.Expect(ALU.DetermineAndPerformOperation(createOpCodeBitArray(0, 1, 1, 1), new Longword(1), new Longword(2)).GetSigned(), 2);
            TestUtils.Expect(ALU.DetermineAndPerformOperation(createOpCodeBitArray(0, 1, 1, 1), new Longword(25), new Longword(3)).GetSigned(), 75);
            TestUtils.Expect(ALU.DetermineAndPerformOperation(createOpCodeBitArray(0, 1, 1, 1), new Longword(-5), new Longword(-10)).GetSigned(), 50);
        }

        private static Bit[] createOpCodeBitArray(int bitOne, int bitTwo, int bitThree, int bitFour)
        {
            return new Bit[]{new Bit(bitOne), new Bit(bitTwo), new Bit(bitThree), new Bit(bitFour)};
        }
    }
}
