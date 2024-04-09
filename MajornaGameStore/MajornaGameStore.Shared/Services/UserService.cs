using MajornaGameStore.DataAccess.Entities;

namespace MajornaGameStore.DataAccess.Services;

public class UserService(IUserRepository repository) : ServiceBase<User, string>(repository)
{
    
}