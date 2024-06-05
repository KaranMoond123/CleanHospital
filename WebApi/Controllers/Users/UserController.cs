using Application.Features.Dcouments.Commands.CreateDocuments;
using Application.Features.Users.Commands.CreateUsers;
using Application.Features.Users.Commands.Logins;
using Application.Features.Users.Queries.GetAllUsers;
using Domain.Entities.Employees;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Peristance.DataContext;

namespace WebApi.Controllers.Users;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ApplicationdbContext _dbContext;

    public UserController(IMediator mediator, ApplicationdbContext dbContext)
    {
        _mediator = mediator;
        _dbContext = dbContext;
    }
    [HttpPost]
    public async Task<ActionResult> Post(CreateuserCommand command)
    {
        var data = await _mediator.Send(command);
        return ResponseHelper.GenerateReponse(data);
    }
    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var data = await _mediator.Send(new GetUserQuery());
        return ResponseHelper.GenerateReponse(data);
    }
    [HttpPost("LogIn")]
    [Authorize]
    public async Task<ActionResult> PostToken(CreateLoginCommand command)
    {
        var data =await _mediator.Send(command);
        return ResponseHelper.GenerateReponse(data);
    }

    [HttpPost("document")]
    public async Task<ActionResult> PostDocument([FromForm]CreateDcoumentCommand command)
    {
        var data=await _mediator.Send(command);
        return ResponseHelper.GenerateReponse(data);
    }

    [HttpPost("Employee")]
    public  async Task<ActionResult> CreateEMploye(EmployeeDto command)
    {
        var data = new Employee
        {
            Name = command.Name,
            City = command.City,
            PostalCode = command.PostalCode,
            Country = command.Country,
            
        };
        await _dbContext.AddAsync(data);
        await _dbContext.SaveChangesAsync();
        return Ok();    
    }

   public class EmployeeDto
    {
      
        public string Name { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }
        public int Country { get; set; }
    }
}

