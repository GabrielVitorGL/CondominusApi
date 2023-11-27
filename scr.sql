IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [AreasComuns] (
    [Id] int NOT NULL IDENTITY,
    [Capacidade] int NOT NULL,
    [Nome] nvarchar(max) NULL,
    CONSTRAINT [PK_AreasComuns] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Condominios] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NULL,
    [Endereco] nvarchar(max) NULL,
    CONSTRAINT [PK_Condominios] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Pessoas] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NULL,
    [Perfil] nvarchar(max) NULL,
    [Telefone] nvarchar(max) NULL,
    [Cpf] nvarchar(max) NULL,
    CONSTRAINT [PK_Pessoas] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Usuarios] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NULL,
    [Telefone] nvarchar(max) NULL,
    [Cpf] nvarchar(max) NULL,
    [Perfil] nvarchar(max) NULL,
    [PasswordHash] varbinary(max) NULL,
    [PasswordSalt] varbinary(max) NULL,
    [Email] nvarchar(max) NULL,
    [DataAcesso] datetime2 NULL,
    [IdApartamento] int NOT NULL,
    CONSTRAINT [PK_Usuarios] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Apartamentos] (
    [Id] int NOT NULL IDENTITY,
    [Telefone] nvarchar(max) NULL,
    [Numero] nvarchar(max) NULL,
    [IdCondominio] int NOT NULL,
    CONSTRAINT [PK_Apartamentos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Apartamentos_Condominios_IdCondominio] FOREIGN KEY ([IdCondominio]) REFERENCES [Condominios] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Avisos] (
    [Id] int NOT NULL IDENTITY,
    [Assunto] nvarchar(max) NULL,
    [Mensagem] nvarchar(max) NULL,
    [DataEnvio] datetime2 NOT NULL,
    [PessoaId] int NULL,
    [IdPessoa] int NOT NULL,
    CONSTRAINT [PK_Avisos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Avisos_Pessoas_PessoaId] FOREIGN KEY ([PessoaId]) REFERENCES [Pessoas] ([Id])
);
GO

CREATE TABLE [Dependentes] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NULL,
    [Telefone] nvarchar(max) NULL,
    [IdPessoa] int NOT NULL,
    CONSTRAINT [PK_Dependentes] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Dependentes_Pessoas_IdPessoa] FOREIGN KEY ([IdPessoa]) REFERENCES [Pessoas] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Reservas] (
    [Id] int NOT NULL IDENTITY,
    [Data] datetime2 NOT NULL,
    [PessoaId] int NULL,
    [IdPessoa] int NOT NULL,
    [AreaComumId] int NULL,
    [IdAreaComum] int NOT NULL,
    CONSTRAINT [PK_Reservas] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Reservas_AreasComuns_AreaComumId] FOREIGN KEY ([AreaComumId]) REFERENCES [AreasComuns] ([Id]),
    CONSTRAINT [FK_Reservas_Pessoas_PessoaId] FOREIGN KEY ([PessoaId]) REFERENCES [Pessoas] ([Id])
);
GO

CREATE TABLE [ApartPessoas] (
    [IdApartamento] int NOT NULL,
    [IdPessoa] int NOT NULL,
    [Id] int NOT NULL,
    [UsuarioId] int NULL,
    CONSTRAINT [PK_ApartPessoas] PRIMARY KEY ([IdPessoa], [IdApartamento]),
    CONSTRAINT [FK_ApartPessoas_Apartamentos_IdApartamento] FOREIGN KEY ([IdApartamento]) REFERENCES [Apartamentos] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ApartPessoas_Pessoas_IdPessoa] FOREIGN KEY ([IdPessoa]) REFERENCES [Pessoas] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ApartPessoas_Usuarios_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [Usuarios] ([Id])
);
GO

