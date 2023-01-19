using MediatR;
using Microsoft.AspNetCore.Mvc;
using Twitter.Application.Features.TwitterStatistics;
using Twitter.Application.Features.TwitterStatistics.Commands.CreateTwitterStatistic;
using Twitter.Application.Features.TwitterStatistics.Commands.DeleteTwitterStatistic;
using Twitter.Application.Features.TwitterStatistics.Commands.UpdateTwitterStatistic;
using Twitter.Application.Features.TwitterStatistics.Queries.GetTwitterStatisticsExport;
using Twitter.Application.Features.TwitterStatistics.Queries.GetTwitterStatisticsList;
using Twitter.Api.Utility;
using Twitter.Application.Features.TwitterStatistics.Queries.GetMostRecentTwitterStatisticDetail;
using Microsoft.AspNetCore.Authorization;

namespace Twitter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TwitterStatisticController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TwitterStatisticController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllTwitterStatistics")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<TwitterStatisticListVm>>> GetAllTwitterStatistics()
        {
            var dtos = await _mediator.Send(new GetTwitterStatisticsListQuery());
            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetTwitterStatisticById")]
        public async Task<ActionResult<TwitterStatisticDetailVm>> GetTwitterStatisticById(int id)
        {
            var getTwitterStatisticDetailQuery = new GetTwitterStatisticDetailQuery() { Id = id };
            return Ok(await _mediator.Send(getTwitterStatisticDetailQuery));
        }

        [HttpGet("recent", Name = "GetMostRecentTwitterStatistic")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<TwitterStatisticDetailVm>> GetMostRecentTwitterStatistic()
        {
            var dtos = await _mediator.Send(new GetMostRecentTwitterStatisticsDetailQuery());
            return Ok(dtos);
        }


        [HttpPost(Name = "AddTwitterStatistic")]
        public async Task<ActionResult<CreateTwitterStatisticCommandResponse>> Create
            ([FromBody] CreateTwitterStatisticCommand createTwitterStatisticCommand)
        {
            var response = await _mediator.Send(createTwitterStatisticCommand);
            return Ok(response);
        }

        [HttpPut(Name = "UpdateTwitterStatistic")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update
            ([FromBody] UpdateTwitterStatisticCommand updateTwitterStatisticCommand)
        {
            await _mediator.Send(updateTwitterStatisticCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteTwitterStatistic")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var deleteTwitterStatisticCommand = new DeleteTwitterStatisticCommand() { Id = id };
            await _mediator.Send(deleteTwitterStatisticCommand);
            return NoContent();
        }

        [HttpGet("export", Name = "ExportTwitterStatistics")]
        [FileResultContentType("text/csv")]
        public async Task<FileResult> ExportEvents()
        {
            var fileDto = await _mediator.Send(new GetTwitterStatisticsExportQuery());

            return File(fileDto.Data, fileDto.ContentType, fileDto.EventExportFileName);
        }
    }
}
