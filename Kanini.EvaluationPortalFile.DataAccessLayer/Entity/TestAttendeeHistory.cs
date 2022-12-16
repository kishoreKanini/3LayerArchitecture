using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Kanini.EvaluationPortalFile.DataAccessLayer.Entity;

public partial class TestAttendeeHistory
{
    public int QuestionPaperCode { get; set; }

    public int? UserId { get; set; }

    public int? SubjectId { get; set; }

    public DateTime ExamStartTime { get; set; }

    public DateTime ExamEndTime { get; set; }

    public int Experience { get; set; }

    public DateTime DateOfExam { get; set; }

    public int? Marks { get; set; }

    public int? QuestionPatternId { get; set; }

    public virtual QuestionPattern? QuestionPattern { get; set; }

    public virtual Subject? Subject { get; set; }

    [JsonIgnore]
    public virtual ICollection<TestHistory> TestHistories { get; } = new List<TestHistory>();

    [JsonIgnore]
    public virtual User? User { get; set; }
}
