IF NOT EXISTS(SELECT 1 FROM sysobjects WHERE name='Clientes' and xtype='U') BEGIN
    CREATE TABLE teste_webmotors..tb_AnuncioWebmotors
    (
        ID INT identity not null,
        marca varchar (45) not null,
        modelo varchar (45) not null,
        versao varchar (45) not null,
        ano INT not null,
        quilometragem INT not null,
        observacao text not null
    )
END