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

CREATE TABLE [Portarias] (
    [Id] int NOT NULL IDENTITY,
    CONSTRAINT [PK_Portarias] PRIMARY KEY ([Id])
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

CREATE TABLE [Entregas] (
    [Id] int NOT NULL IDENTITY,
    [Destinatario] nvarchar(max) NULL,
    [DataEntrega] datetime2 NULL,
    [DataRetirada] datetime2 NULL,
    [IdApartamento] int NOT NULL,
    [PortariaId] int NULL,
    CONSTRAINT [PK_Entregas] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Entregas_Apartamentos_IdApartamento] FOREIGN KEY ([IdApartamento]) REFERENCES [Apartamentos] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Entregas_Portarias_PortariaId] FOREIGN KEY ([PortariaId]) REFERENCES [Portarias] ([Id])
);
GO

CREATE TABLE [Pessoas] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NULL,
    [Perfil] nvarchar(max) NULL,
    [Telefone] nvarchar(max) NULL,
    [Cpf] nvarchar(max) NULL,
    [ApartamentoId] int NULL,
    [IdApartamento] int NOT NULL,
    CONSTRAINT [PK_Pessoas] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Pessoas_Apartamentos_ApartamentoId] FOREIGN KEY ([ApartamentoId]) REFERENCES [Apartamentos] ([Id])
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
    [ApartamentoId] int NULL,
    [IdApartamento] int NOT NULL,
    CONSTRAINT [PK_Usuarios] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Usuarios_Apartamentos_ApartamentoId] FOREIGN KEY ([ApartamentoId]) REFERENCES [Apartamentos] ([Id])
);
GO

CREATE TABLE [ApartPessoas] (
    [Id] int NOT NULL IDENTITY,
    [ApartamentoId] int NULL,
    [IdApartamento] int NOT NULL,
    [PessoaId] int NULL,
    [IdPessoa] int NOT NULL,
    CONSTRAINT [PK_ApartPessoas] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ApartPessoas_Apartamentos_ApartamentoId] FOREIGN KEY ([ApartamentoId]) REFERENCES [Apartamentos] ([Id]),
    CONSTRAINT [FK_ApartPessoas_Pessoas_PessoaId] FOREIGN KEY ([PessoaId]) REFERENCES [Pessoas] ([Id])
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

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ApartamentoId', N'Cpf', N'IdApartamento', N'Nome', N'Perfil', N'Telefone') AND [object_id] = OBJECT_ID(N'[Pessoas]'))
    SET IDENTITY_INSERT [Pessoas] ON;
INSERT INTO [Pessoas] ([Id], [ApartamentoId], [Cpf], [IdApartamento], [Nome], [Perfil], [Telefone])
VALUES (1, NULL, N'56751898901', 0, N'João Gomes', NULL, N'11924316523'),
(2, NULL, N'63158658205', 0, N'Paola Oliveira', NULL, N'11975231678'),
(3, NULL, N'27458823908', 0, N'Marilia Mendonça', NULL, N'11937512056'),
(4, NULL, N'32152898910', 0, N'Sorriso Maroto', NULL, N'11987618735');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ApartamentoId', N'Cpf', N'IdApartamento', N'Nome', N'Perfil', N'Telefone') AND [object_id] = OBJECT_ID(N'[Pessoas]'))
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

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ApartamentoId', N'Cpf', N'DataAcesso', N'Email', N'IdApartamento', N'Nome', N'PasswordHash', N'PasswordSalt', N'Perfil', N'Telefone') AND [object_id] = OBJECT_ID(N'[Usuarios]'))
    SET IDENTITY_INSERT [Usuarios] ON;
