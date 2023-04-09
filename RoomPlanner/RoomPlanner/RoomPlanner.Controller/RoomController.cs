using Microsoft.AspNetCore.Mvc;
using RoomPlanner.RoomPlanner.Common.Entities;
using RoomPlanner.RoomPlanner.Repository.Interfaces;

namespace RoomPlanner.RoomPlanner.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepository? _roomRepository;

        public RoomController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        // GET: api/Room
        [HttpGet]
        public async Task<ActionResult<List<Room>>> GetAll()
        {
            return await _roomRepository.GetAll();
        }

        // GET: api/Room/5
        [HttpGet("{id}", Name = "GetR")]
        public async Task<ActionResult<Room>> Get(string id)
        {
            Room r = (Room)(await _roomRepository.Get(id));
            if (r == null)
            {
                return NotFound();
            }
            return r;
        }


    }
}
