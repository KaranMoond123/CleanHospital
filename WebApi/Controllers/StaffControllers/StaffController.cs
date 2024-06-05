using Application.Features.Staffs.Commands.CreateStaffs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.StaffControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StaffController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult>Post(CreateStaffCommand command)
        {
            var data=await _mediator.Send(command);
            return ResponseHelper.GenerateReponse(data);
        }
    }
}
