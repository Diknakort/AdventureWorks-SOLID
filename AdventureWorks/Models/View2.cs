using System;
using System.Collections.Generic;

namespace AdventureWorks.Models;

public partial class View2
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public int ProductSubcategoryId { get; set; }

    public string SubCategoria { get; set; } = null!;
}
