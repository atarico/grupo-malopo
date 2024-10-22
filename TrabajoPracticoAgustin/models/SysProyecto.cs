using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using TrabajoPracticoAgustin.enums;

namespace TrabajoPracticoAgustin.models
{
    public class SysProyecto
    {
        static List<Proyecto> proyectos = new List<Proyecto>();
        static string ArchivoDatos = "proyectos.txt";
        static TipoProyecto tipo;
        static TipoProyecto tipo2;
        public void AgregaProyecto()
        {
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("Ingrese el nombre del proyecto: ");
            string nombre = Console.ReadLine();
            Console.WriteLine("ingrese el estado del proyecto\n " +
               "1 ->       Planificación   \n" +
                " 2 ->       En Desarrollo    \n" +
                " 3 ->       Completado       \n" +
                " 4 ->       En prueba        \n" +
                " 5 ->       Cancelado        \n");
            EstadoProyecto estado = (EstadoProyecto)Enum.Parse(typeof(EstadoProyecto), Console.ReadLine());
            Console.WriteLine("Ingrese la cantidad de desarrolladores que trabajaran en el proyecto: ");
            int desarrolladores = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el tipo de proyecto\n" +
                "1 ->        Desarrollo web\n" +
                "2 ->        Desarrollo movil\n");
            tipo = (TipoProyecto)Enum.Parse(typeof(TipoProyecto), Console.ReadLine());
            DateTime fecha = DateTime.Now;

            if ((int)tipo == 1)
            {
                Console.WriteLine("Que tecnologia vas a usar?\n" +
                 "1 ->    React\n" +
                 "2 ->    Angular\n" +
                 "3 ->    Vue.js\n");
                string tecnologia = Console.ReadLine();
                Proyecto desarrolloWeb = new DesarrolloWeb(nombre, estado, desarrolladores, fecha, tipo, tecnologia);
                proyectos.Add(desarrolloWeb);
            }
            else if ((int)tipo == 2)
            {
                Console.WriteLine("Plataformas objetivo?\n " +
                   "1 ->         iOS\n" +
                    " 2 ->         Android\n" +
                    " 3 ->         Windows Phone\n");
                string plataformas = Console.ReadLine();
                Proyecto desarrollomovil = new DesarrolloMovil(nombre, estado, desarrolladores, fecha, tipo, plataformas);
                proyectos.Add(desarrollomovil);
            }

