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

CREATE TABLE [Apartamentos] (
    [Id] int NOT NULL IDENTITY,
    [Telefone] nvarchar(max) NULL,
    [Numero] nvarchar(max) NULL,
    [CondominioId] int NULL,
    [IdCondominio] int NOT NULL,
    CONSTRAINT [PK_Apartamentos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Apartamentos_Condominios_CondominioId] FOREIGN KEY ([CondominioId]) REFERENCES [Condominios] ([Id])
);
GO

CREATE TABLE [Sindicos] (
    [Id] int NOT NULL IDENTITY,
    [Cpf] nvarchar(max) NULL,
    [Nome] nvarchar(max) NULL,
    [Telefone] nvarchar(max) NULL,
    [CondominioId] int NULL,
    [IdCondominio] int NOT NULL,
    CONSTRAINT [PK_Sindicos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Sindicos_Condominios_CondominioId] FOREIGN KEY ([CondominioId]) REFERENCES [Condominios] ([Id])
);
GO

CREATE TABLE [Moradores] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NULL,
    [Cpf] nvarchar(max) NULL,
    [Telefone] nvarchar(max) NULL,
    [ApartamentoId] int NULL,
    [IdApartamento] int NOT NULL,
    CONSTRAINT [PK_Moradores] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Moradores_Apartamentos_ApartamentoId] FOREIGN KEY ([ApartamentoId]) REFERENCES [Apartamentos] ([Id])
);
GO

CREATE TABLE [Entregas] (
    [Id] int NOT NULL IDENTITY,
    [Remetente] nvarchar(max) NULL,
    [DataEntrega] datetime2 NOT NULL,
    [DataRetirada] datetime2 NOT NULL,
    [MoradorId] int NULL,
    [IdMorador] int NOT NULL,
    CONSTRAINT [PK_Entregas] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Entregas_Moradores_MoradorId] FOREIGN KEY ([MoradorId]) REFERENCES [Moradores] ([Id])
);
GO

CREATE TABLE [Reservas] (
    [Id] int NOT NULL IDENTITY,
    [DataReserva] datetime2 NOT NULL,
    [MoradorId] int NULL,
    [IdMorador] int NOT NULL,
    [AreaComumId] int NULL,
    [IdAreaComum] int NOT NULL,
    CONSTRAINT [PK_Reservas] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Reservas_AreasComuns_AreaComumId] FOREIGN KEY ([AreaComumId]) REFERENCES [AreasComuns] ([Id]),
    CONSTRAINT [FK_Reservas_Moradores_MoradorId] FOREIGN KEY ([MoradorId]) REFERENCES [Moradores] ([Id])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CondominioId', N'IdCondominio', N'Numero', N'Telefone') AND [object_id] = OBJECT_ID(N'[Apartamentos]'))
    SET IDENTITY_INSERT [Apartamentos] ON;
INSERT INTO [Apartamentos] ([Id], [CondominioId], [IdCondominio], [Numero], [Telefone])
VALUES (1, NULL, 0, N'A001', N'11912345678'),
(2, NULL, 0, N'B002', N'11912345678'),
(3, NULL, 0, N'C003', N'11887654321'),
(4, NULL, 0, N'E005', N'11955555555');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CondominioId', N'IdCondominio', N'Numero', N'Telefone') AND [object_id] = OBJECT_ID(N'[Apartamentos]'))
    SET IDENTITY_INSERT [Apartamentos] OFF;
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

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataEntrega', N'DataRetirada', N'IdMorador', N'MoradorId', N'Remetente') AND [object_id] = OBJECT_ID(N'[Entregas]'))
    SET IDENTITY_INSERT [Entregas] ON;
