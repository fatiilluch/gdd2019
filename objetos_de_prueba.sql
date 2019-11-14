--Carga inicial del Sistema!!!!!!!
-------------------------------------------------------------------------------

--Usuario admin
	insert into Usuarios (nombre_usuario,password) values ('admin','f446c8d778f9139e45b488b3c823369567f055e2a5e11e765ce1f3164267ac03')

--Usuario Cliente
	insert into Usuarios (nombre_usuario,password) values ('user1','f446c8d778f9139e45b488b3c823369567f055e2a5e11e765ce1f3164267ac03')

--Roles de prueba para probar el combobox 
	insert into Roles (rol_nombre) values ('Cliente')
	insert into Roles (rol_nombre) values ('Proveedor')
	insert into Roles (rol_nombre) values ('Administrador')

--Funcionalidades
	insert into Funcionalidades (funcionalidad_nombre) values ('Registrar usuario')
	insert into Funcionalidades (funcionalidad_nombre) values ('Registrar cliente')
	insert into Funcionalidades (funcionalidad_nombre) values ('Registrar proveedor')
	insert into Funcionalidades (funcionalidad_nombre) values ('Crear oferta')
	insert into Funcionalidades (funcionalidad_nombre) values ('Listar ofertas')
