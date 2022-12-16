using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Kanini.EvaluationPortalFile.DataAccessLayer.Entity;

public partial class Subject
{
    public int SubjectId { get; set; }

    public string SubjectName { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<QuestionBank> QuestionBanks { get; } = new List<QuestionBank>();

    [JsonIgnore]
    public virtual ICollection<TestAttendeeHistory> TestAttendeeHistories { get; } = new List<TestAttendeeHistory>();
}
