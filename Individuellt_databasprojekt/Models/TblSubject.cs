using System;
using System.Collections.Generic;

namespace Individuellt_databasprojekt.Models;

public partial class TblSubject
{
    public int Id { get; set; }

    public string SubjectName { get; set; } = null!;

    public virtual ICollection<TblCourse> TblCourses { get; set; } = new List<TblCourse>();
}
