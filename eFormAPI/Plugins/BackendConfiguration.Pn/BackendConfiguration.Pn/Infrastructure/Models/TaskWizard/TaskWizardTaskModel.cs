﻿namespace BackendConfiguration.Pn.Infrastructure.Models.TaskWizard;

using System;
using Enums;
using Microting.eFormApi.BasePn.Infrastructure.Models.Common;
using System.Collections.Generic;

public class TaskWizardTaskModel
{
    public int Id { get; set; }
    public int PropertyId { get; set; }
    public int FolderId { get; set; }
    public List<int> Tags { get; set; } = new();
    public List<CommonTranslationsModel> Translations { get; set; } = new();
    public int EformId { get; set; }
    public string EformName { get; set; }
    public DateTime StartDate { get; set; }
    public RepeatType RepeatType { get; set; }
    public int RepeatEvery { get; set; }
    public TaskWizardStatuses Status { get; set; }
    public List<int> AssignedTo { get; set; } = new();
}