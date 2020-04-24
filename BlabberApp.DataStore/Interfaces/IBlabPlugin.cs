using System.Collections;
using System;

namespace BlabberApp.DataStore.Interfaces
{
    public interface IBlabPlugin : IPlugin
    {
        IEnumerable ReadByUserId(string Id);
        void UpdateBlabById(Guid Id, string blab);
    }
}