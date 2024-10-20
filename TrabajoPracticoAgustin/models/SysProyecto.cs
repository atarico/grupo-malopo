using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TrabajoPracticoAgustin.enums;

namespace TrabajoPracticoAgustin.models
{
    public class SysProyecto
    {
        static List<Proyecto> proyectos = new List<Proyecto>();
        static string ArchivoDatos = "proyectos.txt";
        static TipoProyecto tipo;
        public void AgregaProyecto()
        {
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

            if (tipo == TipoProyecto.DesarrolloWeb)
            {
                Console.WriteLine("Que tecnologia vas a usar?\n " +
                    "1 ->      React\n" +
                    "2 ->      Angular\n" +
                    "3 ->      Vue.js\n");
                string tecnologia = Console.ReadLine();
                Proyecto desarrolloWeb = new DesarrolloWeb(nombre, estado, desarrolladores, fecha, tipo, tecnologia);
                proyectos.Add(desarrolloWeb);
            }
            else
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

        }
        public void ModificarProyecto()
        {

        }
        public void EliminarProyecto()
        {
            Console.WriteLine("Que proyecto quieres eliminar? (nombre)");
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
                Console.WriteLine("no se encontro ese proyecto");
            }
        }
        public void VisualizarProyectos()
        {
            foreach (var proyecto in proyectos)
            {
                
                if (tipo == TipoProyecto.DesarrolloWeb)
                {
                    Console.WriteLine(proyecto);
                    proyecto.CalcularFechaEstimada();
                }
                else if (tipo == TipoProyecto.DesarrolloMovil)
                {
                    Console.WriteLine(proyecto);
                    proyecto.CalcularFechaEstimada();
                }
                Console.WriteLine("--------------------------");
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
                foreach(Proyecto proyecto in proyectos)
                {
                    writer.WriteLine($"{proyecto.Nombre},{proyecto.EstadoActual},{proyecto.CantidadDesarrolladores},{proyecto.FechaInicio},{proyecto.TecnologiaProyecto},{proyecto.ObtenerDatoEspecifico()}");
                }
            }
        }
    }
}