USE sistema;
GO
--;WITH CTE_Legajos hace una lista ordenada con posicion(1,2,3,4) y legajo
--si son <> hay un "hueco", si no hay huecos, sigue sumando de a 1
CREATE PROCEDURE SP_Legajo
    @nombre NVARCHAR(50),
    @apellido NVARCHAR(50)
AS
BEGIN
    DECLARE @legajo INT;

    ;WITH CTE_Legajos AS (
        SELECT Legajo, ROW_NUMBER() OVER (ORDER BY Legajo) AS Posicion
        FROM Personal
    )
    SELECT TOP 1 @legajo = Posicion
    FROM CTE_Legajos
    WHERE Legajo <> Posicion
    ORDER BY Posicion;

    -- Si no se encontraron huecos, usar el mayor legajo + 1
    IF @legajo IS NULL
        SELECT @legajo = ISNULL(MAX(Legajo), 0) + 1 FROM Personal;

    -- Insertar nuevo empleado con el legajo calculado
    INSERT INTO Personal (Legajo, Nombre, Apellido)
    VALUES (@legajo, @nombre, @apellido);

END;
GO
