-- Insertar Clientes
INSERT INTO Cliente (nombre, tipo, direccion, telefono, email) VALUES
('Carlos Pérez', 'Natural', 'Calle 123', '3001234567', 'carlos@mail.com'),
('Constructora ABC S.A.', 'Juridica', 'Av. Principal 45', '3102345678', 'contacto@abc.com');

-- Insertar Proveedores
INSERT INTO Proveedor (nombre, contacto, direccion, telefono, email) VALUES
('Proveedor Uno', 'Luis Gómez', 'Zona Industrial 12', '3204567890', 'proveedor1@mail.com'),
('Proveedor Dos', 'Ana Ruiz', 'Carrera 7 #21', '3219876543', 'proveedor2@mail.com');

-- Insertar Productos
INSERT INTO Producto (nombre, descripcion, precio, id_proveedor) VALUES
('Cemento Ultra', 'Cemento de alta resistencia', 28000, 1),
('Ladrillo Rojo', 'Ladrillo de arcilla para muros', 650, 1),
('Pintura Blanca', 'Pintura látex 4L', 32000, 2);

-- Insertar Empleados
INSERT INTO Empleado (nombre, cedula, direccion, telefono, email, id_cliente) VALUES
('Laura Martínez', '10203040', 'Calle 9 #10', '3004567890', 'laura@mail.com', 1),
('Andrés Ruiz', '20304050', 'Cra 5 #11', '3005678901', 'andres@mail.com', 2),
('Juana López', '30405060', 'Av 7 #12', '3006789012', 'juana@mail.com', 2);

-- Insertar Secciones
INSERT INTO Seccion (nombre, descripcion) VALUES
('Ventas', 'Área de ventas y atención al cliente'),
('Logística', 'Área de distribución y transporte'),
('Almacén', 'Área de almacenamiento de productos');

-- Insertar Empleado_Seccion (relaciones N:M)
INSERT INTO Empleado_Seccion (id_empleado, id_seccion, fecha_ingreso) VALUES
(1, 1, '2024-01-10'),
(1, 2, '2024-03-15'),
(2, 2, '2024-02-01'),
(3, 3, '2024-04-20');

-- Insertar Cliente_Producto (relaciones N:M)
INSERT INTO Cliente_Producto (id_cliente, id_producto, fecha_asociacion) VALUES
(1, 1, '2024-05-01'),
(1, 2, '2024-05-02'),
(2, 2, '2024-05-03'),
(2, 3, '2024-05-04');
