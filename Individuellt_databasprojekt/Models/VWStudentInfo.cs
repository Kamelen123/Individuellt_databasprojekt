using System;
using System.Collections.Generic;

namespace Individuellt_databasprojekt.Models;

public partial class VWStudentInfo
{
    public int StudentId { get; set; }

    public string StudentFullName { get; set; } = null!;

    public string Class { get; set; } = null!;

    public string CourseName { get; set; } = null!;

    public string Grade { get; set; } = null!;

    public string GradedBy { get; set; } = null!;

    public DateOnly? DateGraded { get; set; }
}
