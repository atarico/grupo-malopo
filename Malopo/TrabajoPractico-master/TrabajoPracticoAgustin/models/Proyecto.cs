using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoPracticoAgustin.enums;

namespace TrabajoPracticoAgustin
{
    public abstract class Proyecto
    {
        public string Nombre { get; set; }
        public EstadoProyecto EstadoActual { get; set; }
        public int CantidadDesarrolladores { get; set; }
        public TipoProyecto TecnologiaProyecto { get; set; }

        public DateTime FechaInicio { get; set; }
        public Proyecto(string nombre, EstadoProyecto estado, int desarrolladores)
        {
            Nombre = nombre;
            EstadoActual = estado;
            CantidadDesarrolladores = desarrolladores;
            FechaInicio = DateTime.Now;
        }
        public override string ToString()
        {
            return $"Nombre {Nombre}, Estado: {EstadoActual}, Cantidad de desarrolladores: {CantidadDesarrolladores}, Fecha de inicio {FechaInicio.Date}";
        }


    }
}
