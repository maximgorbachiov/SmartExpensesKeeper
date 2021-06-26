using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WasteService.Utilities
{
    public interface ISerializer
    {
        T DeserializeItem<T>(string item);
        string SerializeItem<T>(T item);
    }
}
