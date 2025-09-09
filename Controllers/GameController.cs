using HumanVSAi.Api.Data;
using HumanVSAi.Api.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HumanVSAi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly GameDbContext _context;

        public GameController(GameDbContext context)
        {
            _context = context;
        }

        [HttpGet("random-image")]
        public async Task<IActionResult> GetRandomImage()
        {
            var r2BaseUrl = "https://ai-vs-human-proxy.ahmetmucahitsimsek1.workers.dev";

            var image = await _context.Images
                                      .OrderBy(r => EF.Functions.Random())
                                      .FirstOrDefaultAsync();

            if (image == null)
            {
                return NotFound("Veritabanında hiç resim bulunamadı.");
            }

            var fullUrl = $"{r2BaseUrl}/{image.R2ObjectKey}";

            // Frontend'e sadece ihtiyacı olan bilgileri gönder.
            var response = new
            {
                ImageId = image.Id,
                ImageUrl = fullUrl
            };

            return Ok(response);
        }

        [HttpPost("submit-guess")]
        public async Task<IActionResult> SubmitGuess([FromBody] SubmitGuessRequestDto request)
        {
            var imageInDb = await _context.Images.FindAsync(request.ImageId);

            if (imageInDb == null)
            {
                return NotFound(new { message = $"Verilen Id ({request.ImageId}) ile bir resim bulunamadı." });
            }

            bool isCorrect = request.GuessIsAI == imageInDb.IsAI;

            var response = new
            {
                IsCorrect = isCorrect,
                CorrectAnswerIsAI = imageInDb.IsAI
            };

            return Ok(response);
        }
    }
}