namespace Sevilla.Sevilla
{
    public class Computer
    {
        private const int INSTRUCTION_SIZE_IN_BYTES = 2, NUMBER_OF_REGISTERS = 16, OPCODE_SIZE_IN_BITS = 4, 
        OPERAND_ONE_REGISTER_SHIFT = 4, OPERAND_TWO_REGISTER_SHIFT = 8, DESTINATION_REGISTER_SHIFT = 0;
        private Memory mem;

        private Longword[] registers;

        private Longword programCounter, currentInstruction, operandOne, operandTwo, result, bitMask;

        private Bit[] opCode;

        private Bit haltBit;

        private int destination;

        public Computer()
        {
            mem = new Memory();
            registers = new Longword[NUMBER_OF_REGISTERS];
            programCounter = new Longword();
            currentInstruction = new Longword();
            operandOne = new Longword();
            operandTwo = new Longword();
            result = new Longword();
            bitMask = new Longword(15); //0000 0000 0000 0000 0000 0000 0000 1111
            opCode = new Bit[OPCODE_SIZE_IN_BITS];
            haltBit = new Bit(0);
            destination = 0;
        }

        public void Run()
        {
            while (haltBit.IsOn())
            {
                Fetch();
                Decode();
                Execute();
                Store();
            }
        }

        private void Fetch()
        {
            currentInstruction = mem.Read(programCounter);
            RippleAdder.Add(programCounter, new Longword(INSTRUCTION_SIZE_IN_BYTES * Memory.BITS_PER_BYTE));
        }

        private void Decode()
        {
            operandOne = registers[currentInstruction.LeftShift(21).RightShift(28).And(bitMask).GetSigned()]; 
            //ex: 0000 0000 0000 0000 1010 0101 1010 0101 => 0101 1010 0101 0000 0000 0000 0000 0000 => 0000 0000 0000 0000 0000 0000 0000 0000 0101 => 0101 & 1111 => 0101 => 9 <=> Operand one comes from Register 9.
            operandTwo = registers[currentInstruction.LeftShift(25).RightShift(28).And(bitMask).GetSigned()];
            //ex: 0000 0000 0000 0000 1010 0101 1010 0101 => 1010 0101 0000 0000 0000 0000 0000 0000 => 0000 0000 0000 0000 0000 0000 0000 0000 1010 => 1010 & 1111 => 1010 => 10 <=> Operand two comes from Register 10.
        }

        private void Execute()
        {
            opCode = currentInstruction.RightShift(27).And(bitMask).TransformToOpCode();
            result = ALU.DetermineAndPerformOperation(opCode, operandOne, operandTwo);
        }

        private void Store()
        {
            destination = currentInstruction.LeftShift(17).RightShift(28).And(bitMask).GetSigned();
            //ex: 0000 0000 0000 0000 1010 0101 1010 1101 =>  1101 0000 0000 0000 0000 0000 0000 0000 => 0000 0000 0000 0000 0000 0000 0000 0000 1101 => 1101 & 1111 => 1101 => 13 <=> The destination register is Register 13.
            registers[destination] = result;
        }
    }
}
