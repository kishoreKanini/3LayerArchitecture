using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Kanini.EvaluationPortalFile.DataAccessLayer.Entity;

public partial class TestHistory
{
    public int SerialNumber { get; set; }

    public int? QuestionPaperCode { get; set; }

    public int? QuestionId { get; set; }

    public string OptionChosen { get; set; } = null!;

    [JsonIgnore]
    public virtual QuestionBank? Question { get; set; }

    [JsonIgnore]
    public virtual TestAttendeeHistory? QuestionPaperCodeNavigation { get; set; }
}
