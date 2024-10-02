using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineQuiz.BLL.Dtos.Track;
using OnlineQuiz.BLL.Managers.Track;
using OnlineQuiz.DAL.Data.Models;
using OnlineQuiz.DAL.Repositoryies.TrackRepository;

namespace OnlineQuiz.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrackController : ControllerBase
    {
        private readonly ITrackManager _trackManager;

        public TrackController(ITrackManager trackManager)
        {
            _trackManager = trackManager;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TrackDto>> GetAllTracks()
        {
            var tracks = _trackManager.GetAllTracks();
            return Ok(tracks);
        }

        [HttpGet("{id}")]
        public ActionResult<TrackDto> GetTrackById(int id)
        {
            var track = _trackManager.GetTrackById(id);
            if (track == null)
            {
                return NotFound();
            }
            return Ok(track);
        }

        [HttpPost]
        public ActionResult<TrackDto> AddTrack([FromBody] TrackDto trackDto)
        {
            if (trackDto == null)
            {
                return BadRequest();
            }

            var createdTrack = _trackManager.AddTrack(trackDto);
            return CreatedAtAction(nameof(GetTrackById), new { id = createdTrack.Id }, createdTrack);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTrack(int id, [FromBody] TrackDto trackDto)
        {
            if (trackDto == null || id != trackDto.Id)
            {
                return BadRequest();
            }

            _trackManager.UpdateTrack(trackDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTrack(int id)
        {
            _trackManager.DeleteTrack(id);
            return NoContent();
        }
    }
}
