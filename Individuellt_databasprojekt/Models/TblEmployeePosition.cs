using System;
using System.Collections.Generic;

namespace Individuellt_databasprojekt.Models;

public partial class TblEmployeePosition
{
    public int? EmployeeId { get; set; }

    public int? PositionId { get; set; }

    public virtual TblEmployee? Employee { get; set; }

    public virtual TblPosition? Position { get; set; }
}
