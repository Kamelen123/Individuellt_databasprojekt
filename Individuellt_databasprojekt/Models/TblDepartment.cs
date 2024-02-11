using System;
using System.Collections.Generic;

namespace Individuellt_databasprojekt.Models;

public partial class TblDepartment
{
    public int Id { get; set; }

    public string DepartmentName { get; set; } = null!;

    public virtual ICollection<TblTeacher> TblTeachers { get; set; } = new List<TblTeacher>();
}
