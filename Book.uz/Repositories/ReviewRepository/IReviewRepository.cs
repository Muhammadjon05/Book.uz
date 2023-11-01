using Book.uz.Entities;

namespace Book.uz.Repositories.ReviewRepository;

public interface IReviewRepository
{
    Task<Review> AddReview(Review review);
    Task<ICollection<Review>> GetAllTheReviews();
    Task<Review?> GetReviewById(Guid id);
    Task DeleteReview(Review review);
    

}