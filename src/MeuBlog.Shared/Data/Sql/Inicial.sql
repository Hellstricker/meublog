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

CREATE TABLE [Autores] (
    [Id] int NOT NULL IDENTITY,
    [Nome] varchar(100) NOT NULL,
    [UsuarioAplicacaoId] nvarchar(max) NULL,
    CONSTRAINT [PK_Autores] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Posts] (
    [Id] int NOT NULL IDENTITY,
    [Titulo] varchar(100) NOT NULL,
    [Descricao] varchar(1000) NOT NULL,
    [DataPublicacao] datetime NOT NULL DEFAULT (getdate()),
    [AutorId] int NOT NULL,
    CONSTRAINT [PK_Posts] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Posts_Autores_AutorId] FOREIGN KEY ([AutorId]) REFERENCES [Autores] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Comentarios] (
    [Id] int NOT NULL IDENTITY,
    [PostId] int NOT NULL,
    [Descricao] varchar(500) NOT NULL,
    [AutorId] int NOT NULL,
    [DataCriacao] datetime NOT NULL DEFAULT (getdate()),
    CONSTRAINT [PK_Comentarios] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Comentarios_Autores_AutorId] FOREIGN KEY ([AutorId]) REFERENCES [Autores] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Comentarios_Posts_PostId] FOREIGN KEY ([PostId]) REFERENCES [Posts] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Comentarios_AutorId] ON [Comentarios] ([AutorId]);
GO

CREATE INDEX [IX_Comentarios_PostId] ON [Comentarios] ([PostId]);
GO

CREATE INDEX [IX_Posts_AutorId] ON [Posts] ([AutorId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240923223435_Inicial', N'8.0.8');
GO

COMMIT;
GO

