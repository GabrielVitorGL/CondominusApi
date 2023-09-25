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
    [Status] nvarchar(max) NULL,
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

CREATE TABLE [Usuarios] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NULL,
    [Perfil] nvarchar(max) NULL,
    [PasswordHash] varbinary(max) NULL,
    [PasswordSalt] varbinary(max) NULL,
    [Email] nvarchar(max) NULL,
    [DataAcesso] datetime2 NULL,
    CONSTRAINT [PK_Usuarios] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Apartamentos] (
    [Id] int NOT NULL IDENTITY,
    [Telefone] nvarchar(max) NULL,
    [Numero] nvarchar(max) NULL,
    [Status] nvarchar(max) NULL,
    [CondominioId] int NULL,
    [IdCondominio] int NOT NULL,
    [UsuarioId] int NULL,
    CONSTRAINT [PK_Apartamentos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Apartamentos_Condominios_CondominioId] FOREIGN KEY ([CondominioId]) REFERENCES [Condominios] ([Id]),
    CONSTRAINT [FK_Apartamentos_Usuarios_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [Usuarios] ([Id])
);
GO

CREATE TABLE [Pessoas] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NULL,
    [Cpf] nvarchar(max) NULL,
    [Perfil] nvarchar(max) NULL,
    [Telefone] nvarchar(max) NULL,
    [Status] nvarchar(max) NULL,
    [ApartamentoId] int NULL,
    [IdApartamento] int NOT NULL,
    [CondominioId] int NULL,
    [IdCondominio] int NOT NULL,
    CONSTRAINT [PK_Pessoas] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Pessoas_Apartamentos_ApartamentoId] FOREIGN KEY ([ApartamentoId]) REFERENCES [Apartamentos] ([Id]),
    CONSTRAINT [FK_Pessoas_Condominios_CondominioId] FOREIGN KEY ([CondominioId]) REFERENCES [Condominios] ([Id])
);
GO

CREATE TABLE [Entregas] (
    [Id] int NOT NULL IDENTITY,
    [Remetente] nvarchar(max) NULL,
    [DataEntrega] datetime2 NOT NULL,
    [DataRetirada] datetime2 NOT NULL,
    [PessoaId] int NULL,
    [IdPessoa] int NOT NULL,
    CONSTRAINT [PK_Entregas] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Entregas_Pessoas_PessoaId] FOREIGN KEY ([PessoaId]) REFERENCES [Pessoas] ([Id])
);
GO

CREATE TABLE [Reservas] (
    [Id] int NOT NULL IDENTITY,
    [DataReserva] datetime2 NOT NULL,
    [Status] nvarchar(max) NULL,
    [PessoaId] int NULL,
    [IdPessoa] int NOT NULL,
    [AreaComumId] int NULL,
    [IdAreaComum] int NOT NULL,
    CONSTRAINT [PK_Reservas] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Reservas_AreasComuns_AreaComumId] FOREIGN KEY ([AreaComumId]) REFERENCES [AreasComuns] ([Id]),
    CONSTRAINT [FK_Reservas_Pessoas_PessoaId] FOREIGN KEY ([PessoaId]) REFERENCES [Pessoas] ([Id])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CondominioId', N'IdCondominio', N'Numero', N'Status', N'Telefone', N'UsuarioId') AND [object_id] = OBJECT_ID(N'[Apartamentos]'))
    SET IDENTITY_INSERT [Apartamentos] ON;
