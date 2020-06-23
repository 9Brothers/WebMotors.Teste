IF EXISTS (
        SELECT 1
        FROM sys.procedures WITH(NOLOCK)
        WHERE NAME = 'psAnuncioWebMotors'
            AND type = 'P'
      )
      DROP PROCEDURE dbo.psAnuncioWebMotors
GO

CREATE PROCEDURE dbo.psAnuncioWebMotors
    @Marca varchar (45),
    @Modelo varchar (45),
    @Versao varchar (45)
AS

    SELECT * FROM 
    (
        SELECT * FROM 
        (
            SELECT * FROM tb_AnuncioWebmotors (NOLOCK) AS AN1
            WHERE @Marca IS NOT NULL AND AN1.marca = @Marca
            OR @Marca IS NULL
        )
        AS AN2
        WHERE @Modelo IS NOT NULL AND AN2.modelo = @Modelo
        OR @Modelo IS NULL
    )
    AS AN3
    WHERE @Versao IS NOT NULL AND AN3.versao = @Versao
    OR @Versao IS NULL

GO