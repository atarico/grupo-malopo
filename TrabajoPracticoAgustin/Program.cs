using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrabajoPracticoAgustin.models;

namespace TrabajoPracticoAgustin
{
    class Program
    {
        
        static void Main(string[] args)
        {
            SysProyecto sistemaProyecto = new SysProyecto();
            int opcion;
            sistemaProyecto.CargarArchivos();
            do
            {
                Console.WriteLine("--------MENU--------");
                Console.WriteLine("1. Registrar proyecto");
                Console.WriteLine("2. Modificar proyecto");
                Console.WriteLine("3. Eliminar proyecto");
                Console.WriteLine("4. Visualizar proyectos");
                Console.WriteLine("5. Guadar y salir");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        sistemaProyecto.AgregaProyecto();
                        break;

                    case 2:
                        break;

                    case 3:
                        break;

                    case 4:
                        sistemaProyecto.VisualizarProyectos();
                        break;
                }
            }
            while (opcion != 5);
            sistemaProyecto.GuardarProyectos();
            Console.WriteLine("Hasta luego!!");
            Thread.Sleep(2000);

        }
    }
}
