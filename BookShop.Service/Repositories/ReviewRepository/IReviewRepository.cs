using BookShop.Domain.DtoModels;
using BookShop.Domain.Entities;
using BookShop.Service.Filter;
using BookShop.ViewModel.Models;

namespace BookShop.Service.Repositories.ReviewRepository;

public interface IReviewRepository
{
    ValueTask<ReviewModel> AddReview(ReviewDto review);
    ValueTask<IEnumerable<ReviewModel>> GetAllTheReviews(ReviewFilter filter);
    ValueTask<ReviewModel?> GetReviewById(Guid id);
    ValueTask<ICollection<ReviewModel>?> GetReviewByBookId(Guid id);
    void DeleteReview(Guid id);
    

}