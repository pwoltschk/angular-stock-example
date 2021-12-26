﻿using Application.WorkItems.Commands;
using Application.WorkItems.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WorkItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<int>> PostWorkItem(
            CreateWorkItemRequest request)
        {
            return await _mediator.Send(new CreateWorkItemCommand(request));
        }
    }
}
