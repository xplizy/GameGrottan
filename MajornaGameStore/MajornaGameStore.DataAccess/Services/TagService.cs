using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.DataAccess.Sql.Repositories;

namespace MajornaGameStore.DataAccess.Services;

public class TagService(TagRepository repository) : ServiceBase<Tag, int>(repository)
{
    
}