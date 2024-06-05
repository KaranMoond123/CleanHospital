using Application.Features.Countries.Commands;
using Application.Features.Countries.Commands.CreateCountries;
using Application.Features.Countries.Commands.DeletedCountries;
using Application.Features.Countries.Commands.UpdateCountries;
using Application.Features.Countries.Queries.GetAllCountries;
using Application.Features.Countries.Queries.GetCountrybyId;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.CountriesControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CountryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult>Post(CreateCommandCountry command)
        {
            var data=await _mediator.Send(command);
            return ResponseHelper.GenerateReponse(data);
        }
        [HttpGet]
        public async Task<ActionResult>GetAll()
        {
            var data = await _mediator.Send(new GetAllCountryQuery());
            return ResponseHelper.GenerateReponse(data);
        }
        [HttpGet]
        [Route("api/Country/{id}")]
        public async Task<ActionResult>GetByID(int id)
        {
            var data=await _mediator.Send(new GetCountryByIdquary (id));
            return ResponseHelper.GenerateReponse(data);
        }
        [HttpPut]
        [Route("api/Country/{id}")]
        public async Task<ActionResult>Put(int id , CreateCommandCountry command)
        {
            var data=await _mediator.Send(new UpdateCountryCommand (id, command));
            return ResponseHelper.GenerateReponse(data);
        }
        [HttpDelete]
        [Route("api/Country/{id}")]
        public async Task<ActionResult>Deleted(int id)
        {
            var data=await _mediator.Send(new DeleteCountryCommand (id));
            return ResponseHelper.GenerateReponse(data);
        }
    }
}
