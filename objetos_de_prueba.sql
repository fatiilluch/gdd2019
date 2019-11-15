--Carga inicial del Sistema!!!!!!!
-------------------------------------------------------------------------------

--Usuario admin
	insert into Usuarios (nombre_usuario,password) values ('admin','f446c8d778f9139e45b488b3c823369567f055e2a5e11e765ce1f3164267ac03')

--Usuario Cliente
	insert into Usuarios (nombre_usuario,password) values ('user1','f446c8d778f9139e45b488b3c823369567f055e2a5e11e765ce1f3164267ac03')

--Usuario Proveedor
	insert into Usuarios (nombre_usuario,password) values ('user2','f446c8d778f9139e45b488b3c823369567f055e2a5e11e765ce1f3164267ac03')

--Usuario Por Rol
	insert into UsuarioPorRol select rol_id,'admin' from Roles where rol_nombre='Administrador'
	insert into UsuarioPorRol select rol_id,'user1' from Roles where rol_nombre='Cliente'
	insert into UsuarioPorRol select rol_id,'user2' from Roles where rol_nombre='Proveedor'

--Roles de prueba para probar el combobox 
	insert into Roles (rol_nombre) values ('Administrador')
	insert into Roles (rol_nombre) values ('Proveedor')
	insert into Roles (rol_nombre) values ('Cliente')
--Funcionalidades
	insert into Funcionalidades (funcionalidad_nombre) values ('Registrar usuario')
	insert into Funcionalidades (funcionalidad_nombre) values ('Registrar cliente')
	insert into Funcionalidades (funcionalidad_nombre) values ('Registrar proveedor')
	insert into Funcionalidades (funcionalidad_nombre) values ('Crear oferta')
	insert into Funcionalidades (funcionalidad_nombre) values ('Comprar Oferta')
	insert into Funcionalidades (funcionalidad_nombre) values ('Registrar Consumo')
	insert into Funcionalidades (funcionalidad_nombre) values ('Listar Estadisticas')
	insert into Funcionalidades (funcionalidad_nombre) values ('Listar ofertas')
	insert into Funcionalidades (funcionalidad_nombre) values ('Realizar Reporte de facturacion')
	insert into Funcionalidades (funcionalidad_nombre) values ('Alta de rol')
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

