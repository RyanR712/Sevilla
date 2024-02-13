namespace Sevilla.Sevilla
{
    public class Longword : LongwordInterface
    {
        const int WORD_SIZE = 32;
        private Bit[] word;

        public Longword()
        {
            word = new Bit[WORD_SIZE];
        }

        public Longword(string wordString)
        {
            if (wordString.Length != 32)
            {
                throw new Exception("String of length " + wordString.Length + " is not valid for Longword construction.");
            }

            word = new Bit[WORD_SIZE];

            for (int i = 0; i < WORD_SIZE; i++)
            {
                word[i] = new Bit(int.Parse(wordString[i].ToString()));
            }
        }

        public Longword(Longword otherWord)
        {
            word = otherWord.GetWord();
        }

        public Bit[] GetWord()
        {
            return word;
        }

        public Bit GetBit(int i)
        {
            checkLongwordIndices(i);
            return word[i];
        }

        public void Copy(Longword other)
        {
            for (int i = 0; i < word.Length; i++)
            {
                word[i] = new Bit(other.GetBit(i));
            }
        }

        public void SetBit(int i, Bit value)
        {
            checkLongwordIndices(i);
            word[i] = new Bit(value);
        }

        public void Set(int value)
        {
            //parse an int as a binary
        }

        public int GetSigned()
        {
            int signedBaseTen = 0;

            int multiplier = word[0].GetValue() == 0 ? 1 : -1;

            for (int i = word.Length - 1; i > 0; i--)
            {
                signedBaseTen += word[i].GetValue() == 1 ? (int)Math.Pow(2, word.Length - i - 1) : 0;
            }

            return multiplier == 1 ? signedBaseTen : ((int)Math.Pow(2, 31) - signedBaseTen) * multiplier;
        }

        public long GetUnsigned()
        {
            long unsignedBaseTen = 0;

            for (int i = 0; i < word.Length; i++)
            {
                unsignedBaseTen += word[i].GetValue() == 1 ? (long)Math.Pow(2, word.Length - i - 1) : 0;
            }

            return unsignedBaseTen;
        }

        public Longword And(Longword other)
        {
            Longword longWord = new Longword();

            for (int i = 0; i < word.Length; i++)
            {
                longWord.SetBit(i, word[i].And(other.GetBit(i)));
            }

            return longWord;
        }

        public Longword Or(Longword other)
        {
            Longword longWord = new Longword();

            for (int i = 0; i < word.Length; i++)
            {
                longWord.SetBit(i, word[i].Or(other.GetBit(i)));
            }

            return longWord;
        }

        public Longword Not()
        {
            Longword longWord = new Longword();

            for (int i = 0; i < word.Length; i++)
            {
                longWord.SetBit(i, word[i].Not());
            }

            return longWord;
        }

        public Longword Xor(Longword other)
        {
            Longword longWord = new Longword();

            for (int i = 0; i < word.Length; i++)
            {
                longWord.SetBit(i, word[i].Xor(other.GetBit(i)));
            }

            return longWord;
        }

        public Longword LeftShift(int amount)
        {
            checkLongwordIndices(amount);
            Longword longWord = new Longword();

            for (int i = amount; i < word.Length; i++)
            {
                longWord.SetBit(i - amount, word[i]);
            }

            return longWord;
        }

        public Longword RightShift(int amount)
        {
            checkLongwordIndices(amount);
            Longword longWord = new Longword();

            for (int i = word.Length - amount; i >= 0; i--)
            {
                longWord.SetBit(i + amount, word[i]);
            }

            return longWord;
        }

        public override string ToString()
        {
            string wordString = "";

            for (int i = 0; i < word.Length; i++)
            {
                wordString += word[i].ToString();
            }

            return wordString;
        }

        private void checkLongwordIndices(int i)
        {
            if (i < 0 || i >= WORD_SIZE)
            {
                throw new Exception("Index " + i + " not valid for Longwords of size " + WORD_SIZE + ".");
            }
        }
    }
}
