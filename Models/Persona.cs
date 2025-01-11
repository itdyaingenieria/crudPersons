
namespace Prueba_YamaAndrade.Models
{
    using System;
    using System.Collections.Generic;

    public class Persona
    {
        public int IdPersona { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Identificacion { get; set; }
        public string Genero { get; set; } // 'M' o 'F'
        public DateTime Fecha_nacimiento { get; set; }
        public string Contrasena { get; set; }
        public bool Activo { get; set; }
    }
}