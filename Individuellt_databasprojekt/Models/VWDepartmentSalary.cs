using System;
using System.Collections.Generic;

namespace Individuellt_databasprojekt.Models;

public partial class VWDepartmentSalary
{
    public string DepartmentName { get; set; } = null!;

    public int? TotalSalary { get; set; }

    public int? AverageSalary { get; set; }
}
