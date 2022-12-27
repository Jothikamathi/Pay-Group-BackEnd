using System;
using System.Collections.Generic;

namespace payapi.Models;

public partial class TbComponent
{
    public int ComponentCode { get; set; }

    public string? StartDate { get; set; }

    public string? EndDate { get; set; }

    public string? ComponentDescription { get; set; }

    public string? MonthlyLimit { get; set; }

    public string? FortNightLimit { get; set; }
}
