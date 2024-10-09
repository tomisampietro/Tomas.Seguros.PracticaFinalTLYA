using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tomas.Seguros.Practica2
{
    internal class Rodado: Bienes
    {
        public string Patente { get; set; }
        public int Anio { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public double ValorDeclarado { get; set; }

        public Rodado(double pValorDeclarado, string pPatente, int pAnio, string pMarca, string pModelo): base(pValorDeclarado)
        {
            Patente = pPatente;
            Anio = pAnio;
            Marca = pMarca;
            Modelo = pModelo;
            ValorDeclarado = pValorDeclarado;
        }
    }
}
