using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Kanini.EvaluationPortalFile.DataAccessLayer.Entity;

public partial class User
{
    public int UserId { get; set; }

    public string Email { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool IsAdmin { get; set; }

    [JsonIgnore]
    public virtual ICollection<TestAttendeeHistory> TestAttendeeHistories { get; } = new List<TestAttendeeHistory>();
}