INSERT INTO [Apartamentos] ([Id], [CondominioId], [IdCondominio], [Numero], [Status], [Telefone], [UsuarioId])
VALUES (1, NULL, 0, N'A001', NULL, N'11912345678', NULL),
(2, NULL, 0, N'B002', NULL, N'11912345678', NULL),
(3, NULL, 0, N'C003', NULL, N'11887654321', NULL),
(4, NULL, 0, N'E005', NULL, N'11955555555', NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CondominioId', N'IdCondominio', N'Numero', N'Status', N'Telefone', N'UsuarioId') AND [object_id] = OBJECT_ID(N'[Apartamentos]'))
    SET IDENTITY_INSERT [Apartamentos] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Capacidade', N'Nome', N'Status') AND [object_id] = OBJECT_ID(N'[AreasComuns]'))
    SET IDENTITY_INSERT [AreasComuns] ON;
INSERT INTO [AreasComuns] ([Id], [Capacidade], [Nome], [Status])
VALUES (1, 50, N'Salão de Festas', NULL),
(2, 30, N'Churrasqueira', NULL),
(3, 20, N'Sala de Jogos', NULL),
(4, 10, N'Piscina', NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Capacidade', N'Nome', N'Status') AND [object_id] = OBJECT_ID(N'[AreasComuns]'))
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

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataEntrega', N'DataRetirada', N'IdPessoa', N'PessoaId', N'Remetente') AND [object_id] = OBJECT_ID(N'[Entregas]'))
    SET IDENTITY_INSERT [Entregas] ON;
INSERT INTO [Entregas] ([Id], [DataEntrega], [DataRetirada], [IdPessoa], [PessoaId], [Remetente])
VALUES (1, '2023-09-23T12:35:48.5410976-03:00', '2023-09-23T12:35:48.5410987-03:00', 0, NULL, N'Sorriso Maroto'),
(2, '2023-09-23T12:35:48.5410988-03:00', '2023-09-23T12:35:48.5410989-03:00', 0, NULL, N'Marilia Mendonça'),
(3, '2023-09-23T12:35:48.5410990-03:00', '2023-09-23T12:35:48.5410990-03:00', 0, NULL, N'Paola Oliveira'),
(4, '2023-09-23T12:35:48.5410991-03:00', '2023-09-23T12:35:48.5410992-03:00', 0, NULL, N'João Gomes');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataEntrega', N'DataRetirada', N'IdPessoa', N'PessoaId', N'Remetente') AND [object_id] = OBJECT_ID(N'[Entregas]'))
    SET IDENTITY_INSERT [Entregas] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ApartamentoId', N'CondominioId', N'Cpf', N'IdApartamento', N'IdCondominio', N'Nome', N'Perfil', N'Status', N'Telefone') AND [object_id] = OBJECT_ID(N'[Pessoas]'))
    SET IDENTITY_INSERT [Pessoas] ON;
INSERT INTO [Pessoas] ([Id], [ApartamentoId], [CondominioId], [Cpf], [IdApartamento], [IdCondominio], [Nome], [Perfil], [Status], [Telefone])
VALUES (1, NULL, NULL, N'56751898901', 0, 0, N'João Gomes', NULL, NULL, N'11924316523'),
(2, NULL, NULL, N'63158658205', 0, 0, N'Paola Oliveira', NULL, NULL, N'11975231678'),
(3, NULL, NULL, N'27458823908', 0, 0, N'Marilia Mendonça', NULL, NULL, N'11937512056'),
(4, NULL, NULL, N'32152898910', 0, 0, N'Sorriso Maroto', NULL, NULL, N'11987618735');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ApartamentoId', N'CondominioId', N'Cpf', N'IdApartamento', N'IdCondominio', N'Nome', N'Perfil', N'Status', N'Telefone') AND [object_id] = OBJECT_ID(N'[Pessoas]'))
    SET IDENTITY_INSERT [Pessoas] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AreaComumId', N'DataReserva', N'IdAreaComum', N'IdPessoa', N'PessoaId', N'Status') AND [object_id] = OBJECT_ID(N'[Reservas]'))
    SET IDENTITY_INSERT [Reservas] ON;
INSERT INTO [Reservas] ([Id], [AreaComumId], [DataReserva], [IdAreaComum], [IdPessoa], [PessoaId], [Status])
VALUES (1, NULL, '2023-09-23T12:35:48.5411025-03:00', 0, 0, NULL, NULL),
(2, NULL, '2023-09-23T12:35:48.5411026-03:00', 0, 0, NULL, NULL),
(3, NULL, '2023-09-23T12:35:48.5411027-03:00', 0, 0, NULL, NULL),
(4, NULL, '2023-09-23T12:35:48.5411028-03:00', 0, 0, NULL, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AreaComumId', N'DataReserva', N'IdAreaComum', N'IdPessoa', N'PessoaId', N'Status') AND [object_id] = OBJECT_ID(N'[Reservas]'))
    SET IDENTITY_INSERT [Reservas] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataAcesso', N'Email', N'Nome', N'PasswordHash', N'PasswordSalt', N'Perfil') AND [object_id] = OBJECT_ID(N'[Usuarios]'))
    SET IDENTITY_INSERT [Usuarios] ON;
INSERT INTO [Usuarios] ([Id], [DataAcesso], [Email], [Nome], [PasswordHash], [PasswordSalt], [Perfil])
VALUES (1, NULL, N'seuEmail@gmail.com', N'UsuarioAdmin', 0x9D8EED75EC973885A7DAFC5A1CD9E57AD2CC949075F8CED00A0CAC3473EB5B870D761EEF749FF239FD8C108D48874C2F57FB3F1A7DC1A81D9AD8CE482ECD504C, 0x599797FAB46CD4487CCAFBFDA5F704AD2F536AC1D6B774FCD5AD259A7B18BFA0860C4A0E99E16D77355016818803A9564A86DEF947E75E29FCF32EA3AEE22BC35994A5A059151DFFADB7CF68A102A4EC0C9999CC7A102A56E80295453B148429B741DBBE3BCD675B3520C9CB65FE1CA5E4BADACDF460E5F9DAECA029BDCBEC0C, N'Admin'),
(3, NULL, N'email@gmail.com', N'UsuarioSindico', 0x9D8EED75EC973885A7DAFC5A1CD9E57AD2CC949075F8CED00A0CAC3473EB5B870D761EEF749FF239FD8C108D48874C2F57FB3F1A7DC1A81D9AD8CE482ECD504C, 0x599797FAB46CD4487CCAFBFDA5F704AD2F536AC1D6B774FCD5AD259A7B18BFA0860C4A0E99E16D77355016818803A9564A86DEF947E75E29FCF32EA3AEE22BC35994A5A059151DFFADB7CF68A102A4EC0C9999CC7A102A56E80295453B148429B741DBBE3BCD675B3520C9CB65FE1CA5E4BADACDF460E5F9DAECA029BDCBEC0C, N'Sindico'),
(4, NULL, N'email@gmail.com', N'UsuarioMorador', 0x9D8EED75EC973885A7DAFC5A1CD9E57AD2CC949075F8CED00A0CAC3473EB5B870D761EEF749FF239FD8C108D48874C2F57FB3F1A7DC1A81D9AD8CE482ECD504C, 0x599797FAB46CD4487CCAFBFDA5F704AD2F536AC1D6B774FCD5AD259A7B18BFA0860C4A0E99E16D77355016818803A9564A86DEF947E75E29FCF32EA3AEE22BC35994A5A059151DFFADB7CF68A102A4EC0C9999CC7A102A56E80295453B148429B741DBBE3BCD675B3520C9CB65FE1CA5E4BADACDF460E5F9DAECA029BDCBEC0C, N'Morador');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataAcesso', N'Email', N'Nome', N'PasswordHash', N'PasswordSalt', N'Perfil') AND [object_id] = OBJECT_ID(N'[Usuarios]'))
    SET IDENTITY_INSERT [Usuarios] OFF;
GO

CREATE INDEX [IX_Apartamentos_CondominioId] ON [Apartamentos] ([CondominioId]);
GO

CREATE INDEX [IX_Apartamentos_UsuarioId] ON [Apartamentos] ([UsuarioId]);
GO

CREATE INDEX [IX_Entregas_PessoaId] ON [Entregas] ([PessoaId]);
GO

CREATE INDEX [IX_Pessoas_ApartamentoId] ON [Pessoas] ([ApartamentoId]);
GO

CREATE INDEX [IX_Pessoas_CondominioId] ON [Pessoas] ([CondominioId]);
GO

CREATE INDEX [IX_Reservas_AreaComumId] ON [Reservas] ([AreaComumId]);
GO

CREATE INDEX [IX_Reservas_PessoaId] ON [Reservas] ([PessoaId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230923153548_BaseFinal', N'7.0.4');
GO

COMMIT;
GO

