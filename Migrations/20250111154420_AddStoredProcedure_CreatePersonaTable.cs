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
                @nuevoNombreTabla NVARCHAR(128)
            AS
            BEGIN
                DECLARE @sql NVARCHAR(MAX)

                -- Crear la nueva tabla con la misma estructura que la tabla persona
                SET @sql = 'SELECT * INTO ' + QUOTENAME(@nuevoNombreTabla) + ' FROM persona WHERE 1 = 0;'
                EXEC sp_executesql @sql;

                -- Insertar los registros de la tabla persona en la nueva tabla
                SET @sql = 'INSERT INTO ' + QUOTENAME(@nuevoNombreTabla) + ' SELECT * FROM persona;'
                EXEC sp_executesql @sql;
            END
        ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Eliminar el procedimiento almacenado si la migración se revierte
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS CrearTablaPersona");
        }
    }
}
