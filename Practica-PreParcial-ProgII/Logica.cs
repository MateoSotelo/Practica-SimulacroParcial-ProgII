using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_PreParcial_ProgII
{
    public class Logica
    {
        public List<Persona> Personas = new List<Persona>();
        public List<Movimiento> Movimientos = new List<Movimiento>();
        public Persona BuscarPersona(int dni)
        {
            return Personas.Find(x => x.DNI == dni);
        }
        public short POST(int dniEnvia,int dniRecibe,string descripcion,double monto)
        {
            Persona envia = BuscarPersona(dniEnvia);
            Persona recibe = BuscarPersona(dniRecibe);

            if (envia == null || recibe == null)
            {
                new Exception("Persona no encontrada");
                return 400;
            }
            else
            {
                Movimiento nuevoMovimientoEnvia = new Movimiento(Movimientos.Count() + 1,envia.DNI, DateTime.Today, descripcion, monto);
                envia.HistoricoMovimientos.Add(nuevoMovimientoEnvia);
                Movimientos.Add(nuevoMovimientoEnvia);
                envia.Saldo =+ monto;

                Movimiento nuevoMovimientoRecibe = new Movimiento(Movimientos.Count() + 1,recibe.DNI, DateTime.Today, descripcion, -monto);
                recibe.HistoricoMovimientos.Add(nuevoMovimientoRecibe);
                Movimientos.Add(nuevoMovimientoRecibe);
                recibe.Saldo =- monto;

                return 201;
            }
        }
        public bool DELETE(int idMovimiento)
        {
            Movimiento MovimientoCancelar = Movimientos.Find(x => x.ID == idMovimiento);
            Persona afectadoEnvia = BuscarPersona(MovimientoCancelar.DNIenvia);
            Persona afectadoRecibe = BuscarPersona(MovimientoCancelar.DNIrecibe);

            Movimiento CancelacionEnvia = new Movimiento(Movimientos.Count + 1, 0, DateTime.Today, $"Cancelacion: {MovimientoCancelar.Descripcion}", -(MovimientoCancelar.Monto));
            afectadoEnvia.HistoricoMovimientos.Add(CancelacionEnvia);
            Movimientos.Add(CancelacionEnvia);

            Movimiento CancelacionRecibe = new Movimiento(Movimientos.Count + 1, 0, DateTime.Today, $"Cancelacion: {MovimientoCancelar.Descripcion}", MovimientoCancelar.Monto);
            afectadoRecibe.HistoricoMovimientos.Add(CancelacionRecibe);
            Movimientos.Add(CancelacionRecibe);

            return true;   
        }
        public List<Movimiento> ObtenerListaMovimientos(int dni)
        {
            Persona persona = BuscarPersona(dni);
            if (persona == null)
            {
                throw new Exception("404");
            }

            return persona.HistoricoMovimientos.OrderByDescending(x => x.Fecha).ToList();
        }
    }
}
