-- bd de minisuper

create database MinisuperDB;

use MinisuperDB;


create table Negocio(
	NegocioId int primary key identity (1,1),
	NombreNegocio varchar (100) not null,
	Direccion varchar (200) not null,
	Telefono varchar (15) not null,
	MensajeTicket varchar (250) null
);

Create table Cargo(
	CargoId int primary key identity(1,1),
	Nombrecargo varchar(30) unique not null 
);

Create table Rol(
	RolId int primary key identity (1,1),
	TipoRol varchar(35) unique not null,
	Descripcion varchar(150) null
);

Create table Cliente(
	ClienteId int primary key identity (1,1),
	DUI varchar(35) unique  null, 
);

Create table EstadoUsuario(
	EstadoUsuarioId int primary key identity (1,1),
	TipoEsado varchar(35)  
);

create table FormaPago(
	FormaPagoId int primary key identity (1,1),
	TipoPago varchar (50) not null
);

create table Categoria(
	CategoriaId int primary key identity (1,1),
	NombreCategoria varchar(50) unique null
);

create table EstadoProducto(
	EstadoProductoId int primary key identity (1,1),
	TipoEstado varchar (50) not null
);

create table Proveedor(
	ProveedorId int primary key identity (1,1),
	NombreEmpresa varchar(50) null unique,
	NombreProveedor varchar (50) not null,
	ApellidoProveedor varchar(50) not null,
	TipoProveedor varchar (50) check(TipoProveedor in('individual', 'Empresa')),
	DUI varchar(10) not null unique,
	Telefono varchar (10) not null unique,
	Correo varchar (35) not null unique,
	Direccion varchar (100) not null
);

Create table Empleado(
	EmpleadoId int primary key identity(1,1),
	PrimerNombre varchar(25) not null,
	SegundoNombre varchar(25) not null,
	PrimerApellido varchar(25) not null,
	SegundoApellido varchar(25) not null,
	DUI varchar(10) not null unique,
	Telefono varchar(10) not null unique,
	Correo varchar(100) not null unique,
	Direccion varchar(100) not null,
	CargoId int foreign key references Cargo(CargoId)
);


Create table Usuario(
	UsuarioId int primary key identity(1,1),
	NombreUsuario varchar(50) not null unique,
	Clave varchar(40) not null,
	FechaCreacion datetime default getdate(),
	RolId int foreign key references Rol(RolId),
	EmpleadoId int foreign key references Empleado(EmpleadoId),
	EstadoUsuarioId int foreign key references EstadoUsuario(EstadoUsuarioId)
);


Create table Venta(
	VentaId int primary key identity(1,1),
	FechaHora datetime default getdate(),
	NumeroTicket int not null unique,
	UsuarioId int foreign key references Usuario(UsuarioId),
	ClienteId int foreign key references Cliente(ClienteId),
	Iva decimal(10,2) not null,
	Subtotal money not null,
	Total money not null
);

create table Pago(
	PagoId int primary key identity (1,1),
	VentaId int foreign key references Venta(VentaId),
	FormaPagoId int foreign key references FORMAPAGO(FormaPagoId),
	Monto decimal (10,2) not null,
	MontoRecibido decimal (10,2) not null,
	Cambio decimal (10,2) not null,
);

create table Producto(
	ProductoId int primary key identity (1,1),
	CodigoBarra varchar(50) not null unique,
	NombreProducto  varchar (50),
	UnidadMedida varchar (50),
	PrecioVenta money not null,
	CategoriaId int foreign key references Categoria(CategoriaId),
	EstadoProductoId int foreign key references EstadoProducto (EstadoProductoId)
);

create table Inventario(
	InventarioId int primary key identity (1,1),
	ProductoId int foreign key references Producto(ProductoId),
	StockActual int not null default 0, 
	StockMinimo int not null default 0, 
	CostoPromedio decimal (10,2) not null default 0.00
 );


Create table DetalleVenta(
	DetventaId int primary key identity(1,1),
	VentaId int foreign key references Venta(VentaId),
	Cantidad int not null,
	ProductoId int foreign key references Producto(ProductoId),
	Precio money not null,
	Subtotal money not null
);

create table Compra(
	CompraId int primary key identity (1,1),
	NombreFactura varchar (25),
	FechaHora datetime default getdate(),
	DetVentaId int foreign key references DetalleVenta(DetVentaId),
	UsuarioId int foreign key references Usuario(UsuarioId)
);

create table DetalleCompra(
	DetCompraId int primary key identity (1,1),
	CompraId int foreign key references Compra(Compraid),
	Cantidad int not null,
	ProveedorId int foreign key references Proveedor(Proveedorid),
	UsuarioId int foreign key references Usuario(UsuarioId),
	Total money not null
);


Create table LoteInventario(
	LoteInventarioId int primary key identity (1,1),
	DetCompraId int foreign key references DetalleCompra(DetCompraId),
	FechaIngreso datetime default getdate(),
	StockInicialId int not null,
	StockActualId int not null
);	

create table DetalleInventario(
	DetInventarioId int primary key identity(1,1),
	InventarioId int foreign key references Inventario(InventarioId),
	LoteInventarioId int foreign key references LoteInventario(LoteInventarioId),
	FechaHoraMovimiento datetime default getdate(),
	TipoMovimiento varchar(50) not null,
	Cantidad int not null,
	Observacion varchar(255) null,
	DetventaId int foreign key references DetalleVenta(DetventaId)
);



