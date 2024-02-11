using System;
using System.Collections.Generic;

namespace Individuellt_databasprojekt.Models;

public partial class TblTeacher
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public int DepartmentId { get; set; }

    public virtual TblDepartment Department { get; set; } = null!;

    public virtual TblEmployee Employee { get; set; } = null!;

    public virtual ICollection<TblCourse> TblCourses { get; set; } = new List<TblCourse>();

    public virtual ICollection<TblGrade> TblGrades { get; set; } = new List<TblGrade>();
}
