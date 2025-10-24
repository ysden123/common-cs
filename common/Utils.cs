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
        /// Builds the path to the local application data folder for the specified assembly.
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <returns>the path to the local application data folder for the specified assembly.</returns>
        public static string GetAssemblyFolderInLocalData(string assemblyName)
        {
            string folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), assemblyName);
            return folder;
        }
    }
}
