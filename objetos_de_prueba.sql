--Carga inicial del Sistema!!!!!!!
-------------------------------------------------------------------------------

--Usuario admin
	insert into Usuarios (nombre_usuario,password) values ('admin','e79bdc0fdce8b1d14a2a3edd4d900dd09edca47001dbb8fc4381cbbf5070b8e6')
	
--Usuario Cliente
	insert into Usuarios (nombre_usuario,password) values ('user1','f446c8d778f9139e45b488b3c823369567f055e2a5e11e765ce1f3164267ac03')

--Usuario Proveedor
	insert into Usuarios (nombre_usuario,password) values ('user2','f446c8d778f9139e45b488b3c823369567f055e2a5e11e765ce1f3164267ac03')

--Usuario Con mas de un rol
	insert into Usuarios (nombre_usuario,password) values ('user3','f446c8d778f9139e45b488b3c823369567f055e2a5e11e765ce1f3164267ac03')
	
--Roles
	insert into Roles (rol_nombre) values ('administrador general')
	insert into Roles (rol_nombre) values ('proveedor')
	insert into Roles (rol_nombre) values ('cliente')

--Usuario Por Rol
	insert into UsuarioPorRol select rol_id,'admin' from Roles where rol_nombre='administrador General'
	insert into UsuarioPorRol select rol_id,'user1' from Roles where rol_nombre='cliente'
	insert into UsuarioPorRol select rol_id,'user2' from Roles where rol_nombre='proveedor'
	insert into UsuarioPorRol select rol_id,'user3' from Roles where rol_nombre='cliente' or rol_nombre='proveedor'

--Funcionalidades
	insert into Funcionalidades (funcionalidad_nombre) values ('Registrar usuario')
	insert into Funcionalidades (funcionalidad_nombre) values ('Abm de cliente')
	insert into Funcionalidades (funcionalidad_nombre) values ('Abm de proveedor')
	insert into Funcionalidades (funcionalidad_nombre) values ('Crear oferta')
	insert into Funcionalidades (funcionalidad_nombre) values ('Comprar oferta')
	insert into Funcionalidades (funcionalidad_nombre) values ('Registrar consumo')
	insert into Funcionalidades (funcionalidad_nombre) values ('Listar estadisticas')
	insert into Funcionalidades (funcionalidad_nombre) values ('Realizar reporte de facturacion')
	insert into Funcionalidades (funcionalidad_nombre) values ('Abm de rol')
	insert into Funcionalidades (funcionalidad_nombre) values ('Carga de credito')
	insert into Funcionalidades (funcionalidad_nombre) values ('Consumo de oferta')
	
 --Funcionalidad Por Rol
	insert into FuncionalidadPorRol (rol_id,funcionalidad_id) values (3,5)
	insert into FuncionalidadPorRol (rol_id,funcionalidad_id) values (1,1)
	insert into FuncionalidadPorRol (rol_id,funcionalidad_id) values (1,2)
	insert into FuncionalidadPorRol (rol_id,funcionalidad_id) values (1,3)
	insert into FuncionalidadPorRol (rol_id,funcionalidad_id) values (1,4)
	insert into FuncionalidadPorRol (rol_id,funcionalidad_id) values (1,7)
	insert into FuncionalidadPorRol (rol_id,funcionalidad_id) values (1,8)
	insert into FuncionalidadPorRol (rol_id,funcionalidad_id) values (2,4)
	insert into FuncionalidadPorRol (rol_id,funcionalidad_id) values (2,6)
	insert into FuncionalidadPorRol (rol_id,funcionalidad_id) values (1,9)
	insert into FuncionalidadPorRol (rol_id,funcionalidad_id) values (3,10)
	insert into FuncionalidadPorRol (rol_id,funcionalidad_id) values (1,10)
	insert into FuncionalidadPorRol (rol_id,funcionalidad_id) values (1,11)
	insert into FuncionalidadPorRol (rol_id,funcionalidad_id) values (2,11)
	
--Cliente asociado a user1
	insert into Clientes (dni,cliente_nombre,cliente_apellido,fecha_nacimiento,ciudad,codigo_postal,telefono,email,direccion,nombre_usuario)
	values (39655888,'santu','feijoo',getdate(),'london ahre','1406',4625857,'santuuu','quirno y junta','user1')

--Proveedor asociado a user2
	insert into Proveedores (rs,email,telefono,codigo_postal,ciudad,cuit,rubro_id,nombre_contacto,direccion,nombre_usuario)
	values
	('Lo de tu vieja sa','sadsada',129384,'cp de london','london :v','20.120312933',1,'ivan','Quirno','user2')

--Cliente y proveedor asociado a user3
	insert into Clientes (dni,cliente_nombre,cliente_apellido,fecha_nacimiento,ciudad,codigo_postal,telefono,email,direccion,nombre_usuario)
	values (396888,'chskl','muz',getdate(),'london ahre','1406',48425857,'tusd8dada','quirno y junta','user3')

	insert into Proveedores (rs,email,telefono,codigo_postal,ciudad,cuit,rubro_id,nombre_contacto,direccion,nombre_usuario)
	values
	('Lo deeja sa','sq2asddsada',458756,'cp del london','tambien london :v','20.1312933',1,'ivan','Quirno','user3')
