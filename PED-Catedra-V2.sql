CREATE DATABASE PED_Catedra
GO
USE PED_Catedra
GO

CREATE TABLE [Usuarios] (
  [IdUsuario] integer PRIMARY KEY NOT NULL,
  [Nombre] NVARCHAR(100),
  [Apellido] NVARCHAR(100),
  [FechaNacimiento] DATE,
  [Correo] NVARCHAR(255) UNIQUE,
  [Usuario] NVARCHAR(100) UNIQUE,
  [Contraseña] NVARCHAR(255),
  [Rol] NVARCHAR(50)
)
GO

CREATE TABLE [Clientes] (
  [IdCliente] integer PRIMARY KEY NOT NULL,
  [IdUsuario] integer,
  [Direccion] NVARCHAR(255),
  [IdMembresia] integer,
  [FechaExpiracion] DATE
)
GO

CREATE TABLE [Repartidores] (
  [IdRepartidor] integer PRIMARY KEY NOT NULL,
  [DUI] NVARCHAR(10) UNIQUE,
  [CalificacionPromedio] FLOAT,
  [TotalCalificaciones] integer,
  [FechaRegistro] DATE,
  [IdUsuario] integer,
  [Disponibilidad] NVARCHAR(50)
)
GO

CREATE TABLE [Membresias] (
  [IdMembresia] integer PRIMARY KEY NOT NULL,
  [Membresia] NVARCHAR(50),
  [Descripcion] NVARCHAR(255)
)
GO

CREATE TABLE [Reviews] (
  [IdReview] integer PRIMARY KEY NOT NULL,
  [IdRepartidor] integer,
  [IdPedido] integer,
  [Calificacion] integer,
  [Comentario] NVARCHAR(500),
  [FechaReview] DATE
)
GO

CREATE TABLE [EstadosPedidos] (
  [IdEstadoPedido] integer PRIMARY KEY NOT NULL,
  [Estado] NVARCHAR(50)
)
GO

CREATE TABLE [Pedidos] (
  [IdPedido] integer PRIMARY KEY NOT NULL,
  [Descripcion] NVARCHAR(255),
  [IdCliente] integer,
  [HoraPedido] DATETIME,
  [HoraEntrega] DATETIME,
  [IdRepartidor] integer,
  [IdEstadoPedido] integer,
  [TotalPrecio] DECIMAL(10,2)
)
GO

CREATE TABLE [DetallesPedidos] (
  [IdDetallePedido] integer PRIMARY KEY NOT NULL,
  [IdPedido] integer,
  [IdMenu] integer,
  [Cantidad] integer,
  [PrecioUnitario] DECIMAL(10,2)
)
GO

CREATE TABLE [Menus] (
  [IdMenu] integer PRIMARY KEY NOT NULL,
  [NombreMenu] NVARCHAR(100),
  [Precio] DECIMAL(10,2),
  [Descripcion] NVARCHAR(255)
)
GO

ALTER TABLE [Repartidores] ADD CONSTRAINT [fk_Repartidores_Usuario] FOREIGN KEY ([IdUsuario]) REFERENCES [Usuarios] ([IdUsuario])
GO

ALTER TABLE [Clientes] ADD CONSTRAINT [fk_Clientes_Usuario] FOREIGN KEY ([IdUsuario]) REFERENCES [Usuarios] ([IdUsuario])
GO

ALTER TABLE [Clientes] ADD CONSTRAINT [fk_Clientes_Membresia] FOREIGN KEY ([IdMembresia]) REFERENCES [Membresias] ([IdMembresia])
GO

ALTER TABLE [Reviews] ADD CONSTRAINT [fk_Reviews_Repartidor] FOREIGN KEY ([IdRepartidor]) REFERENCES [Repartidores] ([IdRepartidor])
GO

ALTER TABLE [Reviews] ADD CONSTRAINT [fk_Reviews_Pedido] FOREIGN KEY ([IdPedido]) REFERENCES [Pedidos] ([IdPedido])
GO

ALTER TABLE [Pedidos] ADD CONSTRAINT [fk_Pedidos_Cliente] FOREIGN KEY ([IdCliente]) REFERENCES [Clientes] ([IdCliente])
GO

ALTER TABLE [Pedidos] ADD CONSTRAINT [fk_Pedidos_Repartidor] FOREIGN KEY ([IdRepartidor]) REFERENCES [Repartidores] ([IdRepartidor])
GO

ALTER TABLE [Pedidos] ADD CONSTRAINT [fk_Pedidos_Estado] FOREIGN KEY ([IdEstadoPedido]) REFERENCES [EstadosPedidos] ([IdEstadoPedido])
GO

ALTER TABLE [DetallesPedidos] ADD CONSTRAINT [fk_DetallesPedidos_Pedido] FOREIGN KEY ([IdPedido]) REFERENCES [Pedidos] ([IdPedido])
GO

ALTER TABLE [DetallesPedidos] ADD CONSTRAINT [fk_DetallesPedidos_Menu] FOREIGN KEY ([IdMenu]) REFERENCES [Menus] ([IdMenu])
GO



