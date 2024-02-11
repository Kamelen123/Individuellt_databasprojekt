using System;
using System.Collections.Generic;

namespace Individuellt_databasprojekt.Models;

public partial class TblStudent
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Personnummer { get; set; }

    public string Class { get; set; } = null!;

    public DateOnly? EnrolmentDate { get; set; }

    public string? PhoneNumber { get; set; }

    public virtual ICollection<TblGrade> TblGrades { get; set; } = new List<TblGrade>();
}
