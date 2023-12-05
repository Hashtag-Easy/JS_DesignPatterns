using System.Globalization;
using System.Threading;

namespace DesignPatterns.Samples.WithDI
{
    public class AppConfigSingleton
    {
        private static AppConfigSingleton _instance;

        private static readonly object _instanceLock = new object();

        private AppConfigSingleton() { }

        public static AppConfigSingleton Instance { 
            get
            {
                if (_instance != null)
                    return _instance;

                lock (_instanceLock)
                {
                    if (_instance == null)
                        _instance = new AppConfigSingleton();
                }

                return _instance;
            }
        }

        public CultureInfo Language { get; set; }
    }


    class TestSingleton
    {
        public void Test()
        {
            var appconfig = AppConfigSingleton.Instance;

        }
    }
}
