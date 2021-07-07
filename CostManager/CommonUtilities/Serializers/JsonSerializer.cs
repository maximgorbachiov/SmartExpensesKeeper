using Newtonsoft.Json;

namespace CommonUtilities.Serializers
{
    public class JsonSerializer : ISerializer
    {
        public T DeserializeItem<T>(string item)
        {
            T deserializedItem = JsonConvert.DeserializeObject<T>(item);
            return deserializedItem;
        }

        public string SerializeItem<T>(T item)
        {
            string serializedItem = JsonConvert.SerializeObject(item);
            return serializedItem;
        }
    }
}
