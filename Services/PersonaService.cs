using Microsoft.EntityFrameworkCore;
using Prueba_YamaAndrade.Data;

namespace Prueba_YamaAndrade.Services
{
    public class PersonaService
    {
        private readonly AppDBContext _appDbContext;

        public PersonaService(AppDBContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void CrearTablaPersona(string nuevoNombreTabla)
        {
            var sql = "EXEC CrearTablaPersona @nuevoNombreTabla";

            // Ejecutar el procedimiento almacenado
            _appDbContext.Database.ExecuteSqlRaw(sql, new Microsoft.Data.SqlClient.SqlParameter("@nuevoNombreTabla", nuevoNombreTabla));
        }
    }
}
