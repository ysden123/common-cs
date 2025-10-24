using System.Reflection;

namespace YSCommon
{
    public class Utils
    {
        /// <summary>
        /// Outputs the current thread name and a message to the console.
        /// </summary>
        /// <param name="message">A message to write on console</param>
        public static void Trace(string message)
        {
            var t = DateTime.Now.ToString("HH:mm:ss:fff");
            Console.WriteLine($"[{Thread.CurrentThread.Name}, {t}]: {message}");
        }

        /// <summary>
        /// Builds and returns the path to a folder in LocalApplicationData named after the executing assembly.   
        /// </summary>
        /// <returns>The path to a folder in LocalApplicationData named after the executing assembly</returns>
        /// <exception cref="Exception">If can't get an Assembly the Assembly name</exception>
        public static string GetAssemblyFolderInLocalData()
        {
            //Assembly assembly = Assembly.GetExecutingAssembly() ?? throw new Exception("Can't get excuting assembly!");
            Assembly assembly = Assembly.GetCallingAssembly() ?? throw new Exception("Can't get excuting assembly!");
            string assemblyName = assembly.GetName().Name ?? throw new Exception("Can't get assembly name!");
            string folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), assemblyName);
            return folder;
        }
    }
}
