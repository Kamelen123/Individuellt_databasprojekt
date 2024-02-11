using System;
using System.Collections.Generic;

namespace Individuellt_databasprojekt.Models;

public partial class ScoreReference
{
    public string ScoreRange { get; set; } = null!;

    public int MinScore { get; set; }

    public int MaxScore { get; set; }

    public string Grade { get; set; } = null!;

    public string PassFail { get; set; } = null!;
}
