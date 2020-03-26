using System;
using System.Collections;
using BlabberApp.DataStore.Adapters;

namespace BlabberApp.Services
{
    public class User
    {
        UserAdapter adapter;
        public User(UserAdapter adapter)
        {
            this.adapter = adapter;
        }

        public IEnumerable GetAll()
        {
            return this.adapter.GetAll();
        }
    }
}
