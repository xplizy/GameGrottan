using MajornaGameStore.DataAccess.Entities;

namespace MajornaGameStore.DataAccess.Services;

public class UserService(UserRepository repository) : ServiceBase<User, string>(repository)
{
    
}