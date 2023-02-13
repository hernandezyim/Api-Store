using System;
using System.Collections.Generic;

namespace StoreApi.Models;

public partial class Client
{
    public string Id { get; set; } = null!;

    public string Dni { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<Cubicle> Cubicles { get; } = new List<Cubicle>();

    public virtual ICollection<Footwear> Footwears { get; } = new List<Footwear>();

    public virtual ICollection<Undergarment> Undergarments { get; } = new List<Undergarment>();

    public virtual ICollection<Uppergarment> Uppergarments { get; } = new List<Uppergarment>();
}
