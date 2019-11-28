--!!!!!!!
--begin transaction
--CREACION DE TABLAS
create table Funcionalidades(
	funcionalidad_id smallint identity(1,1) primary key,
	funcionalidad_nombre nvarchar(100) not null unique
)

create table Roles(
	rol_id smallint identity(1,1) primary key,
	rol_nombre nvarchar(100) not null unique,
	habilitado bit default 1
)

create table FuncionalidadPorRol(
	rol_id smallint foreign key references Roles(rol_id),
	funcionalidad_id smallint foreign key references Funcionalidades(funcionalidad_id),
	primary key(rol_id, funcionalidad_id)
)

create table Usuarios(
	nombre_usuario nvarchar(255) primary key,
	password nvarchar(255) not null,
	intentos smallint default 0,
	habilitado bit default 1
)

create table UsuarioPorRol(
	rol_id smallint foreign key references Roles(rol_id),
	nombre_usuario nvarchar(255) foreign key references Usuarios(nombre_usuario),
	primary key(rol_id,nombre_usuario)
)

create table Administradores(
	administrativo_id smallint identity(1,1) primary key,
	nombre_usuario nvarchar(255) not null foreign key references Usuarios(nombre_usuario)
)

create table Clientes (
	dni numeric(18,0) primary key,
	cliente_nombre nvarchar(255) not null,
	cliente_apellido nvarchar(255) not null,
	fecha_nacimiento datetime not null,
	ciudad nvarchar(255) not null,
	codigo_postal nvarchar(20),
	telefono numeric(18,0) not null,
	email nvarchar(255) not null,
	direccion nvarchar(255) not null,
	piso smallint,
	dpto char,
	habilitado bit default 1,
	nombre_usuario nvarchar(255),
	saldo numeric(18,2)
)

create table Rubros(
	rubro_id int identity(1,1) primary key,
	rubro_nombre nvarchar(50) not null unique
)

create table Proveedores(
	cuit nvarchar(20)  primary key,
	rs nvarchar(100) not null,
	email nvarchar(255),
	telefono numeric(18,0) not null,
	ciudad nvarchar(255) not null,
	codigo_postal nvarchar(20),
	rubro_id int not null,
	nombre_contacto nvarchar(100),
	direccion nvarchar(255) not null,
	piso smallint,
	dpto char,
	habilitado bit default 1,
	nombre_usuario nvarchar(255)
)

create table Ofertas(
	oferta_id nvarchar(50) primary key,
	fecha_publicacion datetime not null,
	fecha_vto datetime not null,
	precio_oferta numeric(18,2) not null,
	precio_viejo numeric(18,2) not null,
	proveedor_cuit nvarchar(20) not null,
	stock smallint,
	oferta_descripcion nvarchar(255) not null,
	limite_compra_por_us smallint
)

create table Detalles_Tarjeta(
	tarjeta_id numeric(18,0) primary key,
	titular nvarchar(255) not null,
	fecha_vto datetime not null
)

create table Cargas_credito(
	carga_id int identity(1,1) primary key,
	carga_fecha datetime not null,
	monto numeric(18,2) not null,
	cliente_dni numeric(18,0),
	forma_de_pago nvarchar(100) not null,
	tarjeta_id numeric (18,0)
)

create table Reportes_Facturacion(
	reporte_id numeric(18,0) primary key,
	proveedor_cuit nvarchar(20) not null,
	fecha_minima datetime,
	fecha_maxima datetime not null,
	importe_total numeric(18,2) not null
)

create table Cupones(
	cupon_id int identity(1,1) primary key,
	fecha_consumo datetime,
	fecha_compra datetime not null,
	cliente_comprador_dni numeric(18,0) not null,
	cliente_canjeador_dni numeric(18,0),
	oferta_id nvarchar(50) not null,
	reporte_id numeric(18,0)
)
go

