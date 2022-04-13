using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_PreParcial_ProgII
{
    public class Persona
    {
        public string NombreApellido { get; set; }
        public int DNI { get; set; }
        public double Saldo { get; set; }
        public List<Movimiento> HistoricoMovimientos { get; set; }
        public Persona(string nombreApellido, int dni, double saldo)
        {
            this.NombreApellido = nombreApellido;
            this.DNI = dni;
            this.Saldo = saldo;
            this.HistoricoMovimientos = new List<Movimiento>();
        }
    }
}
