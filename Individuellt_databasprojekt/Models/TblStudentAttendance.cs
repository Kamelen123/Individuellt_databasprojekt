using System;
using System.Collections.Generic;

namespace Individuellt_databasprojekt.Models;

public partial class TblStudentAttendance
{
    public int? StudentId { get; set; }

    public int? CourseId { get; set; }

    public virtual TblCourse? Course { get; set; }

    public virtual TblStudent? Student { get; set; }
}
