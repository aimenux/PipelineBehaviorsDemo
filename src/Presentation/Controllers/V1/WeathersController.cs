using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PipelineBehaviorsDemo.Presentation.Controllers.V1;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/weathers")]
public class WeathersController : ControllerBase
{
    protected readonly ISender Sender;
    protected readonly ILogger<WeathersController> Logger;

    protected WeathersController(ISender sender, ILogger<WeathersController> logger)
    {
        Sender = sender ?? throw new ArgumentNullException(nameof(sender));
        Logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }
}
