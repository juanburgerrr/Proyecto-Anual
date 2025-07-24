USE sistema;
GO

-- 1. Insertar un tipo de documento si no existe
IF NOT EXISTS (SELECT 1 FROM Tipo_Doc WHERE TipoDoc = 'DNI')
    INSERT INTO Tipo_Doc (TipoDoc) VALUES ('DNI');
GO

-- 2. Insertar un género si no existe
IF NOT EXISTS (SELECT 1 FROM Genero WHERE Genero = 'Masculino')
    INSERT INTO Genero (Genero) VALUES ('Masculino');
GO

-- 3. Insertar una localidad si no existe
IF NOT EXISTS (SELECT 1 FROM Localidad WHERE Localidad = 'Buenos Aires')
    INSERT INTO Localidad (Localidad) VALUES ('Buenos Aires');
GO

-- 4. Insertar en Personal si no existe
IF NOT EXISTS (SELECT 1 FROM Personal WHERE Legajo = 1001)
BEGIN
    INSERT INTO Personal (
        Legajo, Nombre, Apellido, Id_TipoDoc, NroDoc, Calle, Nro, Piso, Depto,
        Id_Localidad, Id_Genero, Sexo, Correo, CUIL, Fecha_Alta, Telefono
    )
    VALUES (
        1001, 'Juan', 'Admin', 
        (SELECT TOP 1 Id_TipoDoc FROM Tipo_Doc WHERE TipoDoc = 'DNI'), 
        12345678, 'Calle Falsa', 123, 1, 'A', 
        (SELECT TOP 1 Id_Localidad FROM Localidad WHERE Localidad = 'Buenos Aires'),
        (SELECT TOP 1 Id_Genero FROM Genero WHERE Genero = 'Masculino'), 
        'M', 'admin@ejemplo.com', '20123456789', GETDATE(), 1138856713
    );
END
GO

-- 5. Insertar rol de Administrador si no existe
IF NOT EXISTS (SELECT 1 FROM Roles WHERE Rol = 'Administrador')
    INSERT INTO Roles (Rol) VALUES ('Administrador');
GO

-- 6. Insertar en Usuarios si no existe
IF NOT EXISTS (SELECT 1 FROM Usuarios WHERE usuario = 'usu1')
BEGIN
    INSERT INTO Usuarios (
        usuario, Password, Id_Personal, Usuario_Bloqueado, Fecha_Hora_Bloqueo, CambiaCada, Fecha_Ult_Cambio, Id_Rol
    )
    VALUES (
        'usu1', '12345', 
        (SELECT TOP 1 Id_Personal FROM Personal WHERE Legajo = 1001),
        0, NULL, 30, NULL,
        (SELECT TOP 1 Id_Rol FROM Roles WHERE Rol = 'Administrador')
    );
END
GO
