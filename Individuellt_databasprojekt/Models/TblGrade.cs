using System;
using System.Collections.Generic;

namespace Individuellt_databasprojekt.Models;

public partial class TblGrade
{
    public int Id { get; set; }

    public int? StudentId { get; set; }

    public int? CourseId { get; set; }

    public int? Score { get; set; }

    public int? TeacherId { get; set; }

    public DateOnly? DateGraded { get; set; }

    public virtual TblCourse? Course { get; set; }

    public virtual TblStudent? Student { get; set; }

    public virtual TblTeacher? Teacher { get; set; }
}
