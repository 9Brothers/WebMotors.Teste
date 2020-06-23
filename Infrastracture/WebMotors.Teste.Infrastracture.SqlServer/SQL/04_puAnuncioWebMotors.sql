IF EXISTS (
        SELECT 1
        FROM sys.procedures WITH(NOLOCK)
        WHERE NAME = 'puAnuncioWebMotors'
            AND type = 'P'
      )
      DROP PROCEDURE dbo.puAnuncioWebMotors
GO

CREATE PROCEDURE dbo.puAnuncioWebMotors
    @Id INT,
    @Marca varchar (45),
    @Modelo varchar (45),
    @Versao varchar (45),
    @Ano INT,
    @Quilometragem INT,
    @Observacao text
AS

    UPDATE tb_AnuncioWebmotors SET
        marca = @Marca,
        modelo = @Modelo,
        versao = @Versao,
        ano = @Ano,
        quilometragem = @Quilometragem,
        observacao = @Observacao
    WHERE id = @Id

    SELECT * FROM tb_AnuncioWebmotors WHERE id = @Id
GO