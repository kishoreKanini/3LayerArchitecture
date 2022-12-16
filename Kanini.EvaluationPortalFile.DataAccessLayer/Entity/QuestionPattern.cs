using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Kanini.EvaluationPortalFile.DataAccessLayer.Entity;

public partial class QuestionPattern
{
    public int QuestionPatternId { get; set; }

    public int MinimumExperience { get; set; }

    public int MaximumExperience { get; set; }

    public int? BasicNumberOfQuestion { get; set; }

    public int? IntermediateNumberOfQuestion { get; set; }

    public int? AdvanceNumberOfQuestion { get; set; }

    [JsonIgnore]
    public virtual ICollection<TestAttendeeHistory> TestAttendeeHistories { get; } = new List<TestAttendeeHistory>();
}
