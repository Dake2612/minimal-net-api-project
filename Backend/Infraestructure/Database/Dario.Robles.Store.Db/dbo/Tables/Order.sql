CREATE TABLE [dbo].[Order] (
    [OrderId]   UNIQUEIDENTIFIER   DEFAULT (newid()) NOT NULL,
    [Code]      VARCHAR (20)       NOT NULL,
    [DeliverAt] DATETIMEOFFSET (7) NULL,
    [CreatedAt] DATETIMEOFFSET (7) NOT NULL,
    [State]     VARCHAR (20)       NOT NULL,
    CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED ([OrderId] ASC)
);

