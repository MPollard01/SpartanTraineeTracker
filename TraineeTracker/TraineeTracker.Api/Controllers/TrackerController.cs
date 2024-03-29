﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraineeTracker.Application.DTOs.Tracker;
using TraineeTracker.Application.Features.Trackers.Requests.Commands;
using TraineeTracker.Application.Features.Trackers.Requests.Queries;
using TraineeTracker.Application.Responses;

namespace TraineeTracker.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TrackerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TrackerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<TrackerListDto>>> Get(bool loggedIn)
        {
            var trackers = await _mediator.Send(new GetTrackerListRequest { IsTraineeLoggedIn = loggedIn });
            return Ok(trackers);
        }

        [HttpGet("traineeId")]
        [EndpointName("TrackerAllByTraineeId")]
        public async Task<ActionResult<List<TrackerDto>>> Get(string traineeId)
        {
            var trackers = await _mediator.Send(new GetTrackerListByTraineeIdRequest { Id = traineeId });
            return Ok(trackers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TrackerDto>> Get(int id)
        {
            var tracker = await _mediator.Send(new GetTrackerDetailRequest { Id = id });
            return Ok(tracker);
        }

        [HttpGet("date")]
        [EndpointName("TrackerGETByDate")]
        public async Task<ActionResult<TrackerDto>> Get(DateTime date)
        {
            var tracker = await _mediator.Send(new GetTrackerByDateRequest { Date = date });
            return Ok(tracker);
        }

        [Authorize(Roles = "Trainer")]
        [HttpGet("trainer")]
        [EndpointName("TrackerAllbyTrainer")]
        public async Task<ActionResult<List<TrackerListDto>>> Get()
        {
            var trackers = await _mediator.Send(new GetTrackerListByTrainerRequest());
            return Ok(trackers);
        }

        [Authorize(Roles = "Trainer")]
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateTrackerDto trackerDto)
        {
            var command = new CreateTrackerCommand { TrackerDto = trackerDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
