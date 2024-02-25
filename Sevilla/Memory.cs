namespace Sevilla.Sevilla
{
    public class Memory
    {
        public const int BITS_PER_BYTE = 8;
        private const int MEMORY_SIZE_IN_BYTES = 1024;
        
        private Bit[] memory;

        public Memory()
        {
            memory = new Bit[MEMORY_SIZE_IN_BYTES * BITS_PER_BYTE];

            for (int i = 0; i < memory.Length; i++)
            {
                memory[i] = new Bit(0);
            }
        }

        public Longword Read(Longword address)
        {
            Longword readWord = new Longword(0);

            int addressAsInteger = (int)address.GetUnsigned();

            for (int i = 0; i < Longword.WORD_SIZE; i++)
            {
                readWord.SetBit(i, memory[addressAsInteger + i]);
            }

            return readWord; //brother of Squidward
        }

        public void Write(Longword address, Longword writeWord)
        {
            int addressAsInteger = (int)address.GetUnsigned();

            for (int i = 0; i < Longword.WORD_SIZE; i++)
            {
                memory[addressAsInteger + i] = writeWord.GetBit(i);
            }
        }

        /**
         * Used in testing. Never use for any processor operations.
         */
        public Bit GetBitAtAddress(int address)
        {
            return memory[address];
        }
    }
}
