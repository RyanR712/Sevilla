namespace Sevilla.Sevilla
{
    public static class RippleAdder
    {
        public static Longword Add(Longword wordOne, Longword wordTwo)
        {
            Longword sumWord = new Longword();

            Bit carryBit = new Bit(0);

            for (int i = Longword.WORD_SIZE - 1; i >= 0; i--)
            {
                sumWord.SetBit(i, carryBit.Xor(wordOne.GetBit(i).Xor(wordTwo.GetBit(i))));

                carryBit.Set(wordOne.GetBit(i).And(wordTwo.GetBit(i)).Or(carryBit.And(wordOne.GetBit(i))).Or(carryBit.And(wordTwo.GetBit(i))).GetValue());

                if (wordOne.GetBit(i).And(wordTwo.GetBit(i)).IsOn() || carryBit.And(wordOne.GetBit(i)).IsOn() || carryBit.And(wordTwo.GetBit(i)).IsOn())
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

        public static Longword Subtract(Longword wordOne, Longword wordTwo)
        {
            return Add(wordOne, Add(wordTwo.Not(), new Longword(1))); 
        }
    }
}
