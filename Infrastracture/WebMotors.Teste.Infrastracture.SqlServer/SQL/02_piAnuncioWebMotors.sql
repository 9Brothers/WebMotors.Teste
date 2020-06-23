IF EXISTS (
        SELECT 1
        FROM sys.procedures WITH(NOLOCK)
        WHERE NAME = 'piAnuncioWebMotors'
            AND type = 'P'
      )
      DROP PROCEDURE dbo.piAnuncioWebMotors
GO

CREATE PROCEDURE dbo.piAnuncioWebMotors
    @Marca varchar (45),
    @Modelo varchar (45),
    @Versao varchar (45),
    @Ano INT,
    @Quilometragem INT,
    @Observacao text
AS

    DECLARE @Id INT

    INSERT INTO tb_AnuncioWebmotors (marca, modelo, versao, ano, quilometragem, observacao)
    VALUES(@Marca, @Modelo, @Versao, @Ano, @Quilometragem, @Observacao)

    SET @Id = SCOPE_IDENTITY()

    SELECT * FROM tb_AnuncioWebmotors (NOLOCK) WHERE ID = @Id
GO