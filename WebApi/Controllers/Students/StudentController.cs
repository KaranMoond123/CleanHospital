using Application.Features.States.Commmand.CreateStates;
using Application.Features.Students.Commands.CreateStudent;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Students
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult>Post(CreateStudentCommand command)
        {
            var data=await _mediator.Send(command);
            return ResponseHelper.GenerateReponse(data);
        }
    }
}
