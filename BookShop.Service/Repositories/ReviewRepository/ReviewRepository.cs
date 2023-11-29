using BookShop.Data.DbContext;
using BookShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Service.Repositories.ReviewRepository;

public class ReviewRepository : IReviewRepository
{
    private readonly AppDbContext _appDbContext;

    public ReviewRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Review> AddReview(Review review)
    {
       await _appDbContext.Reviews.AddAsync(review);
       await _appDbContext.SaveChangesAsync();
       return review;
    }

    public async Task<ICollection<Review>> GetAllTheReviews()
    {
        var reviews = await _appDbContext.Reviews.ToListAsync();
        return reviews;
    }

    public async Task<Review?> GetReviewById(Guid id)
    {
        var review = await _appDbContext.Reviews.
            Where(i => i.ReviewId == id).FirstOrDefaultAsync();
        return review;
    }

    public async Task DeleteReview(Review review)
    {
         _appDbContext.Reviews.Remove(review);
         await _appDbContext.SaveChangesAsync();
    }
}