CREATE DATABASE PED_Catedra
GO
USE PED_Catedra
GO

CREATE TABLE [Usuarios] (
  [IdUsuario] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
  [Nombre] NVARCHAR(100),
  [Apellido] NVARCHAR(100),
  [FechaNacimiento] DATE,
  [Correo] NVARCHAR(255) UNIQUE,
  [Usuario] NVARCHAR(100) UNIQUE,
  [Contraseña] NVARCHAR(255),
  [Rol] NVARCHAR(50)
)
GO

CREATE TABLE [Membresias] (
  [IdMembresia] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
  [Membresia] NVARCHAR(50),
  [Descripcion] NVARCHAR(255)
)
GO

CREATE TABLE [Clientes] (
  [IdCliente] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
  [IdUsuario] INT,
  [Direccion] NVARCHAR(255),
  [IdMembresia] INT,
  [FechaExpiracion] DATE NULL
)
GO

CREATE TABLE [Repartidores] (
  [IdRepartidor] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
  [DUI] NVARCHAR(10) UNIQUE,
  [CalificacionPromedio] FLOAT,
  [TotalCalificaciones] INT,
  [FechaRegistro] DATE,
  [IdUsuario] INT,
  [Disponibilidad] NVARCHAR(50)
)
GO

CREATE TABLE [EstadosPedidos] (
  [IdEstadoPedido] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
  [Estado] NVARCHAR(50)
)
GO

CREATE TABLE [Menus] (
  [IdMenu] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
  [NombreMenu] NVARCHAR(100),
  [Precio] DECIMAL(10,2),
  [Descripcion] NVARCHAR(255)
)
GO

CREATE TABLE [Pedidos] (
  [IdPedido] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
  [Descripcion] NVARCHAR(255),
  [IdCliente] INT,
  [HoraPedido] DATETIME,
  [HoraEntrega] DATETIME,
  [IdRepartidor] INT,
  [IdEstadoPedido] INT,
  [TotalPrecio] DECIMAL(10,2)
)
GO

CREATE TABLE [DetallesPedidos] (
  [IdDetallePedido] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
  [IdPedido] INT,
  [IdMenu] INT,
  [Cantidad] INT,
  [PrecioUnitario] DECIMAL(10,2)
)
GO

CREATE TABLE [Reviews] (
  [IdReview] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
  [IdRepartidor] INT,
  [IdPedido] INT,
  [Calificacion] INT,
  [Comentario] NVARCHAR(500),
  [FechaReview] DATE
)
GO

ALTER TABLE [Repartidores] ADD CONSTRAINT [fk_Repartidores_Usuario] FOREIGN KEY ([IdUsuario]) REFERENCES [Usuarios] ([IdUsuario]) ON UPDATE CASCADE ON DELETE CASCADE
GO

ALTER TABLE [Clientes] ADD CONSTRAINT [fk_Clientes_Usuario] FOREIGN KEY ([IdUsuario]) REFERENCES [Usuarios] ([IdUsuario]) ON UPDATE CASCADE ON DELETE CASCADE
GO

ALTER TABLE [Clientes] ADD CONSTRAINT [fk_Clientes_Membresia] FOREIGN KEY ([IdMembresia]) REFERENCES [Membresias] ([IdMembresia]) ON UPDATE CASCADE ON DELETE CASCADE
GO

ALTER TABLE [Reviews] ADD CONSTRAINT [fk_Reviews_Repartidor] FOREIGN KEY ([IdRepartidor]) REFERENCES [Repartidores] ([IdRepartidor]) ON UPDATE CASCADE ON DELETE CASCADE
GO

ALTER TABLE [Reviews] ADD CONSTRAINT [fk_Reviews_Pedido] FOREIGN KEY ([IdPedido]) REFERENCES [Pedidos] ([IdPedido]) ON UPDATE CASCADE ON DELETE CASCADE
GO

ALTER TABLE [Pedidos] ADD CONSTRAINT [fk_Pedidos_Cliente] FOREIGN KEY ([IdCliente]) REFERENCES [Clientes] ([IdCliente])
GO

ALTER TABLE Pedidos ADD CONSTRAINT fk_Pedido_Repartidor FOREIGN KEY (IdRepartidor) REFERENCES Repartidores (IdRepartidor)
GO

ALTER TABLE [Pedidos] ADD CONSTRAINT [fk_Pedidos_Estado] FOREIGN KEY ([IdEstadoPedido]) REFERENCES [EstadosPedidos] ([IdEstadoPedido]) ON UPDATE CASCADE ON DELETE CASCADE
GO

ALTER TABLE [DetallesPedidos] ADD CONSTRAINT [fk_DetallesPedidos_Pedido] FOREIGN KEY ([IdPedido]) REFERENCES [Pedidos] ([IdPedido]) ON UPDATE CASCADE ON DELETE CASCADE
GO

ALTER TABLE [DetallesPedidos] ADD CONSTRAINT [fk_DetallesPedidos_Menu] FOREIGN KEY ([IdMenu]) REFERENCES [Menus] ([IdMenu]) ON UPDATE CASCADE ON DELETE CASCADE
GO

