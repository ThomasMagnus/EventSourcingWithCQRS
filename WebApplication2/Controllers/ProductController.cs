using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Commands;
using WebApplication2.IServices;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : Controller
    {
        private readonly IEventReplayService _eventReplayService;

        public ProductController(IEventReplayService eventReplayService)
        {
            _eventReplayService = eventReplayService;
        }

        [HttpGet("index")]
        public string Index()
        {
            return "Запрос успешен!";
        }

        [HttpPost("product")]
        public async Task<IActionResult> CreateProduct([FromServices] ISender sender, CreateProductCommand product)
        {
            try
            {
                int productId = await sender.Send(product);
                return Ok(productId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("reply")]
        public async Task<IActionResult> ReplyEvents()
        {
            try
            {
                await _eventReplayService.ReplayEvents();
                return Ok("Событие воспроизведено");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
