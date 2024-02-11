using System;
using System.Collections.Generic;

namespace Individuellt_databasprojekt.Models;

public partial class TblEmployee
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string? Adress { get; set; }

    public int? Salary { get; set; }

    public DateOnly? DateStart { get; set; }

    public virtual ICollection<TblTeacher> TblTeachers { get; set; } = new List<TblTeacher>();
}
