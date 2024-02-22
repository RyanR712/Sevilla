namespace Sevilla.Sevilla
{
    public class Computer
    {
        private Memory mem;

        private Bit haltBit;

        public Computer()
        {
            mem = new Memory();
            haltBit = new Bit(0);
        }

        public void run()
        {
            while (haltBit.IsOn())
            {
                fetch();
                decode();
                execute();
                store();
            }
        }

        private void fetch()
        {

        }

        private void decode()
        {

        }

        private void execute()
        {

        }

        private void store()
        {

        }
    }
}
