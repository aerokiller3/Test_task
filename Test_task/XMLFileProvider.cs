using System.Xml;

namespace ConsoleApp30
{
    public class XMLFileProvider : IFileProvider, IConfigProvider
    {
        private List<Configuration> Configurations = new List<Configuration>();

        public void LoadFile(string filePath)
        {
            var configurations = new List<Configuration>();

            var document = new XmlDocument();
            document.Load(filePath);

            foreach (XmlNode node in document.DocumentElement)
            {
                var configuraion = new Configuration
                {
                    Name = node["name"].InnerText,
                    Description = node["description"].InnerText,
                };

                Configurations.Add(configuraion);
            }
        }

        public List<Configuration> GetConfigurations()
        {
            return Configurations;
        }
    }
}
