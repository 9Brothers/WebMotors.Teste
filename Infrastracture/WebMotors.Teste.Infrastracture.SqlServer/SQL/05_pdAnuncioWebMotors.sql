IF EXISTS (
        SELECT 1
        FROM sys.procedures WITH(NOLOCK)
        WHERE NAME = 'pdAnuncioWebMotors'
            AND type = 'P'
      )
      DROP PROCEDURE dbo.pdAnuncioWebMotors
GO

CREATE PROCEDURE dbo.pdAnuncioWebMotors
    @Id INT    
AS

    DELETE FROM tb_AnuncioWebmotors WHERE id = @Id
GO