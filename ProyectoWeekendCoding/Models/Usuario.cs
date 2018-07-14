using System;

namespace ProyectoWeekendCoding.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        public string NombreDeUsuario { get; set; }

        public string NombreParaMostrar { get; set; }

        public DateTime FechaDeNacimiento { get; set; }

        public string Ocupacion { get; set; }
    }
}