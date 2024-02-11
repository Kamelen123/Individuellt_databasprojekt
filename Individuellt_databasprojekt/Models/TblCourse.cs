using System;
using System.Collections.Generic;

namespace Individuellt_databasprojekt.Models;

public partial class TblCourse
{
    public int Id { get; set; }

    public string CourseName { get; set; } = null!;

    public string Active { get; set; } = null!;

    public int? TeacherId { get; set; }

    public int? SubjectId { get; set; }

    public virtual TblSubject? Subject { get; set; }

    public virtual ICollection<TblGrade> TblGrades { get; set; } = new List<TblGrade>();

    public virtual TblTeacher? Teacher { get; set; }
}
