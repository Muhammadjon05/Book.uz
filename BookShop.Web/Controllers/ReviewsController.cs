using BookShop.Web.Entities;
using BookShop.Web.Repositories.ReviewRepository;
using BookShop.Web.DtoModels;
using BookShop.Web.Exceptions;
using BookShop.Web.Manager.Review;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Web.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ReviewsController : ControllerBase
{
    private readonly ReviewManager _reviewManager;

    public ReviewsController(ReviewManager reviewManager)
    {
        _reviewManager = reviewManager;
    }

    [HttpPost]
    public async Task<IActionResult> AddReview(ReviewDto dto)
    {
        var review = await _reviewManager.AddReview(dto);
        return Ok(review);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTheReviews()
    {
        var reviews = await _reviewManager.GetAllTheReviews();
        return Ok(reviews);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetReviewById(Guid id)
    {
        try
        {
            var review = await _reviewManager.GetReviewById(id);
            return Ok(review);
        }
        catch (ReviewNotFoundException e)
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReview(Guid id)
    {
        try
        {
            await _reviewManager.DeleteReview(id);
            return Ok("Deleted successfully");
        }
        catch (ReviewNotFoundException e)
        {
            return NotFound("Review not found");
        }
    }
}