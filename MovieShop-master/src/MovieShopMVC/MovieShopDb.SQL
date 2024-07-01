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

CREATE TABLE [Cast] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(128) NULL,
    [Gender] nvarchar(max) NULL,
    [TmdbUrl] nvarchar(max) NULL,
    [ProfilePath] nvarchar(2084) NULL,
    CONSTRAINT [PK_Cast] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Genre] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(24) NULL,
    CONSTRAINT [PK_Genre] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Movie] (
    [Id] int NOT NULL IDENTITY,
    [Title] nvarchar(256) NULL,
    [Overview] nvarchar(max) NULL,
    [Tagline] nvarchar(512) NULL,
    [Budget] decimal(18,2) NULL,
    [Revenue] decimal(18,2) NULL,
    [ImdbUrl] nvarchar(2084) NULL,
    [TmdbUrl] nvarchar(2084) NULL,
    [PosterUrl] nvarchar(2084) NULL,
    [BackdropUrl] nvarchar(2084) NULL,
    [OriginalLanguage] nvarchar(64) NULL,
    [ReleaseDate] datetime2 NULL,
    [RunTime] int NULL,
    [Price] decimal(5,2) NULL DEFAULT 9.9,
    [CreatedDate] datetime2 NULL DEFAULT (getdate()),
    [UpdatedDate] datetime2 NULL,
    [UpdatedBy] nvarchar(max) NULL,
    [CreatedBy] nvarchar(max) NULL,
    CONSTRAINT [PK_Movie] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Role] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(20) NULL,
    CONSTRAINT [PK_Role] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [User] (
    [Id] int NOT NULL IDENTITY,
    [FirstName] nvarchar(128) NULL,
    [LastName] nvarchar(128) NULL,
    [DateOfBirth] datetime2 NULL,
    [Email] nvarchar(256) NULL,
    [HashedPassword] nvarchar(1024) NULL,
    [Salt] nvarchar(1024) NULL,
    [PhoneNumber] nvarchar(16) NULL,
    [TwoFactorEnabled] bit NULL,
    [LockoutEndDate] datetime2 NULL,
    [LastLoginDateTime] datetime2 NULL,
    [IsLocked] bit NULL DEFAULT CAST(0 AS bit),
    [AccessFailedCount] int NULL,
    CONSTRAINT [PK_User] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [MovieCast] (
    [MovieId] int NOT NULL,
    [CastId] int NOT NULL,
    [Character] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_MovieCast] PRIMARY KEY ([CastId], [MovieId], [Character]),
    CONSTRAINT [FK_MovieCast_Cast_CastId] FOREIGN KEY ([CastId]) REFERENCES [Cast] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_MovieCast_Movie_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [Movie] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [MovieGenre] (
    [GenreId] int NOT NULL,
    [MovieId] int NOT NULL,
    CONSTRAINT [PK_MovieGenre] PRIMARY KEY ([GenreId], [MovieId]),
    CONSTRAINT [FK_MovieGenre_Genre_GenreId] FOREIGN KEY ([GenreId]) REFERENCES [Genre] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_MovieGenre_Movie_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [Movie] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Trailer] (
    [Id] int NOT NULL IDENTITY,
    [MovieId] int NOT NULL,
    [TrailerUrl] nvarchar(2084) NULL,
    [Name] nvarchar(2084) NULL,
    CONSTRAINT [PK_Trailer] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Trailer_Movie_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [Movie] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Favorite] (
    [MovieId] int NOT NULL,
    [UserId] int NOT NULL,
    CONSTRAINT [PK_Favorite] PRIMARY KEY ([MovieId], [UserId]),
    CONSTRAINT [FK_Favorite_Movie_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [Movie] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Favorite_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [User] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Purchase] (
    [Id] int NOT NULL IDENTITY,
    [UserId] int NOT NULL,
    [PurchaseNumber] uniqueidentifier NOT NULL,
    [TotalPrice] decimal(18,2) NOT NULL,
    [PurchaseDateTime] datetime2 NOT NULL,
    [MovieId] int NOT NULL,
    CONSTRAINT [PK_Purchase] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Purchase_Movie_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [Movie] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Purchase_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [User] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Review] (
    [MovieId] int NOT NULL,
    [UserId] int NOT NULL,
    [Rating] decimal(3,2) NOT NULL,
    [ReviewText] nvarchar(max) NULL,
    [CreatedDate] datetime2 NOT NULL DEFAULT (getdate()),
    CONSTRAINT [PK_Review] PRIMARY KEY ([MovieId], [UserId]),
    CONSTRAINT [FK_Review_Movie_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [Movie] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Review_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [User] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [UserRole] (
    [RoleId] int NOT NULL,
    [UserId] int NOT NULL,
    CONSTRAINT [PK_UserRole] PRIMARY KEY ([RoleId], [UserId]),
    CONSTRAINT [FK_UserRole_Role_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Role] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_UserRole_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [User] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Cast_Name] ON [Cast] ([Name]);
GO

CREATE INDEX [IX_Favorite_UserId] ON [Favorite] ([UserId]);
GO

CREATE INDEX [IX_MovieCast_MovieId] ON [MovieCast] ([MovieId]);
GO

CREATE INDEX [IX_MovieGenre_MovieId] ON [MovieGenre] ([MovieId]);
GO

CREATE INDEX [IX_Purchase_MovieId] ON [Purchase] ([MovieId]);
GO

CREATE UNIQUE INDEX [IX_Purchase_UserId_MovieId] ON [Purchase] ([UserId], [MovieId]);
GO

CREATE INDEX [IX_Review_UserId] ON [Review] ([UserId]);
GO

CREATE INDEX [IX_Trailer_MovieId] ON [Trailer] ([MovieId]);
GO

CREATE UNIQUE INDEX [IX_User_Email] ON [User] ([Email]) WHERE [Email] IS NOT NULL;
GO

CREATE INDEX [IX_UserRole_UserId] ON [UserRole] ([UserId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210222202009_DbMigration', N'6.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [User] ADD [ProfilePictureUrl] nvarchar(max) NULL;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Purchase]') AND [c].[name] = N'TotalPrice');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Purchase] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Purchase] ALTER COLUMN [TotalPrice] decimal(5,2) NOT NULL;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Movie]') AND [c].[name] = N'Revenue');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Movie] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Movie] ALTER COLUMN [Revenue] decimal(18,4) NULL;
ALTER TABLE [Movie] ADD DEFAULT 9.9 FOR [Revenue];
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Movie]') AND [c].[name] = N'Budget');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Movie] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Movie] ALTER COLUMN [Budget] decimal(18,4) NULL;
ALTER TABLE [Movie] ADD DEFAULT 9.9 FOR [Budget];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210402143125_UserProfilePictureColumn', N'6.0.0');
GO

COMMIT;
GO

