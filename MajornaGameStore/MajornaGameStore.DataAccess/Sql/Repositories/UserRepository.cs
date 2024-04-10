using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.Shared.Interfaces;

namespace MajornaGameStore.DataAccess.Sql.Repositories;

public class UserRepository(MajornaDbContext context): RepositoryBase<User, string>(context), IUserRepository
{
    public override Task<bool> UpdateAsync(User entity)
    {
        throw new NotImplementedException();
    }
}