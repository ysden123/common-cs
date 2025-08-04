using System.Reflection;

namespace YSCommon
{
    public class Properties
    {
        private readonly string _folder;
        private readonly string _fullPath;
        private readonly Dictionary<string,string> _properties;

        private Dictionary<string, string> Initialize()
        {
            var properties = new Dictionary<string, string>();
            if (File.Exists(_fullPath))
            {
                try
                {
                    foreach (var line in File.ReadAllLines(_fullPath))
                    {
                        var tokens = line.Split('=');
                        if (tokens.Length == 2)
                        {
                            properties.Add(tokens[0], tokens[1]);
                        }
                    }
                }
                catch (Exception)
                {
                }
            }

            return properties;
        }

        public Properties(string folder, string fileName)
        {
            _folder = folder;
            _fullPath = Path.Combine(folder, fileName);
            _properties = Initialize();
        }

        public Properties(string fileName)
        {
            string? assemblyName = Assembly.GetEntryAssembly().GetName().Name;
            _folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), assemblyName!);
            _fullPath = Path.Combine(_folder, fileName);
            _properties = Initialize();
        }

        public Dictionary<string, string> GetProperties()
        {
            return new Dictionary<string, string>(_properties);
        }

        public void SetProperty(string key, string value)
        {
           _properties[key] = value;
        }

        public void SaveProperties()
        {
            try
            {
                if (!Directory.Exists(_folder))
                {
                    Directory.CreateDirectory(_folder);
                }

                using (StreamWriter writer = new(_fullPath))
                {
                    foreach (KeyValuePair<string, string> kvPair in _properties)
                    {
                        writer.WriteLine($"{kvPair.Key}={kvPair.Value}");
                    }
                }
            }
            catch { }
        }
    }
}
