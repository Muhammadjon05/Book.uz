using AutoMapper;
using Book.uz.DtoModels;
using Book.uz.Exceptions;
using Book.uz.Models;
using Book.uz.Repositories.ReviewRepository;

namespace Book.uz.Manager.Review;

public class ReviewManager 
{
    private readonly IReviewRepository _reviewRepository;

    private readonly UserProvider.UserProvider _userProvider;
    private readonly IMapper _mapper;
    public ReviewManager(IReviewRepository reviewRepository, IMapper mapper, UserProvider.UserProvider userProvider)
    {
        _reviewRepository = reviewRepository;
        _mapper = mapper;
        _userProvider = userProvider;
    }

    public  async Task<ReviewModel> AddReview(ReviewDto dto)
    {
        var model = _mapper.Map<Entities.Review>(dto);
        model.UserId = _userProvider.UserId;
        model.ReviewedDate = DateTime.Now;
        var review = await _reviewRepository.AddReview(model);
        return _mapper.Map<ReviewModel>(review);
    }

    public async Task<ICollection<ReviewModel>> GetAllTheReviews()
    {

        var reviews = await _reviewRepository.GetAllTheReviews();
        var reviewModels = _mapper.Map<ICollection<ReviewModel>>(reviews);
        return reviewModels;
    }

    public async Task<ReviewModel> GetReviewById(Guid id)
    {
        var review = await _reviewRepository.GetReviewById(id);
        if (review == null)
        {
            throw new ReviewNotFoundException(id);
        }
        return _mapper.Map<ReviewModel>(review);
    }

    public async Task DeleteReview(Guid id)
    {
        var review = await _reviewRepository.GetReviewById(id);
        if (review == null)
        {
            throw new ReviewNotFoundException(id);
        }
        await _reviewRepository.DeleteReview(review);
    }
}