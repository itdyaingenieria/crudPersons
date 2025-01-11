using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prueba_YamaAndrade.Migrations
{
    /// <inheritdoc />
    public partial class AddStoredProcedure_CreatePersonaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Crear el procedimiento almacenado en la base de datos
            migrationBuilder.Sql(@"
             CREATE PROCEDURE CrearTablaPersona
                @nuevoNombreTabla NVARCHAR(255)
             AS
             BEGIN
                DECLARE @sql NVARCHAR(MAX);

                -- Verificar si la tabla ya existe
                IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = @nuevoNombreTabla)
                BEGIN
                    -- Si no existe, crear la nueva tabla (sin la columna IDENTITY)
                    SET @sql = 'SELECT IdPersona, Nombres, Apellidos, Identificacion, Genero, Fecha_nacimiento, Contrasena, Activo
                                INTO ' + @nuevoNombreTabla + '
                                FROM Personas';
                    EXEC sp_executesql @sql;
                END

                -- Crear la clave primaria en la nueva tabla
                SET @sql = 'ALTER TABLE ' + @nuevoNombreTabla + '
                            ADD CONSTRAINT PK_' + @nuevoNombreTabla + ' PRIMARY KEY (IdPersona)';
                EXEC sp_executesql @sql;
             END;
        ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Eliminar el procedimiento almacenado si la migración se revierte
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS CrearTablaPersona");
        }
    }
}
