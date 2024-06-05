using Application.Dto.States;
using Application.Features.States.Commmand.CreateStates;
using Application.Features.States.Commmand.DeletedStates;
using Application.Features.States.Commmand.UpdateStates;
using Application.Features.States.Queries.GetAllStates;
using Application.Features.States.Queries.GetStateById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.StateControllers;

[Route("api/[controller]")]
[ApiController]
public class StateController : ControllerBase
{
    private readonly IMediator _mediator;

    public StateController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost]
    public async Task<ActionResult>Post(CreateStateCommand command)
    {
      var data=await _mediator.Send(command);
        return ResponseHelper.GenerateReponse(data);
    }
    [HttpGet]
    public async Task<ActionResult>GetAll()
    {
        var data = await _mediator.Send(new GetStateQuery());
        return ResponseHelper.GenerateReponse(data);
    }
    [HttpGet]
    [Route("api/State/{id}")]
    public async Task <ActionResult>GetById(int id)
    {
        var data=await _mediator.Send(new GetStateByIdQuary(id));
        return ResponseHelper.GenerateReponse(data);
    }
    [HttpPut]
    [Route("api/State/{id}")]
    public async Task<ActionResult>Update(int id,CreateStateCommand command)
    {
        var data=await _mediator.Send(new UpdateStateCommand(id,command));
        return ResponseHelper.GenerateReponse(data);
    }
    [HttpDelete]
    [Route("api/State/{id}")]
    public async Task<ActionResult>Deleted(int id)
    {
        var data = await _mediator.Send(new DeleteStateCommand(id));
        return ResponseHelper.GenerateReponse(data);
    }
}
