using MajornaGameStore.DataAccess.Entities;

namespace MajornaGameStore.DataAccess.Sql.Repositories;

public class UserRepository(MajornaDbContext context): RepositoryBase<User, string>(context)
{
    public override Task<bool> UpdateAsync(User entity)
    {
        throw new NotImplementedException();
    }
}