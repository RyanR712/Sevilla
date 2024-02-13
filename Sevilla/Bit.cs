namespace Sevilla.Sevilla
{
    public class Bit : BitInterface
    {
        private int data;

        public Bit(int incomingData)
        {
            if (incomingData != 0 && incomingData != 1)
            {
                throw new Exception("Attempted to create a Bit object with some value that is not 0 or 1.");
            }
            else
            {
                data = incomingData;
            }
        }

        public Bit(Bit incomingBit)
        {
            data = incomingBit.GetValue();
        }

        public Bit And(Bit other)
        {
            if (data == 1)
            {
                if (other.GetValue() == 1)
                {
                    return new Bit(1);
                }
            }
            return new Bit(0);
        }

        public Bit Or(Bit other)
        {
            if (data == 0)
            {
                if (other.GetValue() == 0)
                {
                    return new Bit(0);
                }
            }
            return new Bit(1);
        }

        public Bit Not()
        {
            if (data == 0)
            {
                return new Bit(1);
            }
            else
            {
                return new Bit(0);
            }
        }

        public Bit Xor(Bit other)
        {
            if (data == 1)
            {
                if (other.GetValue() == 0)
                {
                    return new Bit(1);
                }
            }
            else if (other.GetValue() == 1)
            {
                if (data == 0)
                {
                    return new Bit(1);
                }
            }
            return new Bit(0);
        }

        public void Clear()
        {
            data = 0;
        }

        public void Set()
        {
            data = 1;
        }

        public void Set(int value)
        {
            if (value != 0 && value != 1)
            {
                throw new Exception("Attempted to assign a Bit object with some value that is not 0 or 1 in set(int).");
            }
            else
            {
                data = value;
            }
        }

        public void Toggle()
        {
            if (data == 0)
            {
                data = 1;
            }
            else
            {
                data = 0;
            }
        }

        public int GetValue()
        {
            return data;
        }

        override public string ToString()
        {
            return data.ToString();
        }
    }
}
