using BlabberApp.DataStore.Adapters;
using BlabberApp.DataStore.Interfaces;

namespace BlabberApp.Services.Factories
{
    public class UserFactory
    {
        public UserAdapter BuildAdapter(IUserPlugin plugin)
        {
            return new UserAdapter(plugin);
        }

        public BlabberApp.Domain.Entities.User Build(string email = "")
        {
            return new BlabberApp.Domain.Entities.User();
        }

        public User BuildUserService(UserAdapter adapter)
        {
            return new User(adapter);
        }
    }
}
