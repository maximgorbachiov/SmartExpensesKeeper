namespace MobileClient.Utilities
{
    public interface ISerializer
    {
        T DeserializeItem<T>(string item);
        string SerializeItem<T>(T item);
    }
}