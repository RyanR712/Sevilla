namespace Sevilla.Sevilla
{
    public static class RippleAdder
    {
        public static Longword add(Longword wordOne, Longword wordTwo)
        {
            Longword sumWord = new Longword();

            Bit carryBit = new Bit(0);

            for (int i = Longword.WORD_SIZE - 1; i >= 0; i--)
            {

                sumWord.SetBit(i, carryBit.Xor(wordOne.GetBit(i).Xor(wordTwo.GetBit(i))));

                carryBit.Set(wordOne.GetBit(i).And(wordTwo.GetBit(i)).Or(carryBit.And(wordOne.GetBit(i))).Or(carryBit.And(wordTwo.GetBit(i))).GetValue());

                if (wordOne.GetBit(i).And(wordTwo.GetBit(i)).GetValue() == 1 || carryBit.And(wordOne.GetBit(i)).GetValue() == 1 || carryBit.And(wordTwo.GetBit(i)).GetValue() == 1)
                {
                    carryBit.Set();
                }
                else
                {
                    carryBit.Clear();
                }
            }

            return sumWord;
        }

        public static Longword subtract(Longword wordOne, Longword wordTwo)
        {
            return add(wordOne, add(wordTwo.Not(), new Longword(1))); 
        }
    }
}