CREATE TABLE [Entregas] (
    [Id] int NOT NULL IDENTITY,
    [Destinatario] nvarchar(max) NULL,
    [DataEntrega] datetime2 NULL,
    [DataRetirada] datetime2 NULL,
    [IdApartamento] int NOT NULL,
    CONSTRAINT [PK_Entregas] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Entregas_Apartamentos_IdApartamento] FOREIGN KEY ([IdApartamento]) REFERENCES [Apartamentos] ([Id]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Capacidade', N'Nome') AND [object_id] = OBJECT_ID(N'[AreasComuns]'))
    SET IDENTITY_INSERT [AreasComuns] ON;
INSERT INTO [AreasComuns] ([Id], [Capacidade], [Nome])
VALUES (1, 50, N'Salão de Festas'),
(2, 30, N'Churrasqueira'),
(3, 20, N'Sala de Jogos'),
(4, 10, N'Piscina');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Capacidade', N'Nome') AND [object_id] = OBJECT_ID(N'[AreasComuns]'))
    SET IDENTITY_INSERT [AreasComuns] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Endereco', N'Nome') AND [object_id] = OBJECT_ID(N'[Condominios]'))
    SET IDENTITY_INSERT [Condominios] ON;
INSERT INTO [Condominios] ([Id], [Endereco], [Nome])
VALUES (1, N'Rua Guaranésia, 1070', N'Vila Nova Maria'),
(2, N'Rua Paulo Andrighetti, 1573', N'Condomínio Aquarella Pari Colore'),
(3, N'Rua Paulo Andrighetti, 449', N'Condomínio Edifício Antônio Walter Santiago'),
(4, N'Rua Eugênio de Freitas, 525', N'Condomínio Edifício Veneza');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Endereco', N'Nome') AND [object_id] = OBJECT_ID(N'[Condominios]'))
    SET IDENTITY_INSERT [Condominios] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Cpf', N'Nome', N'Perfil', N'Telefone') AND [object_id] = OBJECT_ID(N'[Pessoas]'))
    SET IDENTITY_INSERT [Pessoas] ON;
INSERT INTO [Pessoas] ([Id], [Cpf], [Nome], [Perfil], [Telefone])
VALUES (1, N'56751898901', N'João Gomes', NULL, N'11924316523'),
(2, N'63158658205', N'Paola Oliveira', NULL, N'11975231678'),
(3, N'27458823908', N'Marilia Mendonça', NULL, N'11937512056'),
(4, N'32152898910', N'Sorriso Maroto', NULL, N'11987618735');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Cpf', N'Nome', N'Perfil', N'Telefone') AND [object_id] = OBJECT_ID(N'[Pessoas]'))
    SET IDENTITY_INSERT [Pessoas] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AreaComumId', N'Data', N'IdAreaComum', N'IdPessoa', N'PessoaId') AND [object_id] = OBJECT_ID(N'[Reservas]'))
    SET IDENTITY_INSERT [Reservas] ON;
INSERT INTO [Reservas] ([Id], [AreaComumId], [Data], [IdAreaComum], [IdPessoa], [PessoaId])
VALUES (1, NULL, '0001-01-01T00:00:00.0000000', 0, 0, NULL),
(2, NULL, '0001-01-01T00:00:00.0000000', 0, 0, NULL),
(3, NULL, '0001-01-01T00:00:00.0000000', 0, 0, NULL),
(4, NULL, '0001-01-01T00:00:00.0000000', 0, 0, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AreaComumId', N'Data', N'IdAreaComum', N'IdPessoa', N'PessoaId') AND [object_id] = OBJECT_ID(N'[Reservas]'))
    SET IDENTITY_INSERT [Reservas] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Cpf', N'DataAcesso', N'Email', N'IdApartamento', N'Nome', N'PasswordHash', N'PasswordSalt', N'Perfil', N'Telefone') AND [object_id] = OBJECT_ID(N'[Usuarios]'))
    SET IDENTITY_INSERT [Usuarios] ON;
INSERT INTO [Usuarios] ([Id], [Cpf], [DataAcesso], [Email], [IdApartamento], [Nome], [PasswordHash], [PasswordSalt], [Perfil], [Telefone])
VALUES (1, NULL, NULL, N'admin@gmail.com', 1, N'UsuarioAdmin', 0x7B56D36F49DA272CABE5B6B7C77E3287134E949D1F8EE2C4ACFD0B6A3432E3636DFCB9E01412CBB030B55074D2C3ECD0FEAAEF783DCD588AA1C67137C88F8BAF, 0xEABEB34FD335CBA56D467355C195CB8FA1D98B6192173A33E9C43AC1DB540B1559F33DA97D6CC12DC7260B8C7712A74576ACB2E496B09099475F0E5474A0E397D7004820293DBBAC7DEAD00B529E0EA54372530B853222AFBAFDF756CE40FF85BAA20CFC0C3DBAC85FB1325518F4B54D9AA593B8159E9DF9F04EFE19C829ED4D, N'Admin', NULL),
(3, NULL, NULL, N'UsuarioSindico@gmail.com', 2, N'UsuarioSindico', 0x7B56D36F49DA272CABE5B6B7C77E3287134E949D1F8EE2C4ACFD0B6A3432E3636DFCB9E01412CBB030B55074D2C3ECD0FEAAEF783DCD588AA1C67137C88F8BAF, 0xEABEB34FD335CBA56D467355C195CB8FA1D98B6192173A33E9C43AC1DB540B1559F33DA97D6CC12DC7260B8C7712A74576ACB2E496B09099475F0E5474A0E397D7004820293DBBAC7DEAD00B529E0EA54372530B853222AFBAFDF756CE40FF85BAA20CFC0C3DBAC85FB1325518F4B54D9AA593B8159E9DF9F04EFE19C829ED4D, N'Sindico', NULL),
(4, NULL, NULL, N'UsuarioMorador@gmail.com', 3, N'UsuarioMorador', 0x7B56D36F49DA272CABE5B6B7C77E3287134E949D1F8EE2C4ACFD0B6A3432E3636DFCB9E01412CBB030B55074D2C3ECD0FEAAEF783DCD588AA1C67137C88F8BAF, 0xEABEB34FD335CBA56D467355C195CB8FA1D98B6192173A33E9C43AC1DB540B1559F33DA97D6CC12DC7260B8C7712A74576ACB2E496B09099475F0E5474A0E397D7004820293DBBAC7DEAD00B529E0EA54372530B853222AFBAFDF756CE40FF85BAA20CFC0C3DBAC85FB1325518F4B54D9AA593B8159E9DF9F04EFE19C829ED4D, N'Morador', NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Cpf', N'DataAcesso', N'Email', N'IdApartamento', N'Nome', N'PasswordHash', N'PasswordSalt', N'Perfil', N'Telefone') AND [object_id] = OBJECT_ID(N'[Usuarios]'))
    SET IDENTITY_INSERT [Usuarios] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'IdCondominio', N'Numero', N'Telefone') AND [object_id] = OBJECT_ID(N'[Apartamentos]'))
    SET IDENTITY_INSERT [Apartamentos] ON;
INSERT INTO [Apartamentos] ([Id], [IdCondominio], [Numero], [Telefone])
VALUES (1, 1, N'A001', N'11912345678'),
(2, 1, N'B002', N'11912345678'),
(3, 1, N'C003', N'11887654321'),
(4, 1, N'E005', N'11955555555');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'IdCondominio', N'Numero', N'Telefone') AND [object_id] = OBJECT_ID(N'[Apartamentos]'))
    SET IDENTITY_INSERT [Apartamentos] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'IdPessoa', N'Nome', N'Telefone') AND [object_id] = OBJECT_ID(N'[Dependentes]'))
    SET IDENTITY_INSERT [Dependentes] ON;
