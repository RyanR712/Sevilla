namespace Sevilla.Sevilla
{
    public class Longword : LongwordInterface
    {
        const int MAX_SIGNED_INTEGER_WORD_SIZE = 2147483647;
        const int WORD_SIZE = 32;
        private Bit[] word;

        public Longword()
        {
            word = new Bit[WORD_SIZE];
        }

        public Longword(int wordValue)
        {
            word = new Bit[WORD_SIZE];

            Set(wordValue);
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
            word = new Bit[WORD_SIZE];
            Copy(otherWord);
        }

        public Bit GetBit(int i)
        {
            CheckLongwordIndices(i);
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
            CheckLongwordIndices(i);
            word[i] = new Bit(value);
        }

        public void Set(int value)
        {
            bool isDividedByDivisor, isNegative = value < 0;

            word[0] = isNegative ? new Bit(1) : new Bit(0);

            if (isNegative)
            {
                value += 1;
            }

            value = Math.Abs(value);

            int currentDivisor = 0;

            for (int i = 1; i < word.Length; i++)
            {
                currentDivisor = (int)Math.Pow(2, WORD_SIZE - i - 1);

                isDividedByDivisor = value / currentDivisor != 0;

                word[i] = determineBitToAdd(isDividedByDivisor, isNegative);

                if (isDividedByDivisor)
                {
                    value -= currentDivisor;
                }
            }
        }

        private Bit determineBitToAdd(bool isDividedByDivisor, bool isNegative)
        {
            if (isNegative)
            {
                if (isDividedByDivisor)
                {
                    return new Bit(0);
                }
                else
                {
                    return new Bit(1);
                }
            }   
            else
            {
                if (isDividedByDivisor)
                {
                    return new Bit(1);
                }
                else
                {
                    return new Bit(0);
                }
            }   
        }

        public int GetSigned()
        {
            int signedBaseTen = 0;

            bool isNegative = word[0].GetValue() == 1;

            for (int i = word.Length - 1; i > 0; i--)
            {
                signedBaseTen += determineSignedQuantityToAdd(word[i], i, isNegative);
            }

            if (isNegative)
            {
                signedBaseTen -= 1;
            }

            return signedBaseTen;
        }

        private int determineSignedQuantityToAdd(Bit currentBit, int currentIndex, bool isNegative)
        {
            if (isNegative)
            {
                return currentBit.GetValue() == 1 ? 0 : (int)Math.Pow(2, WORD_SIZE - currentIndex - 1) * -1;
            }
            else
            {
                return currentBit.GetValue() == 0 ? 0 : (int)Math.Pow(2, WORD_SIZE - currentIndex - 1);
            }
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
            CheckLongwordIndices(amount);
            Longword longWord = new Longword();

            for (int i = amount; i < word.Length; i++)
            {
                longWord.SetBit(i - amount, word[i]);
            }

            return longWord;
        }

        public Longword RightShift(int amount)
        {
            CheckLongwordIndices(amount);
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

        private void CheckLongwordIndices(int i)
        {
            if (i < 0 || i >= WORD_SIZE)
            {
                throw new Exception("Index " + i + " not valid for Longwords of size " + WORD_SIZE + ".");
            }
        }
    }
}
