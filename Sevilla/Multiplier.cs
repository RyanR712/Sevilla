namespace Sevilla.Sevilla
{
    public static class Multiplier
    {
        /**
         * Returns the product of two Longwords.
         * 
         * @author https://youtu.be/lLF9bIUGmOg?feature=shared&t=112
         */
        public static Longword Multiply(Longword wordOne, Longword wordTwo)
        {
            Longword productWord = new Longword(0);

            for (int i = Longword.WORD_SIZE - 1; i >= 0; i--)
            {
                if (wordTwo.GetBit(i).IsOn())
                {
                    productWord.Set(RippleAdder.Add(productWord, wordOne).GetSigned());
                }
                wordOne = wordOne.LeftShift(1);
            }

            return productWord;
        }
    }
}
