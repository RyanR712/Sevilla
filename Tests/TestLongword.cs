using Sevilla.Sevilla;

namespace Sevilla.Tests
{
    public class TestLongword
    {
        private const string ONE = "00000000000000000000000000000001";
        private const string SIXTY_FOUR = "00000000000000000000000001000000";
        private const string SEVEN_SEVEN_SEVEN = "00000000000000000000001100001001";

        private const string NEGATIVE_ONE = "11111111111111111111111111111111";
        private const string NEGATIVE_TWO = "11111111111111111111111111111110";

        private const string ALL_ZEROES = "00000000000000000000000000000000";
        private const string ALL_ONES = "11111111111111111111111111111111";

        private const string ALTERNATING_PATTERN_NORMAL = "01010101010101010101010101010101";
        private const string ALTERNATING_PATTERN_INVERSE = "10101010101010101010101010101010";

        private const string GROUP_ALTERNATING_PATTERN_1_NORMAL = "00001111000011110000111100001111";
        private const string GROUP_ALTERNATING_PATTERN_1_INVERSE = "11110000111100001111000011110000";
        private const string GROUP_ALTERNATING_PATTERN_2_NORMAL = "00000000111111110000000011111111";
        private const string GROUP_ALTERNATING_PATTERN_2_INVERSE = "11111111000000001111111100000000";

        private const string SILLY_PATTERN_NORMAL = "10101010100010010010101000100101";
        private const string SILLY_PATTERN_INVERSE = "01010101011101101101010111011010";

        private const string COMPLETELY_RANDOM_1 = "10100100010101001001001001000000";
        private const string COMPLETELY_RANDOM_2 = "10101010010000100100101011111110";

        public static void TestAll()
        {
            TestGetWord();
            TestGetBit();
            TestCopy();
            TestSetBit();
            TestSet();
            TestGetSigned();
            TestGetUnsigned();
            TestAnd();
            TestOr();
            TestNot();
            TestXor();
            TestLeftShift();
            TestRightShift();
        }

        public static void TestGetWord()
        {
            
        }

        public static void TestGetBit()
        {
            Longword word = new Longword("00000000111111110000000011111111");

            TestUtils.Expect(word.GetBit(0).GetValue(), 0);
            TestUtils.Expect(word.GetBit(10).GetValue(), 1);
            TestUtils.Expect(word.GetBit(31).GetValue(), 1);

            TestUtils.Expect(word.GetBit(7).GetValue(), 0);
            TestUtils.Expect(word.GetBit(8).GetValue(), 1);
        }

        public static void TestCopy()
        {
            Longword wordOne = new Longword(COMPLETELY_RANDOM_1);
            Longword wordTwo = new Longword(GROUP_ALTERNATING_PATTERN_2_INVERSE);

            wordOne.Copy(wordTwo);

            TestUtils.Expect(wordOne.ToString(), GROUP_ALTERNATING_PATTERN_2_INVERSE);
        }

        public static void TestSetBit()
        {
            Longword word = new Longword(ONE); //darkness imprisoning me

            word.SetBit(31, new Bit(0));

            TestUtils.Expect(word.ToString()[31], '0');

            word = new Longword(ALL_ZEROES);

            word.SetBit(0, new Bit(1));

            TestUtils.Expect(word.ToString()[0], '1');
        }

        public static void TestSet()
        {

        }

        public static void TestGetSigned()
        {
            Longword word = new Longword(ALL_ZEROES);

            TestUtils.Expect(word.GetSigned(), 0);

            word = new Longword(ONE);

            TestUtils.Expect(word.GetSigned(), 1);

            word = new Longword(NEGATIVE_ONE);

            TestUtils.Expect(word.GetSigned(), -1);

            word = new Longword(NEGATIVE_TWO);

            TestUtils.Expect(word.GetSigned(), -2);
        }

        public static void TestGetUnsigned()
        {
            Longword word = new Longword(ALL_ZEROES);
            TestUtils.Expect(word.GetUnsigned(), 0L);

            word = new Longword(ONE);
            TestUtils.Expect(word.GetUnsigned(), 1L);

            word = new Longword(SIXTY_FOUR);
            TestUtils.Expect(word.GetUnsigned(), 64L);

            word = new Longword(SEVEN_SEVEN_SEVEN);
            TestUtils.Expect(word.GetUnsigned(), 777L);
        }

        public static void TestAnd()
        {
            Longword wordOne = new Longword(ALL_ZEROES);
            Longword wordTwo = new Longword(ALL_ONES);

            TestUtils.Expect(wordOne.And(wordTwo).ToString(), ALL_ZEROES);

            wordOne = new Longword(GROUP_ALTERNATING_PATTERN_1_NORMAL);
            wordTwo = new Longword(GROUP_ALTERNATING_PATTERN_1_INVERSE);

            TestUtils.Expect(wordOne.And(wordTwo).ToString(), ALL_ZEROES);

            wordOne = new Longword(COMPLETELY_RANDOM_1);
            wordTwo = new Longword(COMPLETELY_RANDOM_2);

            TestUtils.Expect(wordOne.And(wordTwo).ToString(), "10100000010000000000001001000000");
        }

        public static void TestOr()
        {
            Longword wordOne = new Longword(ALL_ZEROES);
            Longword wordTwo = new Longword(ALL_ONES);

            TestUtils.Expect(wordOne.Or(wordTwo).ToString(), ALL_ONES);

            wordOne = new Longword(SILLY_PATTERN_NORMAL);
            wordTwo = new Longword(SILLY_PATTERN_INVERSE);

            TestUtils.Expect(wordOne.Or(wordTwo).ToString(), ALL_ONES);

            wordOne = new Longword(COMPLETELY_RANDOM_1);
            wordTwo = new Longword(COMPLETELY_RANDOM_2);

            TestUtils.Expect(wordOne.Or(wordTwo).ToString(), "10101110010101101101101011111110");
        }

        public static void TestNot()
        {
            Longword word = new Longword(ALL_ZEROES);
            TestUtils.Expect(word.Not().ToString(), ALL_ONES);

            word = new Longword(ALL_ONES);
            TestUtils.Expect(word.Not().ToString(), ALL_ZEROES);

            word = new Longword(ALTERNATING_PATTERN_NORMAL);
            TestUtils.Expect(word.Not().ToString(), ALTERNATING_PATTERN_INVERSE);

            word = new Longword(GROUP_ALTERNATING_PATTERN_2_NORMAL);
            TestUtils.Expect(word.Not().ToString(), GROUP_ALTERNATING_PATTERN_2_INVERSE);
        }

        public static void TestXor()
        {
            Longword wordOne = new Longword(ALL_ZEROES);
            Longword wordTwo = new Longword(ALL_ONES);

            TestUtils.Expect(wordOne.Xor(wordTwo).ToString(), ALL_ONES);

            wordOne = new Longword(ALL_ONES);

            TestUtils.Expect(wordOne.Xor(wordTwo).ToString(), ALL_ZEROES);

            wordOne = new Longword(COMPLETELY_RANDOM_1);
            wordTwo = new Longword(COMPLETELY_RANDOM_2);

            TestUtils.Expect(wordOne.Xor(wordTwo).ToString(), "00001110000101101101100010111110");
        }

        public static void TestLeftShift()
        {

        }

        public static void TestRightShift()
        {
            Longword word = new Longword(ONE);

            word = word.RightShift(5);

            TestUtils.Expect(word.ToString(), ALL_ZEROES);
        }
    }
}
