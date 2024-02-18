using System.Security.Cryptography;

namespace Sevilla.Tests
{
    public class TestUtils
    {
        public static void Expect(object obj, object toBe)
        {
            if (!obj.Equals(toBe))
            {
                throw new Exception("Test failed. Object " + obj + " is not the same as the expected Object " + toBe + ".");
            }
        }

        public static void ExpectFailure()
        {

        }
    }
}
