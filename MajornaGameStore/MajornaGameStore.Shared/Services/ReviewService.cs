using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.Shared.Interfaces;

namespace MajornaGameStore.DataAccess.Services;

public class ReviewService(IReviewRepository repository) : ServiceBase<Review, int>(repository)
{
    
}