INSERT INTO [Usuarios] ([Id], [ApartamentoId], [Cpf], [DataAcesso], [Email], [IdApartamento], [Nome], [PasswordHash], [PasswordSalt], [Perfil], [Telefone])
VALUES (1, NULL, NULL, NULL, N'admin@gmail.com', 1, N'UsuarioAdmin', 0x3BB5CB4262E7D0D975DB46ED5C4191061668C2A834E323FD2CD03F7A8FC4B38041E47D7413D55ABF840D02369FAE31B79EFC9210EAB253BAD40C5DE95E4E263C, 0xF9D7D04AFC5DD637A097769638FB72F8519B3289C178E15CF5D259C11756832BD571AB7427E801C17630FF8E101724807ADA9D0D1D99BEC1F2C39709636C6A604F2D4CA268FE0574021F85081393CEBEFACD7FF32CDE7226180C2F480824033A561D518D2FA8C95B948947FFB355149F60E00C680D87A8BCC15A29F3FF4F5A67, N'Admin', NULL),
(3, NULL, NULL, NULL, N'UsuarioSindico@gmail.com', 2, N'UsuarioSindico', 0x3BB5CB4262E7D0D975DB46ED5C4191061668C2A834E323FD2CD03F7A8FC4B38041E47D7413D55ABF840D02369FAE31B79EFC9210EAB253BAD40C5DE95E4E263C, 0xF9D7D04AFC5DD637A097769638FB72F8519B3289C178E15CF5D259C11756832BD571AB7427E801C17630FF8E101724807ADA9D0D1D99BEC1F2C39709636C6A604F2D4CA268FE0574021F85081393CEBEFACD7FF32CDE7226180C2F480824033A561D518D2FA8C95B948947FFB355149F60E00C680D87A8BCC15A29F3FF4F5A67, N'Sindico', NULL),
(4, NULL, NULL, NULL, N'UsuarioMorador@gmail.com', 3, N'UsuarioMorador', 0x3BB5CB4262E7D0D975DB46ED5C4191061668C2A834E323FD2CD03F7A8FC4B38041E47D7413D55ABF840D02369FAE31B79EFC9210EAB253BAD40C5DE95E4E263C, 0xF9D7D04AFC5DD637A097769638FB72F8519B3289C178E15CF5D259C11756832BD571AB7427E801C17630FF8E101724807ADA9D0D1D99BEC1F2C39709636C6A604F2D4CA268FE0574021F85081393CEBEFACD7FF32CDE7226180C2F480824033A561D518D2FA8C95B948947FFB355149F60E00C680D87A8BCC15A29F3FF4F5A67, N'Morador', NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ApartamentoId', N'Cpf', N'DataAcesso', N'Email', N'IdApartamento', N'Nome', N'PasswordHash', N'PasswordSalt', N'Perfil', N'Telefone') AND [object_id] = OBJECT_ID(N'[Usuarios]'))
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

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataEntrega', N'DataRetirada', N'Destinatario', N'IdApartamento', N'PortariaId') AND [object_id] = OBJECT_ID(N'[Entregas]'))
    SET IDENTITY_INSERT [Entregas] ON;
INSERT INTO [Entregas] ([Id], [DataEntrega], [DataRetirada], [Destinatario], [IdApartamento], [PortariaId])
VALUES (1, NULL, NULL, N'Joao Guilherme', 1, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataEntrega', N'DataRetirada', N'Destinatario', N'IdApartamento', N'PortariaId') AND [object_id] = OBJECT_ID(N'[Entregas]'))
    SET IDENTITY_INSERT [Entregas] OFF;
GO

CREATE INDEX [IX_Apartamentos_IdCondominio] ON [Apartamentos] ([IdCondominio]);
GO

CREATE INDEX [IX_ApartPessoas_ApartamentoId] ON [ApartPessoas] ([ApartamentoId]);
GO

CREATE INDEX [IX_ApartPessoas_PessoaId] ON [ApartPessoas] ([PessoaId]);
GO

CREATE INDEX [IX_Avisos_PessoaId] ON [Avisos] ([PessoaId]);
GO

CREATE INDEX [IX_Dependentes_IdPessoa] ON [Dependentes] ([IdPessoa]);
GO

CREATE INDEX [IX_Entregas_IdApartamento] ON [Entregas] ([IdApartamento]);
GO

CREATE INDEX [IX_Entregas_PortariaId] ON [Entregas] ([PortariaId]);
GO

CREATE INDEX [IX_Pessoas_ApartamentoId] ON [Pessoas] ([ApartamentoId]);
GO

CREATE INDEX [IX_Reservas_AreaComumId] ON [Reservas] ([AreaComumId]);
GO

CREATE INDEX [IX_Reservas_PessoaId] ON [Reservas] ([PessoaId]);
GO

CREATE INDEX [IX_Usuarios_ApartamentoId] ON [Usuarios] ([ApartamentoId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231127025858_Added', N'7.0.4');
GO

COMMIT;
GO

