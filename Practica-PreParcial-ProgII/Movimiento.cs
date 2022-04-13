using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_PreParcial_ProgII
{
    public class Movimiento
    {
        public int ID { get; set; }
        public int DNIenvia { get; set; }
        public int DNIrecibe { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public bool EsEnvio { get; set; }
        public double Monto { get; set; }
        public Movimiento(int id, int dni,DateTime fecha,string descripcion,double monto)
        {
            this.EsEnvio = monto > 0 ? true : false;
            this.DNIcliente = dni;
            this.ID = id;
            this.Fecha = fecha;
            this.Descripcion = descripcion;
            this.Monto = monto;
        }
    }
}
