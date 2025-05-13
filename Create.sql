-- Tabla de Clientes
CREATE TABLE Cliente (
    id_cliente INT PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(100) NOT NULL,
    tipo NVARCHAR(20) NOT NULL CHECK (tipo IN ('Natural', 'Juridica')),
    direccion NVARCHAR(150),
    telefono NVARCHAR(20),
    email NVARCHAR(100)
);

-- Tabla de Proveedores
CREATE TABLE Proveedor (
    id_proveedor INT PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(100) NOT NULL,
    contacto NVARCHAR(100),
    direccion NVARCHAR(150),
    telefono NVARCHAR(20),
    email NVARCHAR(100)
);

-- Tabla de Productos (relación con proveedor)
CREATE TABLE Producto (
    id_producto INT PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(100) NOT NULL,
    descripcion NVARCHAR(MAX),
    precio DECIMAL(10,2),
    id_proveedor INT NOT NULL,
    FOREIGN KEY (id_proveedor) REFERENCES Proveedor(id_proveedor)
);

-- Tabla intermedia Cliente_Producto (relación N:M)
CREATE TABLE Cliente_Producto (
    id_cliente INT,
    id_producto INT,
    fecha_asociacion DATE,
    PRIMARY KEY (id_cliente, id_producto),
    FOREIGN KEY (id_cliente) REFERENCES Cliente(id_cliente),
    FOREIGN KEY (id_producto) REFERENCES Producto(id_producto)
);

-- Tabla de Empleados (relación con Cliente)
CREATE TABLE Empleado (
    id_empleado INT PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(100) NOT NULL,
    cedula NVARCHAR(20) UNIQUE NOT NULL,
    direccion NVARCHAR(150),
    telefono NVARCHAR(20),
    email NVARCHAR(100),
    id_cliente INT NOT NULL,
    FOREIGN KEY (id_cliente) REFERENCES Cliente(id_cliente)
);

-- Tabla de Secciones
CREATE TABLE Seccion (
    id_seccion INT PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(100) NOT NULL,
    descripcion NVARCHAR(MAX)
);

-- Tabla intermedia Empleado_Seccion (relación N:M)
CREATE TABLE Empleado_Seccion (
    id_empleado INT,
    id_seccion INT,
    fecha_ingreso DATE,
    PRIMARY KEY (id_empleado, id_seccion),
    FOREIGN KEY (id_empleado) REFERENCES Empleado(id_empleado),
    FOREIGN KEY (id_seccion) REFERENCES Seccion(id_seccion)
);