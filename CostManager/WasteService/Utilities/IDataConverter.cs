namespace WasteService.Utilities
{
    public interface IDataConverter
    {
        void SaveWaste(WasteRequest waste);
        WasteResponse GetWastes(string clientId);
    }
}
