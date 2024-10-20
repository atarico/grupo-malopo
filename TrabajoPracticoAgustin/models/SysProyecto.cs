using System;
using System.Collections.Generic;
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

            if (tipo == TipoProyecto.DesarrolloWeb)
            {
                Console.WriteLine("Que tecnologia vas a usar?\n " +
                    "1 ->      React\n" +
                    "2 ->      Angular\n" +
                    "3 ->      Vue.js\n");
                string tecnologia = Console.ReadLine();
                DesarrolloWeb desarrolloWeb = new DesarrolloWeb(nombre, estado, desarrolladores, tecnologia);
                proyectos.Add(desarrolloWeb);
            }
            else
            {
                Console.WriteLine("Plataformas objetivo?\n " +
                   "1 ->         iOS\n" +
                    " 2 ->         Android\n" +
                    " 3 ->         Windows Phone\n");
                string plataformas = Console.ReadLine();
                DesarrolloMovil desarrollomovil = new DesarrolloMovil(nombre, estado, desarrolladores, plataformas);
                proyectos.Add(desarrollomovil);
            }
            Console.WriteLine("Proyecto guardado correctamente.");

        }
        public void ModificarProyecto()
        {

        }
        public void EliminarProyecto()
        {

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

        }

        public void GuardarProyectos()
        {

        }
    }
}