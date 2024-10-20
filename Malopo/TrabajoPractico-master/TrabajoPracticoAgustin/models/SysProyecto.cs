using System;
using System.Collections.Generic;
using System.Linq;
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
        public void AgregaProyecto()
        {
            Console.WriteLine("Ingrese el nombre del proyecto: ");
            string nombre = Console.ReadLine();
            Console.WriteLine("ingrese el estado del proyecto (Planificación, En Desarrollo, En Pruebas, Completado o Cancelado): ");
            EstadoProyecto estado = (EstadoProyecto)Enum.Parse(typeof(EstadoProyecto), Console.ReadLine());
            Console.WriteLine("Ingrese la cantidad de desarrolladores que trabajaran en el proyecto: ");
            int desarrolladores = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el tipo de proyecto (Desarrollo web, Desarrollo movil)");
            TipoProyecto tipo = (TipoProyecto)Enum.Parse(typeof(TipoProyecto), Console.ReadLine());

            if(tipo == TipoProyecto.DesarrolloWeb)
            {
                Console.WriteLine("Que tecnologia vas a usar? (React, Angular, Vue.js)");
                string tecnologia = Console.ReadLine();
                DesarrolloWeb desarrolloWeb = new DesarrolloWeb(nombre,estado,desarrolladores,tecnologia);
                proyectos.Add(desarrolloWeb);
            }
            else
            {
                Console.WriteLine("Plataformas objetivo? (iOS, Android, Windows Phone)");
                string plataformas = Console.ReadLine();
                DesarrolloMovil desarrollomovil = new DesarrolloMovil(nombre, estado, desarrolladores, plataformas);
                proyectos.Add (desarrollomovil);
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
            foreach(var proyecto in proyectos)
            {
                Console.WriteLine(proyecto);
            }
        }
        public void CargarArchivos()
        {

        }
    }
}