INSERT INTO [Dependentes] ([Id], [IdPessoa], [Nome], [Telefone])
VALUES (1, 1, N'João Gomes', N'11924316523'),
(2, 1, N'Maria Silva', N'11876543210'),
(3, 2, N'Carlos Oliveira', N'11234567890'),
(4, 3, N'Ana Souza', N'11987654321'),
(5, 3, N'Pedro Santos', N'11765432109');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'IdPessoa', N'Nome', N'Telefone') AND [object_id] = OBJECT_ID(N'[Dependentes]'))
    SET IDENTITY_INSERT [Dependentes] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataEntrega', N'DataRetirada', N'Destinatario', N'IdApartamento') AND [object_id] = OBJECT_ID(N'[Entregas]'))
    SET IDENTITY_INSERT [Entregas] ON;
INSERT INTO [Entregas] ([Id], [DataEntrega], [DataRetirada], [Destinatario], [IdApartamento])
VALUES (1, NULL, NULL, N'Joao Guilherme', 1);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataEntrega', N'DataRetirada', N'Destinatario', N'IdApartamento') AND [object_id] = OBJECT_ID(N'[Entregas]'))
    SET IDENTITY_INSERT [Entregas] OFF;
GO

CREATE INDEX [IX_Apartamentos_IdCondominio] ON [Apartamentos] ([IdCondominio]);
GO

CREATE INDEX [IX_ApartPessoas_IdApartamento] ON [ApartPessoas] ([IdApartamento]);
GO

CREATE INDEX [IX_ApartPessoas_UsuarioId] ON [ApartPessoas] ([UsuarioId]);
GO

CREATE INDEX [IX_Avisos_PessoaId] ON [Avisos] ([PessoaId]);
GO

CREATE INDEX [IX_Dependentes_IdPessoa] ON [Dependentes] ([IdPessoa]);
GO

CREATE INDEX [IX_Entregas_IdApartamento] ON [Entregas] ([IdApartamento]);
GO

CREATE INDEX [IX_Reservas_AreaComumId] ON [Reservas] ([AreaComumId]);
GO

CREATE INDEX [IX_Reservas_PessoaId] ON [Reservas] ([PessoaId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231127112319_Metodos', N'7.0.4');
GO

COMMIT;
GO

