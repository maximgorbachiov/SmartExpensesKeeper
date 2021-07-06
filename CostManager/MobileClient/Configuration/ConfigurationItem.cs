using System.Collections.Generic;

namespace MobileClient.Configuration
{
    public class ConfigurationItem
    {
        public ConfigurationItem()
        {
            this.Children = new Dictionary<string, ConfigurationItem>();
        }

        public ConfigurationItem this[string index]
        {
            get
            {
                return this.Children[index];
            } 
        } 

        public string ItemName { get; set; }
        public string Value { get; set; }

        public Dictionary<string, ConfigurationItem> Children { get; set; }
    }
}