INSERT INTO [Entregas] ([Id], [DataEntrega], [DataRetirada], [IdMorador], [MoradorId], [Remetente])
VALUES (1, '2023-08-28T11:13:57.9173535-03:00', '2023-08-28T11:13:57.9173546-03:00', 0, NULL, N'Sorriso Maroto'),
(2, '2023-08-28T11:13:57.9173547-03:00', '2023-08-28T11:13:57.9173547-03:00', 0, NULL, N'Marilia Mendonça'),
(3, '2023-08-28T11:13:57.9173548-03:00', '2023-08-28T11:13:57.9173549-03:00', 0, NULL, N'Paola Oliveira'),
(4, '2023-08-28T11:13:57.9173550-03:00', '2023-08-28T11:13:57.9173550-03:00', 0, NULL, N'João Gomes');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataEntrega', N'DataRetirada', N'IdMorador', N'MoradorId', N'Remetente') AND [object_id] = OBJECT_ID(N'[Entregas]'))
    SET IDENTITY_INSERT [Entregas] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ApartamentoId', N'Cpf', N'IdApartamento', N'Nome', N'Telefone') AND [object_id] = OBJECT_ID(N'[Moradores]'))
    SET IDENTITY_INSERT [Moradores] ON;
INSERT INTO [Moradores] ([Id], [ApartamentoId], [Cpf], [IdApartamento], [Nome], [Telefone])
VALUES (1, NULL, N'56751898901', 0, N'João Gomes', N'11924316523'),
(2, NULL, N'63158658205', 0, N'Paola Oliveira', N'11975231678'),
(3, NULL, N'27458823908', 0, N'Marilia Mendonça', N'11937512056'),
(4, NULL, N'32152898910', 0, N'Sorriso Maroto', N'11987618735');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ApartamentoId', N'Cpf', N'IdApartamento', N'Nome', N'Telefone') AND [object_id] = OBJECT_ID(N'[Moradores]'))
    SET IDENTITY_INSERT [Moradores] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AreaComumId', N'DataReserva', N'IdAreaComum', N'IdMorador', N'MoradorId') AND [object_id] = OBJECT_ID(N'[Reservas]'))
    SET IDENTITY_INSERT [Reservas] ON;
INSERT INTO [Reservas] ([Id], [AreaComumId], [DataReserva], [IdAreaComum], [IdMorador], [MoradorId])
VALUES (1, NULL, '2023-08-28T11:13:57.9173600-03:00', 0, 0, NULL),
(2, NULL, '2023-08-28T11:13:57.9173601-03:00', 0, 0, NULL),
(3, NULL, '2023-08-28T11:13:57.9173602-03:00', 0, 0, NULL),
(4, NULL, '2023-08-28T11:13:57.9173602-03:00', 0, 0, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AreaComumId', N'DataReserva', N'IdAreaComum', N'IdMorador', N'MoradorId') AND [object_id] = OBJECT_ID(N'[Reservas]'))
    SET IDENTITY_INSERT [Reservas] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CondominioId', N'Cpf', N'IdCondominio', N'Nome', N'Telefone') AND [object_id] = OBJECT_ID(N'[Sindicos]'))
    SET IDENTITY_INSERT [Sindicos] ON;
INSERT INTO [Sindicos] ([Id], [CondominioId], [Cpf], [IdCondominio], [Nome], [Telefone])
VALUES (1, NULL, N'12345678900', 0, N'Eliane Marion', N'11925874613');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CondominioId', N'Cpf', N'IdCondominio', N'Nome', N'Telefone') AND [object_id] = OBJECT_ID(N'[Sindicos]'))
    SET IDENTITY_INSERT [Sindicos] OFF;
GO

CREATE INDEX [IX_Apartamentos_CondominioId] ON [Apartamentos] ([CondominioId]);
GO

CREATE INDEX [IX_Entregas_MoradorId] ON [Entregas] ([MoradorId]);
GO

CREATE INDEX [IX_Moradores_ApartamentoId] ON [Moradores] ([ApartamentoId]);
GO

CREATE INDEX [IX_Reservas_AreaComumId] ON [Reservas] ([AreaComumId]);
GO

CREATE INDEX [IX_Reservas_MoradorId] ON [Reservas] ([MoradorId]);
GO

CREATE INDEX [IX_Sindicos_CondominioId] ON [Sindicos] ([CondominioId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230828141358_InitialCreate', N'7.0.4');
GO

COMMIT;
GO

