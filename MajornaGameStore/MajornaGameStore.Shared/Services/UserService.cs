using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.Shared.Interfaces.RepositoryInterfaces;

namespace MajornaGameStore.DataAccess.Services;

public class UserService(IUserRepository repository) : ServiceBase<User, string>(repository)
{
    
}