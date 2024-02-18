namespace Sevilla.Sevilla
{
    /**
     * @author Michael Phipps
     */
    public interface LongwordInterface
    {
        Bit GetBit(int i);
        void SetBit(int i, Bit value);
        Longword And(Longword other);
        Longword Or(Longword other); 
        Longword Xor(Longword other);
        Longword Not();
        Longword RightShift(int amount); 
        Longword LeftShift(int amount);
        long GetUnsigned();
        int GetSigned();
        void Copy(Longword other);
        void Set(int value);
    }
}