-- Insert initial state into EstadosPedidos
INSERT INTO [EstadosPedidos] ([Estado]) VALUES ('Recien creado'),('Esperando confirmación'),('En camino'),('Entregado'),('Calificado');
GO

-- Insert Usuarios
INSERT INTO [Usuarios] ([Nombre], [Apellido], [FechaNacimiento], [Correo], [Usuario], [Contraseña], [Rol]) VALUES
('Carlos', 'Gomez', '1985-05-15', 'carlos.gomez@example.com', 'carlosg', '123', 'admin'),
('Maria', 'Lopez', '1990-07-22', 'maria.lopez@example.com', 'marial', 'Maria123', 'cliente'),
('Juan', 'Martinez', '1988-03-10', 'juan.martinez@example.com', 'juanm', 'Juan123', 'cliente'),
('Ana', 'Garcia', '1992-11-30', 'ana.garcia@example.com', 'anag', 'Ana123', 'cliente'),
('Laura', 'Perez', '1991-06-18', 'laura.perez@example.com', 'laurap', 'Laura123', 'cliente'),
('Daniel', 'Hernandez', '1991-02-20', 'danie@egmail.com', 'danie', '123', 'cliente'),
('Luis', 'Hernandez', '1987-09-25', 'luis.hernandez@example.com', 'luish', 'Luis123', 'repartidor'), --7
('Sofia', 'Ramirez', '1995-01-05', 'sofia.ramirez@example.com', 'sofiar', 'Sofia123', 'repartidor'),--8
('Miguel', 'Fernandez', '1983-12-12', 'miguel.fernandez@example.com', 'miguelf', 'Miguel123', 'repartidor');--9
GO

-- Insert Membresias
INSERT INTO [Membresias] ([Membresia], [Descripcion]) VALUES
('Basica', 'Acceso básico a los servicios'),
('Premium', 'Acceso premium a los servicios'),
('VIP', 'Acceso VIP a los servicios');
GO

-- Insert Clientes
INSERT INTO [Clientes] ([IdUsuario], [Direccion], [IdMembresia], [FechaExpiracion]) VALUES
(2, '123 Calle Principal', 1, NULL),
(3, '456 Avenida Secundaria', 1, NULL),
(4, '789 Boulevard Tercero', 2, '2024-12-31'),
(5, '321 Calle Cuarta', 2, '2024-12-31'),
(6, '654 Avenida Quinta', 3, '2025-12-31');
GO

-- Insert Repartidores
INSERT INTO [Repartidores] ([DUI], [CalificacionPromedio], [TotalCalificaciones], [FechaRegistro], [IdUsuario], [Disponibilidad]) VALUES
('12345678-9', 4.5, 100, '2023-04-01', 7, 'Disponible'),
('23456789-0', 4.7, 150, '2023-02-01', 8, 'Disponible'),
('34567890-1', 4.8, 200, '2023-01-01', 9, 'Disponible');
GO

-- Insert Menus
INSERT INTO [Menus] ([NombreMenu], [Precio], [Descripcion]) VALUES
('Pepperoni Pequeña', 10.00, 'Deliciosa pizza de pepperoni con queso mozzarella en tamaño pequeño'),
('Pepperoni Grande', 15.00, 'Deliciosa pizza de pepperoni con queso mozzarella en tamaño grande'),
('Hawaiana Pequeña', 12.00, 'Exquisita pizza hawaiana con piña y jamón en tamaño pequeño'),
('Hawaiana Grande', 18.00, 'Exquisita pizza hawaiana con piña y jamón en tamaño grande'),
('Jamon Pequeña', 11.00, 'Sabrosa pizza del mejor jamon en tamaño pequeño'),
('Jamon Grande', 17.00, 'Sabrosa pizza del mejor jamon en tamaño grande');
GO

-- Insert Pedidos
INSERT INTO [Pedidos] ([Descripcion], [IdCliente], [HoraPedido], [HoraEntrega], [IdRepartidor], [IdEstadoPedido], [TotalPrecio]) VALUES
('Pedido de prueba 1', 1, '2023-01-01 12:00:00', '2023-01-01 13:00:00', 1, 1, 30.00),
('Pedido de prueba 2', 2, '2023-01-02 12:00:00', '2023-01-02 13:00:00', 2, 3, 45.00),
('Pedido de prueba 3', 3, '2023-01-03 12:00:00', '2023-01-03 13:00:00', 3, 1, 60.00);
GO

-- Insert DetallesPedidos
INSERT INTO [DetallesPedidos] ([IdPedido], [IdMenu], [Cantidad], [PrecioUnitario]) VALUES
(1, 1, 2, 10.00),
(1, 3, 1, 12.00),
(2, 2, 1, 15.00),
(2, 4, 2, 18.00),
(3, 5, 1, 11.00),
(3, 6, 2, 17.00);
GO

-- Insert Reviews
INSERT INTO [Reviews] ([IdRepartidor], [IdPedido], [Calificacion], [Comentario], [FechaReview]) VALUES
(1, 1, 5, 'Excelente servicio', '2023-01-01'),
(2, 2, 4, 'Muy buen servicio', '2023-01-02'),
(3, 3, 5, 'Servicio excepcional', '2023-01-03');
GO
