using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tomas.Seguros.Practica2
{
    internal class Poliza
    {
        public int NumeroPoliza { get; set; } //No se puede repetir.
        public string NombreCliente { get; set; }
        public string FechaEmision { get; set; }

        public double PrimaTotal { get; set; }

        public List<Bienes> listaBienes { get; set; }

        //Constructor
        public Poliza(int pNumeroPoliza, string pNombreCliente)
        {
            NumeroPoliza = pNumeroPoliza;
            NombreCliente = pNombreCliente;
            FechaEmision = DateTime.Now.ToString();
            listaBienes = new List<Bienes>();
        }

        //Metodos
        /*
        public void agregarBienesAPoliza()
        {

        }*/

        public double getImporte()
        {
            double retorno = 0;
            foreach(Bienes bien in listaBienes)
            {
                double valorBien = bien.getValorDeclarado();
                retorno = retorno + valorBien;
            }
            return retorno;
        }

        public override string ToString()
        {
            // Mostrar las propiedades principales de la póliza
            string bienesStr = listaBienes != null && listaBienes.Count > 0
                ? string.Join(", ", listaBienes.Select(b => b.ToString())) // Asumiendo que Bienes tiene su propio ToString()
                : "No hay bienes declarados";

            return $"Número de Póliza: {NumeroPoliza}\n" +
                   $"Cliente: {NombreCliente}\n" +
                   $"Fecha de Emisión: {FechaEmision}\n" +
                   $"Prima Total: {PrimaTotal:C}\n" +
                   $"Cantidad de Bienes en poliza: {listaBienes.Count}";
        }
    }
}
