------------------------------------------------
-- cliente
------------------------------------------------
CREATE TABLE cliente
(
  id_cliente INT NOT NULL IDENTITY(1,1),
  nombre VARCHAR(100) NOT NULL,
  apellido VARCHAR(100) NOT NULL,
  dni INT NOT NULL,
  telefono INT,
  email VARCHAR(200) NOT NULL,
  activo INT NOT NULL CONSTRAINT df_cliente_activo DEFAULT 1, -- SI = 1 y NO = 0  
  sexo VARCHAR(20) CONSTRAINT df_cliente_sexo DEFAULT 'Otros',
  fecha_nacimiento DATE,
  CONSTRAINT pk_cliente PRIMARY KEY (id_cliente),
  CONSTRAINT uq_cliente_dni UNIQUE (dni),
  CONSTRAINT uq_cliente_email UNIQUE (email),
  CONSTRAINT ck_cliente_dni CHECK (dni BETWEEN 10000000 AND 99999999),
  CONSTRAINT ck_cliente_telefono CHECK (telefono BETWEEN 1000000000 AND 9999999999),
  CONSTRAINT ck_cliente_activo CHECK (activo IN (0, 1)),
  CONSTRAINT ck_cliente_sexo CHECK (sexo IN ('Masculino','Femenino','Otros')),
  CONSTRAINT ck_cliente_fecha_nacimiento CHECK ((DATEDIFF(year, fecha_nacimiento, GETDATE()) BETWEEN 18 AND 100) AND (fecha_nacimiento <= GETDATE()))
);

------------------------------------------------
-- categoria
------------------------------------------------
CREATE TABLE categoria
(
  id_categoria INT NOT NULL IDENTITY(1,1),
  descripcion VARCHAR(100) NOT NULL,
  activo INT NOT NULL, -- SI = 1 y NO = 0
  CONSTRAINT pk_categoria PRIMARY KEY (id_categoria),
  CONSTRAINT ck_categoria_activo CHECK (activo IN (0, 1)),
);

------------------------------------------------
-- marca
------------------------------------------------
CREATE TABLE marca
(
  id_marca INT NOT NULL IDENTITY(1,1),
  descripcion VARCHAR(100) NOT NULL,
  activo INT NOT NULL, -- SI = 1 y NO = 0
  CONSTRAINT pk_marca PRIMARY KEY (id_marca),
  CONSTRAINT ck_marca_activo CHECK (activo IN (0, 1))
);

------------------------------------------------
-- producto
------------------------------------------------
CREATE TABLE producto
(
  id_producto INT NOT NULL IDENTITY(1,1),
  nombre VARCHAR(100) NOT NULL,
  descripcion VARCHAR(200),
  precio DECIMAL(10,2) NOT NULL,
  stock INT NOT NULL CONSTRAINT df_producto_stock DEFAULT 0,
  imagen VARCHAR(200),
  eliminado INT NOT NULL CONSTRAINT df_producto_eliminado DEFAULT 1, -- NO = 1 y SI = 0
  precio_vta DECIMAL(10,2) NOT NULL,
  id_marca INT NOT NULL,
  id_categoria INT NOT NULL,
  CONSTRAINT pk_producto PRIMARY KEY (id_producto),
  CONSTRAINT fk_producto_marca FOREIGN KEY (id_marca) REFERENCES marca(id_marca),
  CONSTRAINT fk_producto_categoria FOREIGN KEY (id_categoria) REFERENCES categoria(id_categoria),
  CONSTRAINT ck_producto_precio CHECK (precio >= 0),
  CONSTRAINT ck_producto_precio_vta CHECK ((precio_vta >= 0) AND (precio_vta <= precio)),
  CONSTRAINT ck_producto_stock CHECK (stock >= 0),
  CONSTRAINT ck_producto_eliminado CHECK (eliminado IN (0, 1))
);

------------------------------------------------
-- perfil
------------------------------------------------
CREATE TABLE perfil
(
  id_perfil INT NOT NULL,
  descripcion VARCHAR(100) NOT NULL,
  activo INT NOT NULL, -- SI = 1 y NO = 0
  CONSTRAINT pk_perfil PRIMARY KEY (id_perfil),
  CONSTRAINT ck_perfil_activo CHECK (activo IN (0,1))
);

