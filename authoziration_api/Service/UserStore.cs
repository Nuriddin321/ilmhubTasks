using authoziration_api.Models;

namespace authoziration_api;

public class UserStore
{
    public Dictionary<string, User>? Users;

    public UserStore()
    {
        Users = new Dictionary<string, User>();
    }

}