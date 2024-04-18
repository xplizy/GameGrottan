using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.Shared.Interfaces.RepositoryInterfaces;

namespace MajornaGameStore.DataAccess.Sql.Repositories;

public class UserRepository(MajornaDbContext context): RepositoryBase<User, string>(context), IUserRepository
{
    public async Task<List<string>> GetRolesByEmail(string email)
    {

    }
    public override Task<bool> UpdateAsync(User entity)
    {
        throw new NotImplementedException();
    }
}