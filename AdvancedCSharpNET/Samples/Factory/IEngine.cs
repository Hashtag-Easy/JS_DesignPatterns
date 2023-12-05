namespace DesignPatterns.Samples.WithDI
{
    public interface IEngine
    {
        void GetEngine();
    }

    public class SportEngine : IEngine
    {
        public SportEngine() { }
        public SportEngine(int maxHp) { }

        public void GetEngine()
        {
        }
    }
    public class StandardEngine : IEngine
    {
        public void GetEngine()
        {
        }
    }
}