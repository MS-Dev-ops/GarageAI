using GarageAI.Application.AI.Conversation.Ask;
using Microsoft.AspNetCore.Mvc;

namespace GarageAI.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AIController : ControllerBase
{
    private readonly AskConversationQueryHandler _handler;

    public AIController(AskConversationQueryHandler handler)
    {
        _handler = handler;
    }

    [HttpPost("conversation")]
    public async Task<IActionResult> Ask([FromBody] AskConversationRequest request)
    {
        var response = await _handler.HandleAsync(
            new AskConversationQuery(request));

        return Ok(response);
    }
}