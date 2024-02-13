namespace Sevilla.Sevilla
{
    /**
     * States which operations are required of the Bit object.
     * 
     * @author Michael Phipps
     */
    public interface BitInterface
    {
        void Set(int value);
        void Toggle();
        void Set();
        void Clear();
        int GetValue();
        Bit And(Bit other);
        Bit Or(Bit other);
        Bit Xor(Bit other);
        Bit Not();
        string ToString();
    }
}
