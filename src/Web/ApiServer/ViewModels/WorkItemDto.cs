﻿namespace ApiServer.ViewModels;

public class WorkItemDto
{
    public int Id { get; init; }

    public int? ProjectId { get; set; }

    public string Title { get; init; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Iteration { get; set; } = string.Empty;

    public string AssignedTo { get; set; } = string.Empty;

    public DateTime? StartDate { get; set; }

    public int Priority { get; set; }

    public int Stage { get; set; }
}