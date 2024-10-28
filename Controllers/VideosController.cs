using Advertisement.DBContext;
using Advertisement.Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace Advertisement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class VideosController : ControllerBase
    {
        private readonly Context _context;

        public VideosController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Video>>> GetVideos()
        {
            return await _context.Videos.ToListAsync();
        }

        [HttpPost("watch")]
        public async Task<IActionResult> WatchVideo(int userId, int videoId)
        {
            var user = await _context.Users.FindAsync(userId);
            var video = await _context.Videos.FindAsync(videoId);

            if (user == null || video == null) return NotFound();

            var userVideo = new UserVideo
            {
                UserId = userId,
                VideoId = videoId,
                WatchedOn = DateTime.UtcNow
            };

            _context.UserVideos.Add(userVideo);
            user.CreditBalance += video.CreditAmount;
            await _context.SaveChangesAsync();

            return Ok(new { NewCreditBalance = user.CreditBalance });
        }
    }

}
