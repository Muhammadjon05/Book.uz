using BookShop.Domain.DtoModels;
using BookShop.Service.Filter;
using BookShop.Service.Repositories.ReviewRepository;
using BookShop.Web.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Web.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ReviewsController : ControllerBase
{
    private readonly IReviewRepository _reviewRepository;

    public ReviewsController( IReviewRepository reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }

    [HttpPost]
    public async ValueTask<IActionResult> AddReview(ReviewDto dto)
    {
        try
        {   var review = await _reviewRepository.AddReview(dto);
            return Ok(review);

        }
        catch (BookNotFoundException e)
        {
            return BadRequest(e.Message);
        }
     
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetAllTheReviews([FromQuery] ReviewFilter filter)
    {
        try
        {
            var reviews = await _reviewRepository.GetAllTheReviews(filter);
            return Ok(reviews);
        }
        catch (Exception e)
        {
            return BadRequest("Something went wrong");
        }
       
    }

    [HttpGet("{id}")]
    public async ValueTask<IActionResult> GetReviewById(Guid id)
    {
        try
        {
            var review = await _reviewRepository.GetReviewById(id);
            return Ok(review);
        }
        catch (ReviewNotFoundException e)
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    public async ValueTask<IActionResult> DeleteReview(Guid id)
    {
        try
        {
             _reviewRepository.DeleteReview(id);
            return Ok("Deleted successfully");
        }
        catch (ReviewNotFoundException e)
        {
            return NotFound("Review not found");
        }
    }
}