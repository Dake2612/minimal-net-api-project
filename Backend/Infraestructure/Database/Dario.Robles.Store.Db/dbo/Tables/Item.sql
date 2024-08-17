CREATE TABLE [dbo].[Item] (
    [ItemId]   UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [OrderId]  UNIQUEIDENTIFIER NOT NULL,
    [Name]     NVARCHAR (100)   NOT NULL,
    [Quantity] INT              NOT NULL,
    CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED ([ItemId] ASC),
    CONSTRAINT [FK_Item_Order] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Order] ([OrderId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Item_OrderId]
    ON [dbo].[Item]([OrderId] ASC);