--Migración
create procedure migrar_clientes
as
begin
	insert into Clientes (dni,cliente_nombre, cliente_apellido, fecha_nacimiento, ciudad,telefono, email, direccion)
		select Cli_Dni,Cli_Nombre,Cli_Apellido, Cli_Fecha_Nac, Cli_Ciudad, Cli_Telefono, Cli_Mail, Cli_Direccion
		from gd_esquema.Maestra where Cli_Apellido is not null
		group by Cli_Nombre,Cli_Apellido,Cli_Dni, Cli_Fecha_Nac, Cli_Ciudad, Cli_Telefono, Cli_Mail, Cli_Direccion
end
go

create procedure migrar_rubros
as
begin
	insert into Rubros (rubro_nombre)
		select distinct Provee_Rubro from gd_esquema.Maestra where Provee_Rubro is not null
end
go

create procedure migrar_proveedores
as
begin
	insert into Proveedores (rs, telefono, ciudad, cuit, rubro_id, direccion)
		select distinct Provee_RS, Provee_Telefono, Provee_Ciudad, Provee_CUIT, rubro_id, Provee_Dom
		from gd_esquema.Maestra,Rubros where Provee_CUIT is not null and rubro_nombre=Provee_Rubro
end
go

create procedure migrar_ofertas
as
begin
	insert into ofertas (oferta_id, fecha_publicacion, fecha_vto, precio_oferta, precio_viejo, proveedor_cuit, stock, oferta_descripcion)
		select Oferta_Codigo, Oferta_Fecha, Oferta_Fecha_Venc, Oferta_Precio, Oferta_Precio_Ficticio, cuit,Oferta_Cantidad, Oferta_Descripcion
		from gd_esquema.Maestra join Proveedores on (provee_rs=rs) where Oferta_Codigo is not null
		group by Oferta_Codigo, Oferta_Fecha, Oferta_Fecha_Venc, Oferta_Precio, Oferta_Precio_Ficticio, cuit, Oferta_Cantidad, Oferta_Descripcion
	
end
go

create procedure migrar_cargas
as
begin
	insert into Cargas_credito (carga_fecha,monto,cliente_dni,forma_de_pago)
		select Carga_Fecha,Carga_Credito,dni,Tipo_Pago_Desc
		from gd_esquema.Maestra join Clientes c on (Cli_Dni=c.dni) where Carga_Fecha is not null
end
go

create procedure migrar_reportes
as
begin
	insert into Reportes_Facturacion (reporte_id, proveedor_cuit, fecha_maxima, importe_total)
		select Factura_Nro, cuit, Factura_Fecha,sum(oferta_precio)
		from gd_esquema.Maestra join Proveedores on (cuit=Provee_CUIT)
		where Factura_Nro is not null
		group by Factura_Nro, cuit, Factura_Fecha

end
go

create procedure migrar_cupones
as
begin
	insert into Cupones (fecha_compra, cliente_comprador_dni,cliente_canjeador_dni,oferta_id,reporte_id)
		select Oferta_Fecha_Compra, Cli_Dni,Cli_Dni, Oferta_Codigo,Factura_Nro
		from gd_esquema.Maestra 
		where Oferta_Fecha_Compra is not null and Factura_Nro is not null
end
go

create procedure migrar_tablas
as
begin
	exec migrar_clientes;
	exec migrar_rubros;
	exec migrar_proveedores;
	exec migrar_ofertas;
	exec migrar_cargas;
	exec migrar_reportes;
	exec migrar_cupones;

end
go

exec migrar_tablas;
go

--Agregando constraints
alter table Clientes
add constraint fk_usuario foreign key (nombre_usuario) references Usuarios(nombre_usuario),
	constraint saldo_default default 200 for saldo,
	constraint uc_cliente unique(telefono,email);
go

alter table proveedores
add constraint fk_rubro foreign key (rubro_id) references Rubros(rubro_id),
	constraint fk_proveedor_usuario foreign key (nombre_usuario) references Usuarios(nombre_usuario),
	constraint uc_proveedor unique(rs,email,telefono);
go

alter table ofertas
add constraint fk_proveedor_of  foreign key (proveedor_cuit) references Proveedores(cuit);
go

alter table cargas_credito
add constraint fk_cliente foreign key (cliente_dni) references Clientes(dni),
	constraint fk_tarjeta foreign key (tarjeta_id) references Detalles_Tarjeta(tarjeta_id);
