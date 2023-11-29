using System.Collections;
using AutoMapper;
using BookShop.Data.DbContext;
using BookShop.Domain.DtoModels;
using BookShop.Domain.Entities;
using BookShop.Service.Extensions;
using BookShop.Service.Filter;
using BookShop.Service.PaginationModels;
using BookShop.Service.Repositories.BookRepository;
using BookShop.Service.Repositories.Generic;
using BookShop.ViewModel.Models;
using BookShop.Web.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Service.Repositories.ReviewRepository;

public class ReviewRepository : IReviewRepository
{
    private readonly IGenericRepository<Review> _reviewRepository;
    private readonly HttpContextHelper _httpContext;
    private readonly IBookRepository _repository;
    private readonly UserProvider.UserProvider _userProvider;
    private readonly IMapper _mapper;

    public ReviewRepository(IGenericRepository<Review> reviewRepository, IMapper mapper, HttpContextHelper httpContext, IBookRepository repository, UserProvider.UserProvider userProvider)
    {
        _reviewRepository = reviewRepository;
        _mapper = mapper;
        _httpContext = httpContext;
        _repository = repository;
        _userProvider = userProvider;
    }

    public async ValueTask<ReviewModel> AddReview(ReviewDto dto)
    {

        var book = await _repository.GetBookByIdAsync(dto.BookId);
        if (book is null)
        {
            throw new BookNotFoundException(dto.BookId);
        }
        
        var review = _mapper.Map<Review>(dto);
        review.UserId  =  _userProvider.UserId;
        review.ReviewedDate = DateTime.Now;
        var newReview = await _reviewRepository.InsertAsync(review);
        return _mapper.Map<ReviewModel>(newReview);
    }

    public async ValueTask<IEnumerable<ReviewModel>> GetAllTheReviews(ReviewFilter filter)
    {
        var reviews = _reviewRepository.SelectAll();
        if (filter.ReviewText != null)
        {
            reviews = reviews.Where(t => t.ReviewText.ToLower()
                .Contains(filter.ReviewText.ToLower()));
        }

        if (filter.WrittenDate != null)
        {
            reviews = reviews.Where(t => t.ReviewedDate > filter.WrittenDate);
        }

        var reviewPages = await reviews.ToPagedListAsync(_httpContext, filter);
        return reviewPages.Select(v => _mapper.Map<ReviewModel>(v));
    }

    public ValueTask<ReviewModel?> GetReviewById(Guid id)
    {
        var review = _reviewRepository.SelectFirstAsync
            (t => t.ReviewId == id).Result;
        if (review == null)
        {
            throw new ReviewNotFoundException(id);
        }
        else
        {
            return ValueTask.FromResult(_mapper.Map<ReviewModel>(review))!;
        }
    }

    public ValueTask<ICollection<ReviewModel>?> GetReviewByBookId(Guid id)
    {
        var bookReview = _reviewRepository.SelectAll().Where(t => t.BookId == id).ToListAsync().Result;
        if (bookReview == null)
        {
            throw new ReviewNotFoundException(id);
        }
        else
        {
            return ValueTask.FromResult(_mapper.Map<ICollection<ReviewModel>>(bookReview))!;
        }
    }

    public void DeleteReview(Guid id)
    {
        var review = _reviewRepository.SelectFirstAsync
            (t => t.ReviewId == id).Result;
        if (review == null)
        {
            throw new ReviewNotFoundException(id);
        }
        else
        {
            _reviewRepository.DeleteAsync(review);
        }
    }
}