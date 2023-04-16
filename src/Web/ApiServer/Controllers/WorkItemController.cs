﻿using ApiServer.Identity;
using Application.Common.Services;
using Application.WorkItems.Commands;
using Application.WorkItems.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiServer.Controllers
{
    public class WorkItemController : CustomControllerBase
    {

        public WorkItemController(ISender mediator) : base(mediator) { }


        [HttpPost]
        [Authorize(Permission.WriteProjects)]
        public async Task<ActionResult<int>> PostWorkItem(
            CreateWorkItemRequest request)
        {
            return await Mediator.Send(new CreateWorkItemCommand(request));
        }

        [HttpPut("{id}")]
        [Authorize(Permission.WriteProjects)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> PutWorkItem(int id,
            UpdateWorkItemRequest request)
        {
            if (id != request.Id) return BadRequest();

            await Mediator.Send(new UpdateWorkItemCommand(request));

            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Permission.WriteProjects)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> DeleteWorkItem(int id)
        {
            await Mediator.Send(new DeleteWorkItemCommand(id));

            return Ok();
        }
    }
}
