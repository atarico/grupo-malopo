using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using TrabajoPracticoAgustin.enums;
using TrabajoPracticoAgustin.models;

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
            return $"    Nombre: {Nombre} \n" +
                $"       Estado: {EstadoActual} \n" +
                $"       Cantidad de desarrolladores: {CantidadDesarrolladores}  \n" +
                $"       Tecnologia: {TecnologiaProyecto}\n" +
                $"       Fecha de inicio {FechaInicio.Date}\n";
        }

        public int CalcularDuracionEstimada()
        {
            if (TecnologiaProyecto.ToString() == "DesarrolloWeb")
            {
                if (EstadoActual.ToString() == "Planificacion")
                {
                    return 30;
                }
                else if (EstadoActual.ToString() == "EnDesarrollo")
                {
                    return 30 - 10;
                }
                else if (EstadoActual.ToString() == "EnPrueba")
                {
                    return 30 - 25;
                }
                else if (EstadoActual.ToString() == "Completado")
                {
                    return 30 - 30;
                }
                else
                {
                    return 0;
                }
            }
            else if (TecnologiaProyecto.ToString() == "DesarrolloMovil")
            {
                if (EstadoActual.ToString() == "Planificacion")
                {
                    return 50;
                }
                else if (EstadoActual.ToString() == "EnDesarrollo")
                {
                    return 50 - 10;
                }
                else if (EstadoActual.ToString() == "EnPrueba")
                {
                    return 50 - 30;
                }
                else if (EstadoActual.ToString() == "Completado")
                {
                    return 50 - 50;
                }
                else
                {
                    return 0;
                }
            }
            return 0;
        }
        public void CalcularFechaEstimada()
        {
            Console.WriteLine("Fecha de devolucion estimada: " + FechaInicio.AddDays(CalcularDuracionEstimada()));
        }
    }
}