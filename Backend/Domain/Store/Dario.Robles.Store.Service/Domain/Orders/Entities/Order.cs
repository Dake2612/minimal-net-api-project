﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Dario.Robles.Store.Service.Domain.Orders.Entities;

public partial class Order
{
    public Guid OrderId { get; set; }

    public string Code { get; set; }

    public DateTimeOffset? DeliverAt { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public string State { get; set; }

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}