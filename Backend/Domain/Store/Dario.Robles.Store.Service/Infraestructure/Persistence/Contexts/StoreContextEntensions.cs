using Dario.Robles.Store.Service.Domain.Orders.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dario.Robles.Store.Service.Infraestructure.Persistence.Contexts
{
    public partial class StoreContext : DbContext
    {
        public void EnsureSeedDataForContext()
        {
            Database.EnsureDeleted();
            Database.Migrate();
            SaveChanges();

            List<Order> orders = new List<Order>()
            {
                new Order()
                {
                    OrderId = new Guid("25320c5e-f58a-4b1f-b63a-8ee07a840bdf"),
                    Code = "00001",
                    CreatedAt = DateTime.Now,
                    State = "ready_to_deliver",
                    Items = new List<Item>()
                    {
                        new Item()
                        {
                            ItemId = new Guid("c7ba6add-09c4-45f8-8dd0-eaca221e5d93"),
                            Name = "manzanas",
                            Quantity = 5
                        },
                        new Item()
                        {
                            ItemId = new Guid("a3749477-f823-4124-aa4a-fc9ad5e79cd6"),
                            Name = "mandarinas",
                            Quantity = 6
                        },
                        new Item()
                        {
                            ItemId = new Guid("70a1f9b9-0a37-4c1a-99b1-c7709fc64167"),
                            Name = "platanos",
                            Quantity = 5
                        }
                    }
                },
                new Order()
                {
                    OrderId = new Guid("76053df4-6687-4353-8937-b45556748abe"),
                    Code = "00002",
                    CreatedAt = DateTime.Now,
                    State = "ready_to_deliver",
                    Items = new List<Item>()
                    {
                        new Item()
                        {
                            ItemId = new Guid("bc4c35c3-3857-4250-9449-155fcf5109ec"),
                            Name = "manzanas",
                            Quantity = 2
                        },
                        new Item()
                        {
                            ItemId = new Guid("09af5a52-9421-44e8-a2bb-a6b9ccbc8239"),
                            Name = "cebollas",
                            Quantity = 7
                        }
                    }
                },
                new Order()
                {
                    OrderId = new Guid("412c3012-d891-4f5e-9613-ff7aa63e6bb3"),
                    Code = "00003",
                    CreatedAt = DateTime.Now,
                    State = "ready_to_deliver",
                    Items = new List<Item>()
                    {
                        new Item()
                        {
                            ItemId = new Guid("9edf91ee-ab77-4521-a402-5f188bc0c577"),
                            Name = "papas",
                            Quantity = 5
                        },
                        new Item()
                        {
                            ItemId = new Guid("578359b7-1967-41d6-8b87-64ab7605587e"),
                            Name = "zanahorias",
                            Quantity = 6
                        },
                        new Item()
                        {
                            ItemId = new Guid("01457142-358f-495f-aafa-fb23de3d67e9"),
                            Name = "limones",
                            Quantity = 5
                        }
                    }
                },
                new Order()
                {
                    OrderId = new Guid("f74d6899-9ed2-4137-9876-66b070553f8f"),
                    Code = "00004",
                    CreatedAt = DateTime.Now,
                    State = "ready_to_deliver",
                    Items = new List<Item>()
                    {
                        new Item()
                        {
                            ItemId = new Guid("e57b605f-8b3c-4089-b672-6ce9e6d6c23f"),
                            Name = "peras",
                            Quantity = 5
                        }
                    }
                },
                new Order()
                {
                    OrderId = new Guid("1325360c-8253-473a-a20f-55c269c20407"),
                    Code = "00005",
                    CreatedAt = DateTime.Now,
                    State = "ready_to_deliver",
                    Items = new List<Item>()
                    {
                        new Item()
                        {
                            ItemId = new Guid("a1da1d8e-1988-4634-b538-a01709477b77"),
                            Name = "fresas",
                            Quantity = 5
                        }
                    }
                }
            };

            Orders.AddRange(orders);
            SaveChanges();
        }
    }
}
