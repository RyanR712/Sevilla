namespace Sevilla.Sevilla
{
    /**
     * Models an Arithmetic Logic Unit, which decides what operation to perform on the two incoming Longwords.
     */
    public class ALU
    {
        private const int OPCODE_LENGTH = 4;

        enum opType
        {
            AND,
            OR,
            XOR,
            NOT,
            LSHIFT,
            RSHIFT,
            ADD,
            SUB,
            MULT,
            NONE
        }
        public static Longword DetermineAndPerformOperation(Bit[] opCode, Longword opOne, Longword opTwo)
        {
            opType currentOperation = DetermineOpTypeFromBits(opCode);

            switch (currentOperation)
            {
                case opType.AND: return opOne.And(opTwo);
                case opType.OR: return opOne.Or(opTwo);
                case opType.XOR: return opOne.Xor(opTwo);
                case opType.NOT: return opOne.Not();
                case opType.LSHIFT: return opOne.LeftShift(opTwo.GetSigned());
                case opType.RSHIFT: return opOne.RightShift(opTwo.GetSigned());
                case opType.ADD: return RippleAdder.Add(opOne, opTwo);
                case opType.SUB: return RippleAdder.Subtract(opOne, opTwo);
                case opType.MULT: return Multiplier.Multiply(opOne, opTwo);
                case opType.NONE: break;
            }

            return new Longword(0);
        }

        private static opType DetermineOpTypeFromBits(Bit[] opCode)
        {
            string stringifiedOpCode = "";
            for (int i = 0; i < OPCODE_LENGTH; i++)
            {
                stringifiedOpCode += opCode[i];
            }

            switch (stringifiedOpCode)
            {
                case "1000": return opType.AND;
                case "1001": return opType.OR;
                case "1010": return opType.XOR;
                case "1011": return opType.NOT;
                case "1100": return opType.LSHIFT;
                case "1101": return opType.RSHIFT;
                case "1110": return opType.ADD;
                case "1111": return opType.SUB;
                case "0111": return opType.MULT;
                default    : return opType.NONE;
            }
        }
    }
}
