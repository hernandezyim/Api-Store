using System;
using System.Collections.Generic;

namespace StoreApi.Models;

public partial class Uppergarment
{
    public string Id { get; set; } = null!;

    public string Brand { get; set; } = null!;

    public string Color { get; set; } = null!;

    public int Size { get; set; }

    public string Kind { get; set; } = null!;

    public bool States { get; set; }

    public string IdClient { get; set; } = null!;

    public string IdCubicle { get; set; } = null!;

    public virtual Client IdClientNavigation { get; set; } = null!;

    public virtual Cubicle IdCubicleNavigation { get; set; } = null!;
}
