using BlabberApp.DataStore.Adapters;
using BlabberApp.DataStore.Interfaces;
using BlabberApp.DataStore.Plugins;
using BlabberApp.Domain.Entities;

namespace BlabberApp.Services
{
    public class UserServiceFactory
    {
        public UserAdapter BuildUserAdapter(IUserPlugin plugin = null)
        {
            if (plugin == null)
            {
                plugin = this.BuildUserPlugin();
            }

            return new UserAdapter(plugin);
        }

        public User Build(string email = "")
        {
            return new User();
        }

        public IUserPlugin BuildUserPlugin(string type = "")
        {
            if (type.Equals("MySQL"))
            {
                return new MySqlUser();
            }

            return new InMemory();
        }

        public UserService BuildUserService(UserAdapter adapter = null)
        {
            if (adapter == null)
            {
                adapter = this.BuildUserAdapter();
            }

            return new UserService(adapter);
        }
    }
}