------------------------------------------------
-- usuario
------------------------------------------------
CREATE TABLE usuario
(
  id_usuario INT NOT NULL IDENTITY(1,1),
  nombre VARCHAR(100) NOT NULL,
  apellido VARCHAR(100) NOT NULL,
  email VARCHAR(200) NOT NULL,
  pass VARBINARY(256) NOT NULL,
  activo INT NOT NULL CONSTRAINT df_usuario_activo DEFAULT 1, -- SI = 1 y NO = 0
  sexo VARCHAR(20) CONSTRAINT df_usuario_sexo DEFAULT 'Otros',
  fecha_nacimiento DATE,
  telefono INT,
  dni INT NOT NULL,
  id_perfil INT NOT NULL,
  CONSTRAINT pk_usuario PRIMARY KEY (id_usuario),
  CONSTRAINT fk_usuario_perfil FOREIGN KEY (id_perfil) REFERENCES perfil(id_perfil),
  CONSTRAINT uq_usuario_email UNIQUE (email),
  CONSTRAINT uq_usuario_dni UNIQUE (dni),
  CONSTRAINT ck_usuario_activo CHECK (activo IN (0, 1)),
  CONSTRAINT ck_usuario_sexo CHECK (sexo IN ('Masculino', 'Femenino', 'Otros')),
  CONSTRAINT ck_usuario_fecha_nacimiento CHECK ((DATEDIFF(year, fecha_nacimiento, GETDATE()) BETWEEN 18 AND 100) AND (fecha_nacimiento <= GETDATE())),
  CONSTRAINT ck_usuario_telefono CHECK (telefono BETWEEN 1000000000 AND 9999999999),
  CONSTRAINT ck_usuario_dni CHECK (dni BETWEEN 10000000 AND 99999999),
);

------------------------------------------------
-- venta_cabecera
------------------------------------------------
CREATE TABLE venta_cabecera
(
  id_venta INT NOT NULL IDENTITY(1,1),
  fecha DATE NOT NULL CONSTRAINT df_venta_cabecera_fecha DEFAULT GETDATE(),
  total_venta DECIMAL(10,2) NOT NULL,
  tipo_factura CHAR(1) NOT NULL,
  id_usuario INT NOT NULL,
  id_cliente INT NOT NULL,
  CONSTRAINT pk_venta_cabecera PRIMARY KEY (id_venta),
  CONSTRAINT fk_venta_cabecera_usuario FOREIGN KEY (id_usuario) REFERENCES usuario(id_usuario),
  CONSTRAINT fk_venta_cabecera_cliente FOREIGN KEY (id_cliente) REFERENCES cliente(id_cliente),
  CONSTRAINT ck_venta_cabecera_total_venta CHECK (total_venta >= 0),
  CONSTRAINT ck_venta_cabecera_fecha CHECK (fecha <= GETDATE()),
  CONSTRAINT ck_venta_cabecera_tipo_factura CHECK (tipo_factura IN ('A','B','C','M','E','T'))
);

------------------------------------------------
-- venta_cabecera
------------------------------------------------
CREATE TABLE venta_detalle
(
  id_detalle INT NOT NULL IDENTITY(1,1),
  cantidad INT NOT NULL,
  precio_unitario DECIMAL(10,2) NOT NULL,
  id_venta INT NOT NULL,
  id_producto INT NOT NULL,
  CONSTRAINT pk_venta_detalle PRIMARY KEY (id_detalle),
  CONSTRAINT fk_ven_det_venta_cabecera FOREIGN KEY (id_venta) REFERENCES venta_cabecera(id_venta),
  CONSTRAINT fk_ven_det_producto FOREIGN KEY (id_producto) REFERENCES producto(id_producto),
  CONSTRAINT ck_ven_det_cantidad CHECK (cantidad > 0),
  CONSTRAINT ck_ven_det_precio_unitario CHECK (precio_unitario >= 0)
);