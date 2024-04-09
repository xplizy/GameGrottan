using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.DataAccess.Sql.Repositories;

namespace MajornaGameStore.DataAccess.Services;

public class UserService(IUserRepository repository) : ServiceBase<User, string>(repository)
{
    
}