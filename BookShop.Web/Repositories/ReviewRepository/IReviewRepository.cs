using BookShop.Web.Entities;

namespace BookShop.Web.Repositories.ReviewRepository;

public interface IReviewRepository
{
    Task<Review> AddReview(Review review);
    Task<ICollection<Review>> GetAllTheReviews();
    Task<Review?> GetReviewById(Guid id);
    Task DeleteReview(Review review);
    

}