            Console.WriteLine("Proyecto guardado correctamente.");
            Thread.Sleep(1000);
            Console.Clear();
        }
        public void ModificarProyecto()
        {
            Thread.Sleep(1000);
            Console.Clear();
            if (proyectos == null || proyectos.Count == 0) 
            {
                Console.WriteLine("No tienes ningún proyecto para modificar.");
                Thread.Sleep(1000);
                Console.Clear();
                return; 
            }

            bool seEncontro = false;
            Console.WriteLine("Los proyectos son los siguientes:");
            Console.WriteLine("\n");
            foreach (var proyecto in proyectos)
            {
                Console.WriteLine(proyecto.Nombre);
                Console.WriteLine("___________________");
            }
            Console.WriteLine("\n");
            Console.WriteLine("¿Cuál desea modificar? (por nombre)");
            string nombre = Console.ReadLine();

            foreach (var proyectito in proyectos)
            {
                if (nombre == proyectito.Nombre)
                {
                    Console.WriteLine("Ingrese el nuevo nombre del proyecto: ");
                    string nombreNuevo = Console.ReadLine();
                    Console.WriteLine("Ingrese el estado del nuevo proyecto\n " +
                        "1 ->       Planificación   \n" +
                        "2 ->       En Desarrollo    \n" +
                        "3 ->       En prueba        \n" +
                        "4 ->       Completado       \n" +
                        "5 ->       Cancelado        \n");
                    EstadoProyecto estadoNuevo = (EstadoProyecto)Enum.Parse(typeof(EstadoProyecto), Console.ReadLine());
                    Console.WriteLine("Ingrese la cantidad de desarrolladores que trabajarán en el nuevo proyecto: ");
                    int desarrolladoresProyectoNuevo = int.Parse(Console.ReadLine());
                    Console.WriteLine("Ingrese el tipo de proyecto\n" +
                        "1 ->        Desarrollo web\n" +
                        "2 ->        Desarrollo móvil\n");
                    TipoProyecto tipo = (TipoProyecto)Enum.Parse(typeof(TipoProyecto), Console.ReadLine());
                    DateTime fechaNueva = DateTime.Now;

                    if ((int)tipo == 1)
                    {
                        Console.WriteLine("¿Qué tecnología vas a usar?\n " +
                            "1 ->     React    \n" +
                            "2 ->      Angular \n" +
                            "3 ->      Vue.js \n");
                        string tecnologiaNueva = Console.ReadLine();
                        Proyecto desarrolloWeb = new DesarrolloWeb(nombreNuevo, estadoNuevo, desarrolladoresProyectoNuevo, fechaNueva, tipo, tecnologiaNueva);
                        proyectos.Add(desarrolloWeb);
                    }
                    else if ((int)tipo == 2)
                    {
                        Console.WriteLine("Plataformas objetivo?\n " +
                           "1 ->         iOS\n" +
                           "2 ->         Android\n" +
                           "3 ->         Windows Phone\n");
                        string plataformas = Console.ReadLine();
                        Proyecto desarrollomovil = new DesarrolloMovil(nombreNuevo, estadoNuevo, desarrolladoresProyectoNuevo, fechaNueva, tipo, plataformas);
                        proyectos.Add(desarrollomovil);
                    }
                    proyectos.Remove(proyectito);
                    Console.WriteLine("Proyecto modificado correctamente.");
                    seEncontro = true;
                    Thread.Sleep(1000);
                    Console.Clear();
                    break; 
                }
            }
            if (!seEncontro) 
            {
                Console.WriteLine("No se encontró ningún proyecto con ese nombre.");
                Thread.Sleep(1000);
                Console.Clear();
            }
        }
        public void EliminarProyecto()
        {
            Thread.Sleep(1000);
            Console.Clear();
            if (proyectos == null || proyectos.Count == 0)
            {
                Console.WriteLine("No tienes ningún proyecto para eliminar.");
                Thread.Sleep(1000);
                Console.Clear();
                return;
            }

            Console.WriteLine("¿Qué proyecto quieres eliminar? (nombre)");
            Console.WriteLine("\n");
            foreach (var proyect in proyectos)
            {
                Console.WriteLine(proyect.Nombre);
                Console.WriteLine("----------------------------------");
            }
            Console.WriteLine("\n");
            Console.WriteLine("Ahora elige cuál deseas eliminar:");
            string nombre = Console.ReadLine();

            bool seEncontro = false;
            foreach (var proyecto in proyectos)
            {
                if (nombre == proyecto.Nombre)
                {
                    Console.WriteLine($"Proyecto {proyecto.Nombre} eliminado.");
                    proyectos.Remove(proyecto);
                    seEncontro = true;
                    break; 
                }
            }
            if (!seEncontro)
            {
                Console.WriteLine("No se encontró ese proyecto.");
                Thread.Sleep(1000);
                Console.Clear();
            }
            Thread.Sleep(1000);
            Console.Clear();
        }
        public void VisualizarProyectos()
        {
            while (true)
            {
                Thread.Sleep(1000);
                Console.Clear();
                bool SeEncontro = false;
                foreach (var proyecto in proyectos)
                {

                    if (tipo2 == TipoProyecto.DesarrolloWeb)
                    {
                        Console.WriteLine(proyecto);
                        proyecto.CalcularFechaEstimada();
                        SeEncontro = true;
                    }
                    else if (tipo2 == TipoProyecto.DesarrolloMovil)
                    {
                        Console.WriteLine(proyecto);
                        proyecto.CalcularFechaEstimada();
                        SeEncontro = true;
                    }
                }
                if (!SeEncontro)
                {
                    Console.WriteLine("no tienes ningun proyecto para ver.");
                    Console.WriteLine("\n");
                }
                Console.WriteLine("Ingrese 'salir' o 'S' si quiere volver al menu");
                string salir = Console.ReadLine();
                if(salir == "salir" || salir == "Salir" || salir == "S" || salir == "s")
                {
                    Thread.Sleep(1000);
                    Console.Clear();
                    break;
                }
                else
                {
                    Console.WriteLine("palabra mal escrita.");
                }
            }
        }
        public void CargarArchivos()
        {
            if (File.Exists(ArchivoDatos))
            {
                using (StreamReader reader = new StreamReader(ArchivoDatos))
                {
                    string linea;
                    while ((linea = reader.ReadLine()) != null)
                    {
                        string[] datos = linea.Split(',');
                        string nombre = datos[0];
                        EstadoProyecto estado = (EstadoProyecto)Enum.Parse(typeof(EstadoProyecto), datos[1]);
                        int desarrolladores = int.Parse(datos[2]);
                        DateTime fecha = DateTime.Parse(datos[3]);
                        tipo = (TipoProyecto)Enum.Parse(typeof(TipoProyecto), datos[4]);
                        string tecnologia_plataforma = datos[5];

                        if (tipo == TipoProyecto.DesarrolloWeb)
                        {
                            proyectos.Add(new DesarrolloWeb(nombre, estado, desarrolladores, fecha, tipo, tecnologia_plataforma));
                        }
                        else
                        {
                            proyectos.Add(new DesarrolloMovil(nombre, estado, desarrolladores, fecha, tipo, tecnologia_plataforma));
                        }
                    }
                }
            }
        }
        public void GuardarProyectos()
        {
            using (StreamWriter writer = new StreamWriter(ArchivoDatos))
            {
                foreach (Proyecto proyecto in proyectos)
                {
                    writer.WriteLine($"{proyecto.Nombre},{proyecto.EstadoActual},{proyecto.CantidadDesarrolladores},{proyecto.FechaInicio},{proyecto.TecnologiaProyecto},{proyecto.ObtenerDatoEspecifico()}");
                }
            }
        }
    }
}