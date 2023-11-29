using BookShop.Domain.Entities;

namespace BookShop.Service.Repositories.ReviewRepository;

public interface IReviewRepository
{
    Task<Review> AddReview(Review review);
    Task<ICollection<Review>> GetAllTheReviews();
    Task<Review?> GetReviewById(Guid id);
    Task DeleteReview(Review review);
    

}