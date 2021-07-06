using System.Xml;

namespace MobileClient.Configuration
{
    public class ConfigurationManager
    {
        private static string configFileName = "appsettings.xml";

        private static ConfigurationItem root = new ConfigurationItem();

        public static ConfigurationItem Configuration
        {
            get
            {
                if (root == null)
                {
                    root = Initialize();
                }

                return root;
            }
        }

        public static string Host
        {
            get
            {
                return Configuration["endpoints"]["apiGateway"].Value;
            }
        }

        private static ConfigurationItem Initialize()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(configFileName);

            return CreateItem(doc.FirstChild);
        }

        private static ConfigurationItem CreateItem(XmlNode node)
        {
            ConfigurationItem configurationItem = new ConfigurationItem();

            configurationItem.ItemName = node.Name;

            if (node.HasChildNodes)
            {
                foreach(XmlNode child in node.ChildNodes)
                {
                    ConfigurationItem childItem = CreateItem(child);
                    configurationItem.Children.Add(childItem.ItemName, childItem);
                }
            }
            else
            {
                configurationItem.Value = node.Value;
            }

            return configurationItem;
        }
    }
}