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
                },
                new Order()
                {
                    OrderId = new Guid("21320c5e-f58a-423f-b63a-8ee07a840bdf"),
                    Code = "00006",
                    CreatedAt = DateTime.Now.AddDays(-5),
                    DeliverAt = DateTime.Now.AddDays(-1),
                    State = "delivered",
                    Items = new List<Item>()
                    {
                        new Item()
                        {
                            ItemId = new Guid("c7416add-09c4-45f8-8ae0-eaa322e55d93"),
                            Name = "apio",
                            Quantity = 2
                        }
                    }
                },
                new Order()
                {
                    OrderId = new Guid("76ae1df4-66af-435f-8937-b452ee748abe"),
                    Code = "00007",
                    CreatedAt = DateTime.Now.AddDays(-1),
                    State = "registered",
                    Items = new List<Item>()
                    {
                        new Item()
                        {
                            ItemId = new Guid("3f4cfbc3-3857-4250-9fa9-155f3e5109ec"),
                            Name = "papaya",
                            Quantity = 2
                        }
                    }
                },
                new Order()
                {
                    OrderId = new Guid("44fe7012-d84e-4f5e-9672-ff7aa4ae6bbe"),
                    Code = "00008",
                    CreatedAt = DateTime.Now.AddDays(-4),
                    State = "ready_to_deliver",
                    Items = new List<Item>()
                    {
                        new Item()
                        {
                            ItemId = new Guid("9edf28d0-ab77-453a-a4bb-5f1a1e80c55b"),
                            Name = "mango",
                            Quantity = 2
                        }
                    }
                },
                new Order()
                {
                    OrderId = new Guid("2e4d6ce5-9ee2-4121-9876-66b09ca25f8f"),
                    Code = "00009",
                    CreatedAt = DateTime.Now.AddDays(-4),
                    DeliverAt = DateTime.Now.AddDays(-1),
                    State = "delivered",
                    Items = new List<Item>()
                    {
                        new Item()
                        {
                            ItemId = new Guid("e57bd10f-8ba3-40a2-b63b-6ce9e8c0222a"),
                            Name = "uva",
                            Quantity = 5
                        }
                    }
                },
                new Order()
                {
                    OrderId = new Guid("131aed82-82c1-43fa-a24f-55c2fef20407"),
                    Code = "00010",
                    CreatedAt = DateTime.Now.AddDays(-1),
                    State = "registered",
                    Items = new List<Item>()
                    {
                        new Item()
                        {
                            ItemId = new Guid("a1da1c1e-19be-4634-b248-a0170ed72b77"),
                            Name = "lucuma",
                            Quantity = 2
                        }
                    }
                },
                new Order()
                {
                    OrderId = new Guid("d183f8bc-d79c-4a14-8a1d-3de9942f7bd4"),
                    Code = "00011",
                    CreatedAt = DateTime.Now,
                    State = "ready_to_deliver",
                    Items = new List<Item>()
                    {
                        new Item()
                        {
                            ItemId = new Guid("8d70cf44-3653-4f4d-8ab3-1dbdf6f5d8a9"),
                            Name = "naranjas",
                            Quantity = 8
                        },
                        new Item()
                        {
                            ItemId = new Guid("3b1f5a2a-8d2e-4987-8f2b-11923908d1e2"),
                            Name = "kiwis",
                            Quantity = 4
                        }
                    }
                },

                new Order()
                {
                    OrderId = new Guid("e8d46f6f-54d4-43ea-bf78-fd4b9c9fcdcd"),
                    Code = "00012",
                    CreatedAt = DateTime.Now.AddDays(-2),
                    State = "ready_to_deliver",
                    Items = new List<Item>()
                    {
                        new Item()
                        {
                            ItemId = new Guid("4c58c8b5-89b4-4d83-896a-d383e2e6e1d4"),
                            Name = "cerezas",
                            Quantity = 10
                        },
                        new Item()
                        {
                            ItemId = new Guid("fa9d7bdf-b073-4ec9-bfe1-f68b7a2fdc50"),
                            Name = "melones",
                            Quantity = 3
                        }
                    }
                },
                new Order()
                {
                    OrderId = new Guid("48cfb3a4-4b8e-4b12-9cf4-c8dc7d5b3cdd"),
                    Code = "00013",
                    CreatedAt = DateTime.Now,
                    State = "ready_to_deliver",
                    Items = new List<Item>()
                    {
                        new Item()
                        {
                            ItemId = new Guid("b8360c5a-8c5a-4a68-bd8d-0b9b7dcb04b8"),
                            Name = "piñas",
                            Quantity = 6
                        },
                        new Item()
                        {
                            ItemId = new Guid("013f6887-5b67-48cb-9f68-8e8c5a2f2a70"),
                            Name = "peras",
                            Quantity = 4
                        }
                    }
                },
                new Order()
                {
                    OrderId = new Guid("f0c6d82d-5eb5-4f4b-9b4c-c1a22fc3d13b"),
                    Code = "00014",
                    CreatedAt = DateTime.Now,
                    State = "ready_to_deliver",
                    Items = new List<Item>()
                    {
                        new Item()
                        {
                            ItemId = new Guid("7b6b1cc4-8de5-45f1-a5e8-01670bfa07b5"),
                            Name = "arándanos",
                            Quantity = 7
                        },
                        new Item()
                        {
                            ItemId = new Guid("cdb9a6a7-404f-4de4-bd6b-2079e5292d7d"),
                            Name = "sandías",
                            Quantity = 2
                        }
                    }
                },
                new Order()
                {
                    OrderId = new Guid("2f34ff2c-7aaf-476e-9bca-ec17d1c2cf32"),
                    Code = "00015",
                    CreatedAt = DateTime.Now.AddDays(-3),
                    State = "ready_to_deliver",
                    Items = new List<Item>()
                    {
                        new Item()
                        {
                            ItemId = new Guid("b1a7f815-3162-4d6a-b7e9-b219519f7022"),
                            Name = "higos",
                            Quantity = 6
                        },
                        new Item()
                        {
                            ItemId = new Guid("87414ba1-31ea-4d32-874b-7a86dd52e3c3"),
                            Name = "toronjas",
                            Quantity = 4
                        }
                    }
                },
                new Order()
                {
                    OrderId = new Guid("6b8cf46e-6f6b-4907-aabc-1d982d6f3bc9"),
                    Code = "00016",
                    CreatedAt = DateTime.Now,
                    State = "ready_to_deliver",
                    Items = new List<Item>()
                    {
                        new Item()
                        {
                            ItemId = new Guid("5c0dce98-2641-4ff6-b6f1-62e865d48d34"),
                            Name = "cocos",
                            Quantity = 5
                        },
                        new Item()
                        {
                            ItemId = new Guid("41c98937-0816-44e7-b148-942f9c7c36b2"),
                            Name = "frutillas",
                            Quantity = 8
                        }
                    }
                },
                new Order()
                {
                    OrderId = new Guid("f8de75b2-7343-4906-8a98-80b142c6c55e"),
                    Code = "00017",
                    CreatedAt = DateTime.Now.AddDays(-1),
                    State = "registered",
                    Items = new List<Item>()
                    {
                        new Item()
                        {
                            ItemId = new Guid("1b4478e5-1f57-4d7f-97b8-019b2f81fdc3"),
                            Name = "granadas",
                            Quantity = 2
                        }
                    }
                },
                new Order()
                {
                    OrderId = new Guid("48135cda-b0f1-4c6b-b9f2-1ecb2041bb5f"),
                    Code = "00018",
                    CreatedAt = DateTime.Now,
                    State = "ready_to_deliver",
                    Items = new List<Item>()
                    {
                        new Item()
                        {
                            ItemId = new Guid("06cc1e0f-4681-432f-a23e-bdc4ea1c98b9"),
                            Name = "limones",
                            Quantity = 10
                        },
                        new Item()
                        {
                            ItemId = new Guid("f9e187d5-16c5-49c7-9077-1fb503e4bcd5"),
                            Name = "guayabas",
                            Quantity = 5
                        }
                    }
                },
                new Order()
                {
                    OrderId = new Guid("d8d2a8a4-1ba4-44f3-8e84-e86fba4ffcd1"),
                    Code = "00019",
                    CreatedAt = DateTime.Now,
                    State = "ready_to_deliver",
                    Items = new List<Item>()
                    {
                        new Item()
                        {
                            ItemId = new Guid("b95c1ed5-c1ba-4e4c-995c-5c0476345b22"),
                            Name = "frambuesas",
                            Quantity = 8
                        },
                        new Item()
                        {
                            ItemId = new Guid("913eea24-6767-4f9d-86ed-973ac6d391ed"),
                            Name = "melocotones",
                            Quantity = 5
                        }
                    }
                },
                new Order()
                {
                    OrderId = new Guid("6c99fd71-90b4-4782-a854-f68859408b5d"),
                    Code = "00020",
                    CreatedAt = DateTime.Now.AddDays(-1),
                    State = "registered",
                    Items = new List<Item>()
                    {
                        new Item()
                        {
                            ItemId = new Guid("f0510c64-98f2-476d-9c63-5c88ecfa1b6e"),
                            Name = "nectarinas",
                            Quantity = 3
                        },
                        new Item()
                        {
                            ItemId = new Guid("f1730bdb-d5ff-4a6b-a4f4-d688c43e3bb1"),
                            Name = "pitajayas",
                            Quantity = 4
                        }
                    }
                }
            };

            Orders.AddRange(orders);
            SaveChanges();
        }
    }
}
