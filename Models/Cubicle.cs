using System;
using System.Collections.Generic;

namespace StoreApi.Models;

public partial class Cubicle
{
    public string Id { get; set; } = null!;

    public int Width { get; set; }

    public int Height { get; set; }

    public int Longitude { get; set; }

    public string IdClient { get; set; } = null!;

    public virtual ICollection<Footwear> Footwears { get; } = new List<Footwear>();

    public virtual Client IdClientNavigation { get; set; } = null!;

    public virtual ICollection<Undergarment> Undergarments { get; } = new List<Undergarment>();

    public virtual ICollection<Uppergarment> Uppergarments { get; } = new List<Uppergarment>();
}
