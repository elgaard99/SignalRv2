using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRv2.Repos;

namespace SignalRv2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController(ChatRepo chatRepo) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Task>>> GetChatsAsync() => Ok(await chatRepo.GetChatsAsync());
    }
}
