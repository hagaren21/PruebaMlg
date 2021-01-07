create table Clientes
(
IdCliente int primary key IDENTITY(1,1),
Nombre varchar(50),
Apellidos varchar(50),
Direccion varchar(50)
);

create table Tiendas
(
IdTienda int primary key IDENTITY(1,1),
Sucursal varchar(50),
Direccion varchar(50)
);

create table RelClienteTienda
(
IdRelacion int primary key IDENTITY(1,1),
IdCliente int,
IdTienda int,
Monto money,
Fecha Date,
CONSTRAINT FK_Cliente FOREIGN KEY (IdCliente)
REFERENCES Clientes(IdCliente),
CONSTRAINT FK_Tienda FOREIGN KEY (IdTienda)
REFERENCES Tiendas(IdTienda)
);