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
        public string PlataformasObjetivo { get; set; }
        public DesarrolloMovil(string nombre, EstadoProyecto estado, int desarrolladores, DateTime fechaInicio, TipoProyecto tipoProyecto, string PlataformaObjetivo) :
            base(nombre, estado, desarrolladores, fechaInicio, tipoProyecto)
        {
            this.PlataformasObjetivo = PlataformasObjetivo;
        }
        public override string ObtenerDatoEspecifico()
        {
            return PlataformasObjetivo;
        }
    }
}