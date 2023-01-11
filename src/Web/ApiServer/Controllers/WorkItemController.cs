﻿using Application.WorkItems.Commands;
using Application.WorkItems.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiServer.Controllers
{
    public class WorkItemController : CustomControllerBase
    {

        public WorkItemController(ISender mediator) : base(mediator) { }


        [HttpPost]
        public async Task<ActionResult<int>> PostWorkItem(
            CreateWorkItemRequest request)
        {
            return await Mediator.Send(new CreateWorkItemCommand(request));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> PutWorkItem(int id,
            UpdateWorkItemRequest request)
        {
            if (id != request.Id) return BadRequest();

            await Mediator.Send(new UpdateWorkItemCommand(request));

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> DeleteWorkItem(int id)
        {
            await Mediator.Send(new DeleteWorkItemCommand(id));

            return NoContent();
        }
    }
}