go

alter table reportes_facturacion
add constraint fk_proveedor_rep foreign key (proveedor_cuit) references Proveedores(cuit);
go

alter table cupones
add	constraint fk_comprador foreign key (cliente_comprador_dni) references Clientes(dni),
	constraint fk_canjeador foreign key (cliente_canjeador_dni) references Clientes(dni),
	constraint fk_oferta foreign key (oferta_id) references Ofertas(oferta_id),
	constraint fk_reporte foreign key (reporte_id) references Reportes_facturacion(reporte_id)
go


create procedure usuario_existente (
	@name nvarchar(255)
)
as
begin
	declare @returned smallint
	if(exists(select * from Usuarios where nombre_usuario=@name))
	begin
		set @returned= 1
	end
	else
	begin
		set @returned= (-1)
	end
	return @returned
end
go

create procedure cliente_existente (
	@dni nvarchar(255)
)
as
begin
	declare @v numeric(18,0) = (select TRY_CONVERT(numeric(18,0),@dni))
	declare @returned smallint
	if(exists(select * from Clientes where dni=@v))
	begin
		set @returned= 1
	end
	else
	begin
		set @returned= (-1)
	end
	return @returned
end
go

create procedure usuario_con_rol_existente(
	@rol_id smallint,
	@username nvarchar(255)
)
as
begin
	declare @returned smallint
	if(exists(select * from UsuarioPorRol where rol_id=@rol_id and nombre_usuario=@username))
	begin
		set @returned= 1
	end
	else
	begin
		set @returned= (-1)
	end
	return @returned
end
go

create procedure obtener_funcionalidades_del_rol  (@r smallint)
as
	select f1.funcionalidad_id,funcionalidad_nombre from FuncionalidadPorRol f1 join Funcionalidades f2 on (f1.funcionalidad_id=f2.funcionalidad_id) where rol_id=@r;
go

create procedure rol_habilitado (
	@id smallint
)
as
begin
	declare @returned smallint
	if(exists(select * from Roles where rol_id=@id and habilitado=1))
	begin
		set @returned = 1
	end
	else
	begin
		set @returned = (-1)
	end
	return @returned
end
go

create view FuncionalidadesPorRolView
as
	select r.rol_id,rol_nombre,habilitado, f.funcionalidad_id, funcionalidad_nombre 
	from Roles r join FuncionalidadPorRol fr on(r.rol_id=fr.rol_id)
				 join Funcionalidades f on (fr.funcionalidad_id=f.funcionalidad_id)
go

create procedure buscar_cliente_segun_usuario(
	@user nvarchar(255)
)
as

	declare @returned numeric(18,0) = (select dni from Clientes where nombre_usuario=@user)
	return @returned
go

create procedure cargar_credito (
	@dni numeric(18,0),
	@monto numeric(18,2),
	@fecha_de_carga datetime,
	@forma_pago nvarchar(100),
	@tarj_num numeric(18,0),
	@fecha_venc datetime,
	@titular nvarchar(255)
)
as
begin
	begin transaction
		begin try
			if(not exists(select tarjeta_id from Detalles_Tarjeta where tarjeta_id=@tarj_num))
			begin
				insert into Detalles_Tarjeta (tarjeta_id,titular,fecha_vto) values (@tarj_num,@titular,@fecha_venc)
			end
			insert into Cargas_credito (carga_fecha,monto,cliente_dni,forma_de_pago,tarjeta_id)
				   values (@fecha_de_carga,@monto,@dni,@forma_pago,@tarj_num)
			commit transaction
		end try
		begin catch
			rollback
		end catch
end
go

create procedure publicar_oferta (
	@oferta_id nvarchar(50),
	@stock smallint,
	@limite_de_compra smallint,
	@precio_viejo numeric(18,2),
	@precio_nuevo numeric(18,2),
	@cuit nvarchar(20),
	@descr nvarchar(255),
	@fecha_pub datetime,
	@fecha_venc datetime
)
as
begin
	begin try
		insert into Ofertas values(@oferta_id,@fecha_pub,@fecha_venc,@precio_nuevo,@precio_viejo,@cuit,@stock,@descr,@limite_de_compra)
	end try
	begin catch
		throw 50001,'Se ingresaron mal los campos. Ingreselos de nuevo correctamente',16;
	end catch
