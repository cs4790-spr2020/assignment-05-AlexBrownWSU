using System.Collections;
using BlabberApp.DataStore.Adapters;

namespace BlabberApp.Services
{
    public class UserService : IUserService
    {
        UserAdapter adapter;
        public UserService(UserAdapter adapter)
        {
            this.adapter = adapter;
        }

        public IEnumerable GetAll()
        {
            return this.adapter.GetAll();
        }
    }
}
