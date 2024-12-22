CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

BEGIN TRANSACTION;
CREATE TABLE "ValoresMonetarios" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_ValoresMonetarios" PRIMARY KEY AUTOINCREMENT,
    "Valor" TEXT NOT NULL,
    "Quantidade" INTEGER NOT NULL,
    "TipoMoeda" TEXT NOT NULL
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20241222173850_InitialCreate', '9.0.0');

COMMIT;