end
go

/*create function obtenerFechaDelConfig() returns datetime
begin
	declare @fecha datetime;
	TODO
	return getdate()
end
go*/
create view OfertasDisponiblesView
as
	select * from Ofertas where GETDATE()>=fecha_publicacion and GETDATE()<=fecha_vto;
go

create procedure saldo_disponible(
	@user_name nvarchar(255)
)
as
begin
	declare @returned numeric(18,2);
	set @returned = (select saldo from Clientes where nombre_usuario=@user_name)
	return @returned
end
go

create procedure comprar_oferta (
	@user_name nvarchar(255),
	@oferta_id nvarchar(50)
)
as
begin
	begin transaction

	declare @saldo_disponible numeric(18,2), @precio numeric(18,2), @limite_por_us smallint,@fecha_actual datetime,@dni_comprador numeric(18,0),@compras_realizadas_del_cliente smallint,@stock smallint

	exec @saldo_disponible = saldo_disponible @user_name;
	select @precio=precio_oferta,@limite_por_us=limite_compra_por_us,@stock=stock from Ofertas where oferta_id = @oferta_id;
	set @fecha_actual = getdate() --obtener del config
	set @dni_comprador = (select dni from Clientes where nombre_usuario=@user_name)
	set @compras_realizadas_del_cliente  = (select count(*) from Cupones where cliente_comprador_dni=@dni_comprador and oferta_id=@oferta_id)
	
	if(@stock<0)
	begin
		rollback;
		throw 50003,'Stock insuficiente',16;
	end
	if(@saldo_disponible< @precio)
	begin
		rollback;
		throw 50002,'No hay saldo suficiente',16;
	end
	if(@compras_realizadas_del_cliente>=@limite_por_us)
	begin
		rollback;
		throw 50004,'Ha realizado demasiadas compras de dicha oferta',16;
	end
	insert into Cupones (fecha_compra,cliente_comprador_dni,oferta_id) values (@fecha_actual,@dni_comprador,@oferta_id);
	update Clientes set saldo = (@saldo_disponible-@precio) where nombre_usuario=@user_name;
	update Ofertas set stock = stock-1 where oferta_id=@oferta_id
	commit transaction;
end
go

create procedure cargar_consumo_de_cupon (
	@dni numeric(18,0),
	@fecha_consumo datetime,
	@cuit nvarchar(20),
	@cupon_id int
)
as
begin
	begin transaction
	declare @cup int, @oferta nvarchar(50),@proveedor nvarchar(20), @fecha_limite datetime, @consumido datetime;

	if(not exists(select * from Cupones where cupon_id=@cupon_id))
	begin
		rollback;
		throw 50005,'No existe un cupon con ese código',16;
	end
	select @oferta=c.oferta_id,@proveedor=proveedor_cuit,@cup=cupon_id,@fecha_limite=fecha_vto,@consumido=fecha_consumo from Cupones c join Ofertas o on(c.oferta_id=o.oferta_id and c.cupon_id=@cupon_id)
	if(@cuit!=@proveedor)
	begin
		rollback;
		throw 50008,'El proveedor ingresado no realizo la oferta del cupon',16;
	end
	if(not exists(select dni from Clientes where dni=@dni))
	begin
		rollback;
		throw 50009,'No existe un cliente con ese dni',16;
	end
	if(@consumido is null)
	begin
		rollback;
		throw 50006,'El cupon ya ha sido consumido',16;
	end
	if(@fecha_consumo>@fecha_limite)
	begin
		rollback;
		throw 50007,'El cupon se ha vencido.',16;
	end
	update Cupones set fecha_consumo=@fecha_consumo,cliente_canjeador_dni=@dni where cupon_id=@cupon_id
	commit transaction;
end
go
--rollback