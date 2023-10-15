using Microsoft.AspNetCore.Mvc;
using Application.Activity.Queries;
using Application.Activity.Commands;
using Domain;

namespace Api.Controllers
{
    public class ActivityController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await Mediator.Send(new GetActivities.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            return await Mediator.Send(new GetActivity.Query { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult> CreateActivity(Activity activity)
        {
            await Mediator.Send(new CreateActivity.Command { Activity = activity });
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Activity>> UpdateActivity(Guid id, Activity activity)
        {
            activity.Id = id;
            await Mediator.Send(new UpdateActivity.Command { Activity = activity });
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Activity>> DeleteActivity(Guid id)
        {
            await Mediator.Send(new DeleteActivity.Command { Id = id });
            return Ok();
        }
    }
}