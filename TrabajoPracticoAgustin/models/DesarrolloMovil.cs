using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoPracticoAgustin.enums;

namespace TrabajoPracticoAgustin.models
{
    public class DesarrolloMovil : Proyecto
    {
        public string PlataformasObjetivo {  get; set; }
        public DesarrolloMovil(string nombre, EstadoProyecto estado, int desarrolladores, string PlataformaObjetivo) :
            base(nombre,estado,desarrolladores)
        {
            this.PlataformasObjetivo = PlataformasObjetivo;
        }
    }
}
