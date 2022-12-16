using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace Kanini.EvaluationPortalFile.DataAccessLayer.Entity;

public partial class QuestionBank
{
    public int? SubjectId { get; set; }

    public int QuestionLevel { get; set; }

    public int QuestionId { get; set; }

    public string Question { get; set; } = null!;

    public string Answer { get; set; } = null!;

    public string Option1 { get; set; } = null!;

    public string Option2 { get; set; } = null!;

    public string Option3 { get; set; } = null!;

    public string Option4 { get; set; } = null!;

    public bool? IsActive { get; set; }

    [JsonIgnore]
    public virtual Subject? Subject { get; set; }

    [JsonIgnore]
    public virtual ICollection<TestHistory> TestHistories { get; } = new List<TestHistory>();
}
