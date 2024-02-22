using Sevilla.Sevilla;

namespace Sevilla.Tests
{
    /**
     * Contains tests for Sevilla/Memory.cs.
     */
    public static class TestMemory
    {
        public static void TestAll()
        {
            TestWrite();
            TestRead();
        }

        public static void TestWrite()
        {
            Memory mem = new Memory();

            mem.Write(new Longword(0), new Longword(1));

            TestUtils.Expect(mem.GetBitAtAddress(0).GetValue(), 0);

            mem.Write(new Longword(30), new Longword(-1));

            TestUtils.Expect(mem.GetBitAtAddress(35).GetValue(), 1);

            mem.Write(new Longword(1024), new Longword(259));

            TestUtils.Expect(mem.GetBitAtAddress(1024).GetValue(), 0);

            TestUtils.Expect(mem.GetBitAtAddress(1024 + 30).GetValue(), 1);
        }

        public static void TestRead()
        {
            Memory mem = new Memory();

            mem.Write(new Longword(0), new Longword(1));

            TestUtils.Expect(mem.Read(new Longword(0)).GetSigned(), 1);

            TestUtils.Expect(mem.Read(new Longword(2)).GetSigned(), 4);

            mem.Write(new Longword(30), new Longword(-1));

            TestUtils.Expect(mem.Read(new Longword(0)).GetSigned(), 3);

            TestUtils.Expect(mem.Read(new Longword(2)).GetSigned(), 15);

            mem.Write(new Longword(4096), new Longword(-1));

            TestUtils.Expect(mem.Read(new Longword(4096)).GetSigned(), -1);

            TestUtils.Expect(mem.Read(new Longword(4097)).GetSigned(), -2);
        }
    }
}
